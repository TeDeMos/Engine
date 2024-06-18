using System.Collections;

namespace Engine;

public struct Short2 : IEnumerable<short>
{
    public short X { get; set; }
    public short Y { get; set; }

    public short this[int n]
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
    public Short2(short x, short y) => (X, Y) = (x, y);
    public static implicit operator Short2(short v) => new(v, v);
    public static explicit operator Short2(Bool2 v) => new((short)(v.X ? 1 : 0), (short)(v.Y ? 1 : 0));
    public static implicit operator Short2(Byte2 v) => new(v.X, v.Y);
    public static implicit operator Short2(SByte2 v) => new(v.X, v.Y);
    public static explicit operator Short2(Decimal2 v) => new((short)v.X, (short)v.Y);
    public static explicit operator Short2(Double2 v) => new((short)v.X, (short)v.Y);
    public static explicit operator Short2(Float2 v) => new((short)v.X, (short)v.Y);
    public static explicit operator Short2(Int2 v) => new((short)v.X, (short)v.Y);
    public static explicit operator Short2(UInt2 v) => new((short)v.X, (short)v.Y);
    public static explicit operator Short2(Long2 v) => new((short)v.X, (short)v.Y);
    public static explicit operator Short2(ULong2 v) => new((short)v.X, (short)v.Y);
    public static explicit operator Short2(UShort2 v) => new((short)v.X, (short)v.Y);
    public static Int2 operator +(Short2 v) => new(+v.X, +v.Y);
    public static Int2 operator -(Short2 v) => new(-v.X, -v.Y);
    public static Int2 operator ~(Short2 v) => new(~v.X, ~v.Y);
    public static Short2 operator ++(Short2 v) => new((short)(v.X + 1), (short)(v.Y + 1));
    public static Short2 operator --(Short2 v) => new((short)(v.X + 1), (short)(v.Y + 1));
    public static Int2 operator +(Short2 left, Short2 right) => new(left.X + right.X, left.Y + right.Y);
    public static Int2 operator -(Short2 left, Short2 right) => new(left.X - right.X, left.Y - right.Y);
    public static Int2 operator *(Short2 left, Short2 right) => new(left.X * right.X, left.Y * right.Y);
    public static Int2 operator /(Short2 left, Short2 right) => new(left.X / right.X, left.Y / right.Y);
    public static Int2 operator %(Short2 left, Short2 right) => new(left.X % right.X, left.Y % right.Y);
    public static Int2 operator &(Short2 left, Short2 right) => new(left.X & right.X, left.Y & right.Y);
    public static Int2 operator |(Short2 left, Short2 right) => new(left.X | right.X, left.Y | right.Y);
    public static Int2 operator ^(Short2 left, Short2 right) => new(left.X ^ right.X, left.Y ^ right.Y);
    public static Int2 operator <<(Short2 left, Int2 right) => new(left.X << right.X, left.Y << right.Y);
    public static Int2 operator >> (Short2 left, Int2 right) => new(left.X >> right.X, left.Y >> right.Y);
    public static Int2 operator >>> (Short2 left, Int2 right) => new(left.X >>> right.X, left.Y >>> right.Y);
    public static bool operator ==(Short2 left, Short2 right) => left.X == right.X && left.Y == right.Y;
    public static bool operator !=(Short2 left, Short2 right) => left.X != right.X && left.Y != right.Y;
    public static bool operator <(Short2 left, Short2 right) => left.X < right.X && left.Y < right.Y;
    public static bool operator >(Short2 left, Short2 right) => left.X > right.X && left.Y > right.Y;
    public static bool operator <=(Short2 left, Short2 right) => left.X <= right.X && left.Y <= right.Y;
    public static bool operator >=(Short2 left, Short2 right) => left.X >= right.X && left.Y >= right.Y;
    public override bool Equals(object? obj) => obj is Short2 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<short> GetEnumerator()
    {
        yield return X;
        yield return Y;
    }

    public override string ToString() => $"short({X}, {Y})";
    public void Deconstruct(out short x, out short y) => (x, y) = (X, Y);
}