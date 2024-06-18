using System.Collections;

namespace Engine;

public struct Int2 : IEnumerable<int>
{
    public int X { get; set; }
    public int Y { get; set; }

    public int this[int n]
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
    public Int2(int x, int y) => (X, Y) = (x, y);
    public static implicit operator Int2(int v) => new(v, v);
    public static explicit operator Int2(Bool2 v) => new(v.X ? 1 : 0, v.Y ? 1 : 0);
    public static implicit operator Int2(Byte2 v) => new(v.X, v.Y);
    public static implicit operator Int2(SByte2 v) => new(v.X, v.Y);
    public static explicit operator Int2(Decimal2 v) => new((int)v.X, (int)v.Y);
    public static explicit operator Int2(Double2 v) => new((int)v.X, (int)v.Y);
    public static explicit operator Int2(Float2 v) => new((int)v.X, (int)v.Y);
    public static explicit operator Int2(UInt2 v) => new((int)v.X, (int)v.Y);
    public static explicit operator Int2(Long2 v) => new((int)v.X, (int)v.Y);
    public static explicit operator Int2(ULong2 v) => new((int)v.X, (int)v.Y);
    public static implicit operator Int2(Short2 v) => new(v.X, v.Y);
    public static implicit operator Int2(UShort2 v) => new(v.X, v.Y);
    public static Int2 operator +(Int2 v) => new(+v.X, +v.Y);
    public static Int2 operator -(Int2 v) => new(-v.X, -v.Y);
    public static Int2 operator ~(Int2 v) => new(~v.X, ~v.Y);
    public static Int2 operator ++(Int2 v) => new(v.X + 1, v.Y + 1);
    public static Int2 operator --(Int2 v) => new(v.X + 1, v.Y + 1);
    public static Int2 operator +(Int2 left, Int2 right) => new(left.X + right.X, left.Y + right.Y);
    public static Int2 operator -(Int2 left, Int2 right) => new(left.X - right.X, left.Y - right.Y);
    public static Int2 operator *(Int2 left, Int2 right) => new(left.X * right.X, left.Y * right.Y);
    public static Int2 operator /(Int2 left, Int2 right) => new(left.X / right.X, left.Y / right.Y);
    public static Int2 operator %(Int2 left, Int2 right) => new(left.X % right.X, left.Y % right.Y);
    public static Int2 operator &(Int2 left, Int2 right) => new(left.X & right.X, left.Y & right.Y);
    public static Int2 operator |(Int2 left, Int2 right) => new(left.X | right.X, left.Y | right.Y);
    public static Int2 operator ^(Int2 left, Int2 right) => new(left.X ^ right.X, left.Y ^ right.Y);
    public static Int2 operator <<(Int2 left, Int2 right) => new(left.X << right.X, left.Y << right.Y);
    public static Int2 operator >> (Int2 left, Int2 right) => new(left.X >> right.X, left.Y >> right.Y);
    public static Int2 operator >>> (Int2 left, Int2 right) => new(left.X >>> right.X, left.Y >>> right.Y);
    public static bool operator ==(Int2 left, Int2 right) => left.X == right.X && left.Y == right.Y;
    public static bool operator !=(Int2 left, Int2 right) => left.X != right.X && left.Y != right.Y;
    public static bool operator <(Int2 left, Int2 right) => left.X < right.X && left.Y < right.Y;
    public static bool operator >(Int2 left, Int2 right) => left.X > right.X && left.Y > right.Y;
    public static bool operator <=(Int2 left, Int2 right) => left.X <= right.X && left.Y <= right.Y;
    public static bool operator >=(Int2 left, Int2 right) => left.X >= right.X && left.Y >= right.Y;
    public override bool Equals(object? obj) => obj is Int2 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<int> GetEnumerator()
    {
        yield return X;
        yield return Y;
    }

    public override string ToString() => $"int({X}, {Y})";
    public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
}