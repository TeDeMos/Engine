// ReSharper disable StructCanBeMadeReadOnly
// ReSharper disable UnusedMember.Global

namespace Engine;

public record struct IntCircle(Int2 Center, int Radius)
{
    public int X { get => Center.X; set => Center = Center with { X = value }; }
    public int Y { get => Center.Y; set => Center = Center with { Y = value }; }
    public double Area => Math.PI * Radius * Radius;
    public double Circumference => 2 * Math.PI * Radius;

    public IntCircle(int x, int y, int radius) : this(new(x, y), radius) { }

    public void Deconstruct(out int x, out int y, out int radius)
    {
        (x, y) = Center;
        radius = Radius;
    }
}
