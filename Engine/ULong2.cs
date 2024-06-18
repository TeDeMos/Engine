using System.Collections;

namespace Engine;

public struct ULong2 : IEnumerable<ulong>
{
    public ulong X { get; set; }
    public ulong Y { get; set; }

    public ulong this[int n]
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
    public ULong2(ulong x, ulong y) => (X, Y) = (x, y);
    public static implicit operator ULong2(ulong v) => new(v, v);
    public static explicit operator ULong2(Bool2 v) => new(v.X ? 1u : 0, v.Y ? 1u : 0);
    public static implicit operator ULong2(Byte2 v) => new(v.X, v.Y);
    public static explicit operator ULong2(SByte2 v) => new((ulong)v.X, (ulong)v.Y);
    public static explicit operator ULong2(Decimal2 v) => new((ulong)v.X, (ulong)v.Y);
    public static explicit operator ULong2(Double2 v) => new((ulong)v.X, (ulong)v.Y);
    public static explicit operator ULong2(Float2 v) => new((ulong)v.X, (ulong)v.Y);
    public static explicit operator ULong2(Int2 v) => new((ulong)v.X, (ulong)v.Y);
    public static implicit operator ULong2(UInt2 v) => new(v.X, v.Y);
    public static explicit operator ULong2(Long2 v) => new((ulong)v.X, (ulong)v.Y);
    public static explicit operator ULong2(Short2 v) => new((ulong)v.X, (ulong)v.Y);
    public static implicit operator ULong2(UShort2 v) => new(v.X, v.Y);
    public static ULong2 operator +(ULong2 v) => new(+v.X, +v.Y);
    public static ULong2 operator ~(ULong2 v) => new(~v.X, ~v.Y);
    public static ULong2 operator ++(ULong2 v) => new(v.X + 1, v.Y + 1);
    public static ULong2 operator --(ULong2 v) => new(v.X + 1, v.Y + 1);
    public static ULong2 operator +(ULong2 left, ULong2 right) => new(left.X + right.X, left.Y + right.Y);
    public static ULong2 operator -(ULong2 left, ULong2 right) => new(left.X - right.X, left.Y - right.Y);
    public static ULong2 operator *(ULong2 left, ULong2 right) => new(left.X * right.X, left.Y * right.Y);
    public static ULong2 operator /(ULong2 left, ULong2 right) => new(left.X / right.X, left.Y / right.Y);
    public static ULong2 operator %(ULong2 left, ULong2 right) => new(left.X % right.X, left.Y % right.Y);
    public static ULong2 operator &(ULong2 left, ULong2 right) => new(left.X & right.X, left.Y & right.Y);
    public static ULong2 operator |(ULong2 left, ULong2 right) => new(left.X | right.X, left.Y | right.Y);
    public static ULong2 operator ^(ULong2 left, ULong2 right) => new(left.X ^ right.X, left.Y ^ right.Y);
    public static ULong2 operator <<(ULong2 left, Int2 right) => new(left.X << right.X, left.Y << right.Y);
    public static ULong2 operator >> (ULong2 left, Int2 right) => new(left.X >> right.X, left.Y >> right.Y);
    public static ULong2 operator >>> (ULong2 left, Int2 right) => new(left.X >>> right.X, left.Y >>> right.Y);
    public static bool operator ==(ULong2 left, ULong2 right) => left.X == right.X && left.Y == right.Y;
    public static bool operator !=(ULong2 left, ULong2 right) => left.X != right.X && left.Y != right.Y;
    public static bool operator <(ULong2 left, ULong2 right) => left.X < right.X && left.Y < right.Y;
    public static bool operator >(ULong2 left, ULong2 right) => left.X > right.X && left.Y > right.Y;
    public static bool operator <=(ULong2 left, ULong2 right) => left.X <= right.X && left.Y <= right.Y;
    public static bool operator >=(ULong2 left, ULong2 right) => left.X >= right.X && left.Y >= right.Y;
    public override bool Equals(object? obj) => obj is ULong2 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<ulong> GetEnumerator()
    {
        yield return X;
        yield return Y;
    }

    public override string ToString() => $"ulong({X}, {Y})";
    public void Deconstruct(out ulong x, out ulong y) => (x, y) = (X, Y);
}