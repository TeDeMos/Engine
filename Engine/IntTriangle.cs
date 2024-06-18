// ReSharper disable StructCanBeMadeReadOnly
// ReSharper disable UnusedMember.Global
namespace Engine;

public record struct IntTriangle(Int2 A, Int2 B, Int2 C)
{
    public IntTriangle(int x1, int y1, int x2, int y2, int x3, int y3) :
        this(new(x1, y1), new(x2, y2), new(x3, y3)) { }
    
    public IntLine AB => new(A, B);
    public IntLine BC => new(B, C);
    public IntLine CA => new(C, A);
    public IEnumerable<Int2> Vertices => new[] { A, B, C };
    public IEnumerable<IntLine> Sides => new[] { AB, BC, CA };

    public double Area => (A.X * (B.Y - C.Y) + B.X * (C.Y - A.Y) + C.X * (A.Y - B.Y)) / 2.0;
    public double Circumference => AB.Length + BC.Length + CA.Length;

    public void Deconstruct(out int x1, out int y1, out int x2, out int y2, out int x3, out int y3)
    {
        (x1, y1) = A;
        (x2, y2) = B;
        (x3, y3) = C;
    }
}