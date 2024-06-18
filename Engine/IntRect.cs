// ReSharper disable StructCanBeMadeReadOnly
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace Engine;

public record struct IntRect(int X, int Y, int Width, int Height)
{
    public IntRect(Int2 position, Int2 size) : this(position.X, position.Y, size.X, size.Y) { }

    public int Right => X + Width - 1;
    public int Bottom => Y + Height - 1;
    public Int2 TopLeft { get => new(X, Y); set => (X, Y) = value; }

    public Int2 TopRight => new(Right, Y);
    public Int2 BottomLeft => new(X, Bottom);
    public Int2 BottomRight => new(Right, Bottom);
    public IEnumerable<Int2> Vertices => new[] { TopLeft, TopRight, BottomRight, BottomLeft };
    public IntLine TopSide => new(TopLeft, TopRight);
    public IntLine RightSide => new(TopRight, BottomRight);
    public IntLine BottomSide => new(BottomLeft, BottomRight);
    public IntLine LeftSide => new(TopLeft, BottomLeft);
    public IEnumerable<IntLine> Sides => new[] { TopSide, RightSide, BottomSide, LeftSide };
    public Int2 Size { get => new(Width, Height); set => (Width, Height) = value; }

    public int Area => Width * Height;
    public int Circumference = 2 * (Width + Height);

    public void Deconstruct(out Int2 position, out Int2 size)
    {
        position = TopLeft;
        size = Size;
    }
}
