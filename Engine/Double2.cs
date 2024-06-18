using System.Collections;

namespace Engine;

public struct Double2 : IEnumerable<double>
{
    public double X { get; set; }
    public double Y { get; set; }

    public double this[int n]
    {
        get { return n switch { 0 => X, 1 => Y, _ => throw new ArgumentOutOfRangeException() }; }
        set
        {
            switch (n)
            {
                case 0:
                    X = value;
                    break;
                case 1:
                    Y = value;
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }

    public double Length => Math.Sqrt(X * X + Y * Y);
    public Double2(double x, double y) => (X, Y) = (x, y);
    public static implicit operator Double2(double v) => new(v, v);
    public static explicit operator Double2(Bool2 v) => new(v.X ? 1 : 0, v.Y ? 1 : 0);
    public static implicit operator Double2(Byte2 v) => new(v.X, v.Y);
    public static implicit operator Double2(SByte2 v) => new(v.X, v.Y);
    public static explicit operator Double2(Decimal2 v) => new((double)v.X, (double)v.Y);
    public static implicit operator Double2(Float2 v) => new(v.X, v.Y);
    public static implicit operator Double2(Int2 v) => new(v.X, v.Y);
    public static implicit operator Double2(UInt2 v) => new(v.X, v.Y);
    public static implicit operator Double2(Long2 v) => new(v.X, v.Y);
    public static implicit operator Double2(ULong2 v) => new(v.X, v.Y);
    public static implicit operator Double2(Short2 v) => new(v.X, v.Y);
    public static implicit operator Double2(UShort2 v) => new(v.X, v.Y);
    public static Double2 operator +(Double2 v) => new(+v.X, +v.Y);
    public static Double2 operator -(Double2 v) => new(-v.X, -v.Y);
    public static Double2 operator ++(Double2 v) => new(v.X + 1, v.Y + 1);
    public static Double2 operator --(Double2 v) => new(v.X + 1, v.Y + 1);
    public static Double2 operator +(Double2 left, Double2 right) => new(left.X + right.X, left.Y + right.Y);
    public static Double2 operator -(Double2 left, Double2 right) => new(left.X - right.X, left.Y - right.Y);
    public static Double2 operator *(Double2 left, Double2 right) => new(left.X * right.X, left.Y * right.Y);
    public static Double2 operator /(Double2 left, Double2 right) => new(left.X / right.X, left.Y / right.Y);
    public static Double2 operator %(Double2 left, Double2 right) => new(left.X % right.X, left.Y % right.Y);
    public static bool operator ==(Double2 left, Double2 right) => left.X == right.X && left.Y == right.Y;
    public static bool operator !=(Double2 left, Double2 right) => left.X != right.X && left.Y != right.Y;
    public static bool operator <(Double2 left, Double2 right) => left.X < right.X && left.Y < right.Y;
    public static bool operator >(Double2 left, Double2 right) => left.X > right.X && left.Y > right.Y;
    public static bool operator <=(Double2 left, Double2 right) => left.X <= right.X && left.Y <= right.Y;
    public static bool operator >=(Double2 left, Double2 right) => left.X >= right.X && left.Y >= right.Y;
    public override bool Equals(object? obj) => obj is Double2 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<double> GetEnumerator()
    {
        yield return X;
        yield return Y;
    }

    public override string ToString() => $"double({X}, {Y})";
    public void Deconstruct(out double x, out double y) => (x, y) = (X, Y);
}