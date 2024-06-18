using System.Collections;

namespace Engine;

public struct UInt2 : IEnumerable<uint>
{
    public uint X { get; set; }
    public uint Y { get; set; }

    public uint this[int n]
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
    public UInt2(uint x, uint y) => (X, Y) = (x, y);
    public static implicit operator UInt2(uint v) => new(v, v);
    public static explicit operator UInt2(Bool2 v) => new(v.X ? 1u : 0, v.Y ? 1u : 0);
    public static implicit operator UInt2(Byte2 v) => new(v.X, v.Y);
    public static explicit operator UInt2(SByte2 v) => new((uint)v.X, (uint)v.Y);
    public static explicit operator UInt2(Decimal2 v) => new((uint)v.X, (uint)v.Y);
    public static explicit operator UInt2(Double2 v) => new((uint)v.X, (uint)v.Y);
    public static explicit operator UInt2(Float2 v) => new((uint)v.X, (uint)v.Y);
    public static explicit operator UInt2(Int2 v) => new((uint)v.X, (uint)v.Y);
    public static explicit operator UInt2(Long2 v) => new((uint)v.X, (uint)v.Y);
    public static explicit operator UInt2(ULong2 v) => new((uint)v.X, (uint)v.Y);
    public static explicit operator UInt2(Short2 v) => new((uint)v.X, (uint)v.Y);
    public static implicit operator UInt2(UShort2 v) => new(v.X, v.Y);
    public static UInt2 operator +(UInt2 v) => new(+v.X, +v.Y);
    public static Long2 operator -(UInt2 v) => new(-v.X, -v.Y);
    public static UInt2 operator ~(UInt2 v) => new(~v.X, ~v.Y);
    public static UInt2 operator ++(UInt2 v) => new(v.X + 1, v.Y + 1);
    public static UInt2 operator --(UInt2 v) => new(v.X + 1, v.Y + 1);
    public static UInt2 operator +(UInt2 left, UInt2 right) => new(left.X + right.X, left.Y + right.Y);
    public static UInt2 operator -(UInt2 left, UInt2 right) => new(left.X - right.X, left.Y - right.Y);
    public static UInt2 operator *(UInt2 left, UInt2 right) => new(left.X * right.X, left.Y * right.Y);
    public static UInt2 operator /(UInt2 left, UInt2 right) => new(left.X / right.X, left.Y / right.Y);
    public static UInt2 operator %(UInt2 left, UInt2 right) => new(left.X % right.X, left.Y % right.Y);
    public static UInt2 operator &(UInt2 left, UInt2 right) => new(left.X & right.X, left.Y & right.Y);
    public static UInt2 operator |(UInt2 left, UInt2 right) => new(left.X | right.X, left.Y | right.Y);
    public static UInt2 operator ^(UInt2 left, UInt2 right) => new(left.X ^ right.X, left.Y ^ right.Y);
    public static UInt2 operator <<(UInt2 left, Int2 right) => new(left.X << right.X, left.Y << right.Y);
    public static UInt2 operator >> (UInt2 left, Int2 right) => new(left.X >> right.X, left.Y >> right.Y);
    public static UInt2 operator >>> (UInt2 left, Int2 right) => new(left.X >>> right.X, left.Y >>> right.Y);
    public static bool operator ==(UInt2 left, UInt2 right) => left.X == right.X && left.Y == right.Y;
    public static bool operator !=(UInt2 left, UInt2 right) => left.X != right.X && left.Y != right.Y;
    public static bool operator <(UInt2 left, UInt2 right) => left.X < right.X && left.Y < right.Y;
    public static bool operator >(UInt2 left, UInt2 right) => left.X > right.X && left.Y > right.Y;
    public static bool operator <=(UInt2 left, UInt2 right) => left.X <= right.X && left.Y <= right.Y;
    public static bool operator >=(UInt2 left, UInt2 right) => left.X >= right.X && left.Y >= right.Y;
    public override bool Equals(object? obj) => obj is UInt2 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<uint> GetEnumerator()
    {
        yield return X;
        yield return Y;
    }

    public override string ToString() => $"uint({X}, {Y})";
    public void Deconstruct(out uint x, out uint y) => (x, y) = (X, Y);
}