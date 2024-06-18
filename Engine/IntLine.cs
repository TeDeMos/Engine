// ReSharper disable StructCanBeMadeReadOnly
// ReSharper disable UnusedMember.Global
namespace Engine;

public record struct IntLine(Int2 Start, Int2 End)
{
    public IntLine(int xStart, int yStart, int xEnd, int yEnd) : this(new(xStart, yStart), new(xEnd, yEnd)) { }
    
    public Int2 Offset => End - Start;
    public double Length => Offset.Length;
    public IEnumerable<Int2> Vertices => new[] { Start, End };

    public void Deconstruct(out int xStart, out int yStart, out int xEnd, out int yEnd)
    {
        (xStart, yStart) = Start;
        (xEnd, yEnd) = End;
    }
}