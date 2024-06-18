using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

// ReSharper disable UnusedType.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace Engine;

public abstract class PixelEngine
{
    private readonly WriteableBitmap _bitmap;
    private readonly byte[] _bytes;
    private readonly Int32Rect _rect32;
    private readonly Window _window;
    private readonly IntRect _rect;
    private readonly int _stride;

    protected PixelEngine(int width, int height, int pixelWidth, int pixelHeight, double systemScale)
    {
        Width = width;
        Height = height;
        Size = new(Width, Height);
        _bitmap = new(width, height, 96, 96, PixelFormats.Rgb24, null);
        Image image = new()
        {
            Width = width * pixelWidth / systemScale, Height = height * pixelHeight / systemScale,
            Stretch = Stretch.Fill, VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Left, Source = _bitmap
        };
        RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.NearestNeighbor);
        _window = new()
        {
            Title = "Pixel Engine Window", Content = image, SizeToContent = SizeToContent.WidthAndHeight,
            ResizeMode = ResizeMode.CanMinimize
        };
        _rect32 = new(0, 0, width, height);
        _rect = new(0, 0, width, height);
        _stride = 3 * width;
        _bytes = new byte[_stride * height];
        _window.Show();
        KeyTracker = new();
        Mouse = new(image, pixelWidth, pixelHeight, systemScale);
        image.MouseMove += Mouse.OnMouseMove;
    }

    protected int Width { get; }
    protected int Height { get; }
    protected Int2 Size { get; }
    protected KeyboardTracker KeyTracker { get; }
    protected MouseTracker Mouse { get; }

    protected string Title { set => _window.Title = value; get => _window.Title; }

    protected abstract void OnCreate();
    protected abstract bool OnLoop(long elapsedMillis);

    public async void Start()
    {
        OnCreate();
        bool loop;
        Stopwatch stopwatch = new();
        stopwatch.Start();
        long prev = stopwatch.ElapsedMilliseconds;
        do
        {
            long current = stopwatch.ElapsedMilliseconds;
            loop = OnLoop(current - prev);
            Render();
            KeyTracker.Update();
            Mouse.Update();
            await Task.Delay(1);
            prev = current;
        } while (loop);
    }

    private void Render() => _bitmap.WritePixels(_rect32, _bytes, _stride, 0);

    protected Pixel GetPixel(Int2 position)
    {
        if (!IsInside(position))
            return default;
        int index = Index(position);
        return new(_bytes[index], _bytes[index + 1], _bytes[index + 2]);
    }

    protected Pixel GetPixel(int x, int y) => GetPixel(new(x, y));

    protected void DrawPixel(Pixel? pixel, Int2 position)
    {
        if (!pixel.HasValue || !IsInside(position))
            return;
        int index = Index(position);
        (_bytes[index], _bytes[index + 1], _bytes[index + 2]) = pixel.Value;
    }

    protected void DrawPixel(Pixel? pixel, int x, int y) => DrawPixel(pixel, new(x, y));

    protected void ChangePixel(Int2 position, Func<Pixel, Pixel?> func)
    {
        if (!IsInside(position))
            return;
        int index = Index(position);
        Pixel pixel = new(_bytes[index], _bytes[index + 1], _bytes[index + 2]);
        Pixel? result = func.Invoke(pixel);
        if (result.HasValue)
            (_bytes[index], _bytes[index + 1], _bytes[index + 2]) = result.Value;
    }

    protected void ChangePixel(int x, int y, Func<Pixel, Pixel?> func) => ChangePixel(new(x, y), func);

    public void DrawHorizontalLine(int xStart, int xEnd, int y, Pixel color)
    {
        if (y < 0 || y >= Height || xEnd < 0 || xStart >= Width)
            return;
        xStart = Math.Max(xStart, 0);
        xEnd = Math.Min(xEnd, Width - 1);
        int iStart = Index(xStart, y);
        int iEnd = iStart + (xEnd - xStart) * 3;
        for (int i = iStart; i <= iEnd; i += 3)
            (_bytes[i], _bytes[i + 1], _bytes[i + 2]) = color;
    }

    public void DrawVerticalLine(int yStart, int yEnd, int x, Pixel color)
    {
        if (x < 0 || x >= Width || yEnd < 0 || yStart >= Height)
            return;
        yStart = Math.Max(yStart, 0);
        yEnd = Math.Min(yEnd, Height - 1);
        int iStart = Index(x, yStart);
        int iEnd = iStart + (yEnd - yStart) * _stride;
        for (int i = iStart; i <= iEnd; i += _stride)
            (_bytes[i], _bytes[i + 1], _bytes[i + 2]) = color;
    }

    protected void DrawLine(IntLine line, Pixel color)
    {
        int dx = Math.Abs(line.End.X - line.Start.X), sx = Math.Sign(line.End.X - line.Start.X);
        int dy = -Math.Abs(line.End.Y - line.Start.Y), sy = Math.Sign(line.End.Y - line.Start.Y);
        int err = dx + dy;
        Int2 point = line.Start;
        while (true)
        {
            DrawPixel(color, point);
            if (point == line.End)
                break;
            int e2 = 2 * err;
            if (e2 >= dy)
            {
                err += dy;
                point.X += sx;
            }
            if (e2 <= dx)
            {
                err += dx;
                point.Y += sy;
            }
        }
    }

    protected void DrawLine(Int2 start, Int2 end, Pixel color) => DrawLine(new(start, end), color);

    protected void DrawLine(int xStart, int yStart, int xEnd, int yEnd, Pixel color) =>
        DrawLine(new(xStart, yStart, xEnd, yEnd), color);

    protected void DrawTriangle(IntTriangle triangle, Pixel color)
    {
        int? Intersection(Int2 start, Int2 end, int yLevel)
        {
            (Int2 min, Int2 max) = start.Y < end.Y ? (start, end) : (end, start);
            if (yLevel < min.Y || yLevel > max.Y || min.Y == max.Y)
                return null;
            int xDif = (yLevel - min.Y) * Math.Abs(max.X - min.X) / (max.Y - min.Y);
            return min.X + Math.Sign(max.X - min.X) * xDif;
        }

        int yMin = Math.Max(Math.Min(triangle.A.Y, Math.Min(triangle.B.Y, triangle.C.Y)), 0);
        int yMax = Math.Min(Math.Max(triangle.A.Y, Math.Max(triangle.B.Y, triangle.C.Y)), Height - 1);
        for (int y = yMin; y <= yMax; y++)
        {
            int?[] xs =
            {
                Intersection(triangle.A, triangle.B, y), Intersection(triangle.A, triangle.C, y),
                Intersection(triangle.B, triangle.C, y)
            };
            int min = Width, max = -1;
            foreach (int? t in xs)
            {
                if (!t.HasValue)
                    continue;
                if (t.Value < min)
                    min = t.Value;
                if (t.Value > max)
                    max = t.Value;
            }
            DrawHorizontalLine(min, max, y, color);
        }
    }

    protected void DrawTriangleOutline(IntTriangle triangle, Pixel color)
    {
        DrawLine(triangle.AB, color);
        DrawLine(triangle.BC, color);
        DrawLine(triangle.CA, color);
    }

    protected void DrawTriangle(Int2 a, Int2 b, Int2 c, Pixel color) => DrawTriangle(new(a, b, c), color);

    protected void DrawTriangleOutline(Int2 a, Int2 b, Int2 c, Pixel color) => DrawTriangleOutline(new(a, b, c), color);

    protected void DrawTriangle(int x1, int y1, int x2, int y2, int x3, int y3, Pixel color) =>
        DrawTriangle(new(x1, y1, x2, y2, x3, y3), color);

    protected void DrawTriangleOutline(int x1, int y1, int x2, int y2, int x3, int y3, Pixel color) =>
        DrawTriangleOutline(new(x1, y1, x2, y2, x3, y3), color);

    protected void DrawCircle(IntCircle circle, Pixel color)
    {
        int xOffset = 0;
        int yOffset = circle.Radius;
        int d = 3 - 2 * circle.Radius;
        DrawPixel(color, circle.X, circle.Y - yOffset);
        DrawPixel(color, circle.X, circle.Y + yOffset);
        DrawHorizontalLine(circle.X - yOffset, circle.X + yOffset, circle.Y, color);
        while (yOffset >= xOffset)
        {
            xOffset++;
            if (d > 0)
            {
                d = d + 4 * (xOffset - yOffset) + 10;
                yOffset--;
            }
            else
                d = d + 4 * xOffset + 6;
            DrawHorizontalLine(circle.X - xOffset, circle.X + xOffset, circle.Y - yOffset, color);
            DrawHorizontalLine(circle.X - xOffset, circle.X + xOffset, circle.Y + yOffset, color);
            DrawHorizontalLine(circle.X - yOffset, circle.X + yOffset, circle.Y - xOffset, color);
            DrawHorizontalLine(circle.X - yOffset, circle.X + yOffset, circle.Y + xOffset, color);
        }
    }

    protected void DrawCircleOutline(IntCircle circle, Pixel color)
    {
        int xOffset = 0;
        int yOffset = circle.Radius;
        int d = 3 - 2 * circle.Radius;
        DrawPixel(color, circle.X, circle.Y + yOffset);
        DrawPixel(color, circle.X, circle.Y - yOffset);
        DrawPixel(color, circle.X + yOffset, circle.Y);
        DrawPixel(color, circle.X - yOffset, circle.Y);
        while (yOffset >= xOffset)
        {
            xOffset++;
            if (d > 0)
            {
                d = d + 4 * (xOffset - yOffset) + 10;
                yOffset--;
            }
            else
                d = d + 4 * xOffset + 6;
            DrawPixel(color, circle.X + xOffset, circle.Y + yOffset);
            DrawPixel(color, circle.X - xOffset, circle.Y + yOffset);
            DrawPixel(color, circle.X + xOffset, circle.Y - yOffset);
            DrawPixel(color, circle.X - xOffset, circle.Y - yOffset);
            DrawPixel(color, circle.X + yOffset, circle.Y + xOffset);
            DrawPixel(color, circle.X - yOffset, circle.Y + xOffset);
            DrawPixel(color, circle.X + yOffset, circle.Y - xOffset);
            DrawPixel(color, circle.X - yOffset, circle.Y - xOffset);
        }
    }

    protected void DrawCircle(Int2 center, int radius, Pixel color) => DrawCircle(new(center, radius), color);

    protected void DrawCircleOutline(Int2 center, int radius, Pixel color) =>
        DrawCircleOutline(new(center, radius), color);

    protected void DrawCircle(int x, int y, int radius, Pixel color) => DrawCircle(new(x, y, radius), color);

    protected void DrawCircleOutline(int x, int y, int radius, Pixel color) =>
        DrawCircleOutline(new(x, y, radius), color);

    protected void DrawRect(IntRect rect, Pixel color)
    {
        IntRect? cropped = _rect.Intersection(rect);
        if (!cropped.HasValue)
            return;
        int widthOffset = cropped.Value.Width * 3;
        int heightOffset = cropped.Value.Height * _stride;
        int indexStart = Index(cropped.Value.TopLeft);
        int indexEnd = indexStart + heightOffset;
        for (int i = indexStart; i < indexEnd; i += _stride)
        {
            int smallEnd = i + widthOffset;
            for (int j = i; j < smallEnd; j += 3)
                (_bytes[j], _bytes[j + 1], _bytes[j + 2]) = color;
        }
    }

    protected void DrawRectOutline(IntRect rect, Pixel color)
    {
        DrawHorizontalLine(rect.X, rect.Right, rect.Y, color);
        DrawHorizontalLine(rect.X, rect.Right, rect.Bottom, color);
        DrawVerticalLine(rect.Y, rect.Bottom, rect.X, color);
        DrawVerticalLine(rect.Y, rect.Bottom, rect.Right, color);
    }

    protected void DrawRect(Int2 position, Int2 size, Pixel color) => DrawRect(new(position, size), color);

    protected void DrawRectOutline(Int2 position, Int2 size, Pixel color) =>
        DrawRectOutline(new(position, size), color);

    protected void DrawRect(int x, int y, int width, int height, Pixel color) =>
        DrawRect(new(x, y, width, height), color);

    protected void DrawRectOutline(int x, int y, int width, int height, Pixel color) =>
        DrawRectOutline(new(x, y, width, height), color);

    protected void Fill(Pixel color)
    {
        for (int i = 0; i < _bytes.Length; i += 3)
            (_bytes[i], _bytes[i + 1], _bytes[i + 2]) = color;
    }

    protected void Fill(byte value) => Array.Fill(_bytes, value);

    protected void ChangeRect(IntRect rect, Func<Pixel, Pixel?> func)
    {
        IntRect? cropped = _rect.Intersection(rect);
        if (!cropped.HasValue)
            return;
        int widthOffset = cropped.Value.Width * 3;
        int heightOffset = cropped.Value.Height * _stride;
        int indexStart = Index(cropped.Value.TopLeft);
        int indexEnd = indexStart + heightOffset;
        for (int i = indexStart; i < indexEnd; i += _stride)
        {
            int smallEnd = i + widthOffset;
            for (int j = i; j < smallEnd; j += 3)
            {
                Pixel p = new(_bytes[i], _bytes[i + 1], _bytes[i + 2]);
                Pixel? result = func(p);
                if (result.HasValue)
                    (_bytes[j], _bytes[j + 1], _bytes[j + 2]) = result.Value;
            }
        }
    }

    protected void ChangeRect(Int2 position, Int2 size, Func<Pixel, Pixel?> func) =>
        ChangeRect(new(position, size), func);

    protected void ChangeRect(int x, int y, int width, int height, Func<Pixel, Pixel?> func) =>
        ChangeRect(new(x, y, width, height), func);

    /*
    protected Texture GetTexture(IntRect rect)
    {
        Pixel[,] result = new Pixel[rect.Width, rect.Height];
        IntVector offset = new();
        for (offset.X = 0; offset.X < rect.Width; offset.X++)
            for (offset.Y = 0; offset.Y < rect.Height; offset.Y++)
                result[offset.X, offset.Y] = GetPixel(rect.TopLeft + offset);
        return new(result);
    }
    */

    protected Texture GetTexture(IntRect rect)
    {
        Pixel[,] result = new Pixel[rect.Width, rect.Height];
        IntRect? cropped = _rect.Intersection(rect);
        if (!cropped.HasValue)
            return new(result);
        int widthOffset = cropped.Value.Width * 3;
        int heightOffset = cropped.Value.Height * _stride;
        int indexStart = Index(cropped.Value.TopLeft);
        int indexEnd = indexStart + heightOffset;
        int xOffsetStart = cropped.Value.X - rect.X;
        int y = cropped.Value.Y - rect.Y;
        for (int i = indexStart; i < indexEnd; i += _stride)
        {
            int smallEnd = i + widthOffset;
            int x = xOffsetStart;
            for (int j = i; j < smallEnd; j += 3)
            {
                result[x, y] = new(_bytes[j], _bytes[j + 1], _bytes[j + 2]);
                x++;
            }
            y++;
        }
        return new(result);
    }

    protected Texture GetTexture(Int2 position, Int2 size) => GetTexture(new(position, size));

    protected Texture GetTexture(int x, int y, int width, int height) => GetTexture(new(x, y, width, height));

    protected Texture GetTexture()
    {
        Pixel[,] result = new Pixel[Width, Height];
        int index = 0;
        for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
            {
                result[j, i] = new(_bytes[index], _bytes[index + 1], _bytes[index + 2]);
                index += 3;
            }
        return new(result);
    }

    /*
    protected void DrawTexture(Texture texture, IntVector position)
    {
        IntVector offset = new();
        for (offset.X = 0; offset.X < texture.Width; offset.X++)
            for (offset.Y = 0; offset.Y < texture.Height; offset.Y++)
                DrawPixel(texture[offset], position + offset);
    }
    */

    protected void DrawTexture(Texture texture, Int2 position)
    {
        IntRect? cropped = _rect.Intersection(new(position, texture.Size));
        if (!cropped.HasValue)
            return;
        int widthOffset = cropped.Value.Width * 3;
        int heightOffset = cropped.Value.Height * _stride;
        int indexStart = Index(cropped.Value.TopLeft);
        int indexEnd = indexStart + heightOffset;
        int xOffsetStart = cropped.Value.X - position.X;
        Int2 pos = new(0, cropped.Value.Y - position.Y);
        for (int i = indexStart; i < indexEnd; i += _stride)
        {
            int smallEnd = i + widthOffset;
            pos.X = xOffsetStart;
            for (int j = i; j < smallEnd; j += 3)
            {
                Pixel? result = texture[pos];
                if (result.HasValue)
                    (_bytes[j], _bytes[j + 1], _bytes[j + 2]) = result.Value;
                pos.X++;
            }
            pos.Y++;
        }
    }

    protected void DrawTexture(Texture texture, int x, int y) => DrawTexture(texture, new(x, y));

    /*
    protected void DrawTexturePart(Texture texture, IntRect rect, IntVector position)
    {
        IntVector offset = new();
        for (offset.X = 0; offset.X < rect.Width; offset.X++)
            for (offset.Y = 0; offset.Y < rect.Height; offset.Y++)
                DrawPixel(texture[rect.TopLeft + offset], position + offset);
    }
    */

    protected void DrawTexturePart(Texture texture, IntRect rect, Int2 position)
    {
        for (Int2 offset = 0; offset.X < rect.Width; offset.X++)
            for (offset.Y = 0; offset.Y < rect.Height; offset.Y++)
                DrawPixel(texture[rect.TopLeft + offset], position + offset);
        IntRect? cropped = _rect.Intersection(new(position, rect.Size));
        if (!cropped.HasValue)
            return;
        int widthOffset = cropped.Value.Width * 3;
        int heightOffset = cropped.Value.Height * _stride;
        int indexStart = Index(cropped.Value.TopLeft);
        int indexEnd = indexStart + heightOffset;
        int xOffsetStart = cropped.Value.X - position.X + rect.X;
        Int2 pos = new(0, cropped.Value.Y - position.Y + rect.Y);
        for (int i = indexStart; i < indexEnd; i += _stride)
        {
            int smallEnd = i + widthOffset;
            pos.X = xOffsetStart;
            for (int j = i; j < smallEnd; j += 3)
            {
                Pixel? result = texture[pos];
                if (result.HasValue)
                    (_bytes[j], _bytes[j + 1], _bytes[j + 2]) = result.Value;
                pos.X++;
            }
            pos.Y++;
        }
    }

    protected void DrawTexturePart(Texture texture, Int2 partStart, Int2 partSize, Int2 position) =>
        DrawTexturePart(texture, new(partStart, partSize), position);

    protected void DrawTexturePart(Texture texture, int xStart, int yStart, int width, int height, int x, int y) =>
        DrawTexturePart(texture, new(xStart, yStart, width, height), new(x, y));

    protected void BlendTexture(Texture texture, Int2 position, Func<Pixel?, Pixel, Pixel?> blend)
    {
        IntRect? cropped = _rect.Intersection(new(position, texture.Size));
        if (!cropped.HasValue)
            return;
        int widthOffset = cropped.Value.Width * 3;
        int heightOffset = cropped.Value.Height * _stride;
        int indexStart = Index(cropped.Value.TopLeft);
        int indexEnd = indexStart + heightOffset;
        int xOffsetStart = cropped.Value.X - position.X;
        Int2 pos = new(0, cropped.Value.Y - position.Y);
        for (int i = indexStart; i < indexEnd; i += _stride)
        {
            int smallEnd = i + widthOffset;
            pos.X = xOffsetStart;
            for (int j = i; j < smallEnd; j += 3)
            {
                Pixel? text = texture[pos];
                Pixel orig = new(_bytes[j], _bytes[j + 1], _bytes[j + 2]);
                Pixel? result = blend.Invoke(text, orig);
                if (result.HasValue)
                    (_bytes[j], _bytes[j + 1], _bytes[j + 2]) = result.Value;
                pos.X++;
            }
            pos.Y++;
        }
        /*
        IntVector offset = new();
        for (offset.X = 0; offset.X < texture.Width; offset.X++)
            for (offset.Y = 0; offset.Y < texture.Height; offset.Y++)
                DrawPixel(blend.Invoke(texture[offset], GetPixel(position + offset)), position + offset);
        */
    }

    protected void BlendTexture(Texture texture, int x, int y, Func<Pixel?, Pixel, Pixel?> blend) =>
        BlendTexture(texture, new(x, y), blend);

    protected void BlendTexturePart(Texture texture, IntRect rect, Int2 position, Func<Pixel?, Pixel, Pixel?> blend)
    {
        Int2 offset = new();
        for (offset.X = 0; offset.X < rect.Width; offset.X++)
            for (offset.Y = 0; offset.Y < rect.Height; offset.Y++)
                DrawPixel(texture[rect.TopLeft + offset], position + offset);
        IntRect? cropped = _rect.Intersection(new(position, rect.Size));
        if (!cropped.HasValue)
            return;
        int widthOffset = cropped.Value.Width * 3;
        int heightOffset = cropped.Value.Height * _stride;
        int indexStart = Index(cropped.Value.TopLeft);
        int indexEnd = indexStart + heightOffset;
        int xOffsetStart = cropped.Value.X - position.X + rect.X;
        Int2 pos = new(0, cropped.Value.Y - position.Y + rect.Y);
        for (int i = indexStart; i < indexEnd; i += _stride)
        {
            int smallEnd = i + widthOffset;
            pos.X = xOffsetStart;
            for (int j = i; j < smallEnd; j += 3)
            {
                Pixel? text = texture[pos];
                Pixel orig = new(_bytes[j], _bytes[j + 1], _bytes[j + 2]);
                Pixel? result = blend.Invoke(text, orig);
                if (result.HasValue)
                    (_bytes[j], _bytes[j + 1], _bytes[j + 2]) = result.Value;
                pos.X++;
            }
            pos.Y++;
        }
        /*
        IntVector offset = new();
        for (offset.X = 0; offset.X < rect.Width; offset.X++)
            for (offset.Y = 0; offset.Y < rect.Height; offset.Y++)
                DrawPixel(blend.Invoke(texture[rect.TopLeft + offset], GetPixel(position + offset)),
                    position + offset);
        */
    }

    protected void BlendTexturePart(Texture texture, Int2 partStart, Int2 partSize, Int2 position,
        Func<Pixel?, Pixel, Pixel?> blend) =>
        BlendTexturePart(texture, new(partStart, partSize), position, blend);

    protected void BlendTexturePart(Texture texture, int xStart, int yStart, int width, int height, int x, int y,
        Func<Pixel?, Pixel, Pixel?> blend) =>
        BlendTexturePart(texture, new(xStart, yStart, width, height), new(x, y), blend);

    protected void DrawCharacter(char c, Int2 position, Font font, Pixel fontColor) =>
        BlendTexturePart(font.Texture, font[c], position, Font.Blend(fontColor));

    protected void DrawCharacter(char c, int x, int y, Font font, Pixel fontColor) =>
        DrawCharacter(c, new(x, y), font, fontColor);

    protected void DrawString(string s, Int2 position, Font font, Pixel fontColor)
    {
        Int2 offset = 0;
        foreach (char c in s)
        {
            DrawCharacter(c, position + offset, font, fontColor);
            offset.X += font[c].Width;
        }
    }

    protected void DrawString(string s, int x, int y, Font font, Pixel fontColor) =>
        DrawString(s, new(x, y), font, fontColor);

    protected bool IsInside(Int2 point) => point >= 0 && point < Size;

    private int Index(int x, int y) => (Width * y + x) * 3;
    private int Index(Int2 point) => (Width * point.Y + point.X) * 3;
}
