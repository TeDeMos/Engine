using System.Drawing;
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Engine;

public class Texture
{
    public Texture(Bitmap bitmap, Pixel? transparent = null)
    {
        Width = bitmap.Width;
        Height = bitmap.Height;
        Size = new(Width, Height);
        Pixels = new Pixel?[Width, Height];
        for (int i = 0; i < Width; i++)
            for (int j = 0; j < Height; j++)
            {
                Color c = bitmap.GetPixel(i, j);
                Pixel p = new(c.R, c.G, c.B);
                Pixels[i, j] = p == transparent ? null : p;
            }
    }

    public Texture(Pixel[,] source, Pixel? transparent = null)
    {
        Width = source.GetLength(0);
        Height = source.GetLength(1);
        Size = new(Width, Height);
        Pixels = new Pixel?[Width, Height];
        for (int i = 0; i < Width; i++)
            for (int j = 0; j < Height; j++)
                Pixels[i, j] = source[i, j] == transparent ? null : source[i, j];
    }

    public Texture(Pixel?[,] source)
    {
        Width = source.GetLength(0);
        Height = source.GetLength(1);
        Size = new(Width, Height);
        Pixels = new Pixel?[Width, Height];
        for (int i = 0; i < Width; i++)
            for (int j = 0; j < Height; j++)
                Pixels[i, j] = source[i, j];
    }

    public Pixel? this[Int2 vector] => Pixels[vector.X, vector.Y];
    public Pixel? this[int x, int y] => Pixels[x, y];

    public Bitmap ToBitmap(Pixel? transparentReplace = null)
    {
        Bitmap bitmap = new(Width, Height);
        for (int i = 0; i < Width; i++)
            for (int j = 0; j < Height; j++)
            {
                Pixel p = this[i, j] ?? transparentReplace ?? new(0, 0, 0);
                bitmap.SetPixel(i, j, Color.FromArgb(p.R, p.G, p.B));
            }
        return bitmap;
    }

    public Pixel[,] GetPixels(Pixel? transparentReplace = null)
    {
        Pixel[,] result = new Pixel[Width, Height];
        transparentReplace ??= new(0, 0, 0);
        for (int i = 0; i < Width; i++)
            for (int j = 0; j < Height; j++)
                result[i, j] = this[i, j] ?? transparentReplace.Value;
        return result;
    }

    public Pixel?[,] GetPixelsWithTransparent()
    {
        Pixel?[,] result = new Pixel?[Width, Height];
        for (int i = 0; i < Width; i++)
            for (int j = 0; j < Height; j++)
                result[i, j] = this[i, j];
        return result;
    }

    private Pixel?[,] Pixels { get; }
    public int Width { get; }
    public int Height { get; }
    public Int2 Size { get; }
}