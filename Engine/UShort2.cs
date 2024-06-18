using System.Collections;

namespace Engine;

public struct UShort2 : IEnumerable<ushort>
{
    public ushort X { get; set; }
    public ushort Y { get; set; }

    public ushort this[int n]
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
    public UShort2(ushort x, ushort y) => (X, Y) = (x, y);
    public static implicit operator UShort2(ushort v) => new(v, v);
    public static explicit operator UShort2(Bool2 v) => new((ushort)(v.X ? 1 : 0), (ushort)(v.Y ? 1 : 0));
    public static implicit operator UShort2(Byte2 v) => new(v.X, v.Y);
    public static explicit operator UShort2(SByte2 v) => new((ushort)v.X, (ushort)v.Y);
    public static explicit operator UShort2(Decimal2 v) => new((ushort)v.X, (ushort)v.Y);
    public static explicit operator UShort2(Double2 v) => new((ushort)v.X, (ushort)v.Y);
    public static explicit operator UShort2(Float2 v) => new((ushort)v.X, (ushort)v.Y);
    public static explicit operator UShort2(Int2 v) => new((ushort)v.X, (ushort)v.Y);
    public static explicit operator UShort2(UInt2 v) => new((ushort)v.X, (ushort)v.Y);
    public static explicit operator UShort2(Long2 v) => new((ushort)v.X, (ushort)v.Y);
    public static explicit operator UShort2(ULong2 v) => new((ushort)v.X, (ushort)v.Y);
    public static explicit operator UShort2(Short2 v) => new((ushort)v.X, (ushort)v.Y);
    public static Int2 operator +(UShort2 v) => new(+v.X, +v.Y);
    public static Int2 operator -(UShort2 v) => new(-v.X, -v.Y);
    public static Int2 operator ~(UShort2 v) => new(~v.X, ~v.Y);
    public static UShort2 operator ++(UShort2 v) => new((ushort)(v.X + 1), (ushort)(v.Y + 1));
    public static UShort2 operator --(UShort2 v) => new((ushort)(v.X + 1), (ushort)(v.Y + 1));
    public static Int2 operator +(UShort2 left, UShort2 right) => new(left.X + right.X, left.Y + right.Y);
    public static Int2 operator -(UShort2 left, UShort2 right) => new(left.X - right.X, left.Y - right.Y);
    public static Int2 operator *(UShort2 left, UShort2 right) => new(left.X * right.X, left.Y * right.Y);
    public static Int2 operator /(UShort2 left, UShort2 right) => new(left.X / right.X, left.Y / right.Y);
    public static Int2 operator %(UShort2 left, UShort2 right) => new(left.X % right.X, left.Y % right.Y);
    public static Int2 operator &(UShort2 left, UShort2 right) => new(left.X & right.X, left.Y & right.Y);
    public static Int2 operator |(UShort2 left, UShort2 right) => new(left.X | right.X, left.Y | right.Y);
    public static Int2 operator ^(UShort2 left, UShort2 right) => new(left.X ^ right.X, left.Y ^ right.Y);
    public static Int2 operator <<(UShort2 left, Int2 right) => new(left.X << right.X, left.Y << right.Y);
    public static Int2 operator >> (UShort2 left, Int2 right) => new(left.X >> right.X, left.Y >> right.Y);
    public static Int2 operator >>> (UShort2 left, Int2 right) => new(left.X >>> right.X, left.Y >>> right.Y);
    public static bool operator ==(UShort2 left, UShort2 right) => left.X == right.X && left.Y == right.Y;
    public static bool operator !=(UShort2 left, UShort2 right) => left.X != right.X && left.Y != right.Y;
    public static bool operator <(UShort2 left, UShort2 right) => left.X < right.X && left.Y < right.Y;
    public static bool operator >(UShort2 left, UShort2 right) => left.X > right.X && left.Y > right.Y;
    public static bool operator <=(UShort2 left, UShort2 right) => left.X <= right.X && left.Y <= right.Y;
    public static bool operator >=(UShort2 left, UShort2 right) => left.X >= right.X && left.Y >= right.Y;
    public override bool Equals(object? obj) => obj is UShort2 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<ushort> GetEnumerator()
    {
        yield return X;
        yield return Y;
    }

    public override string ToString() => $"ushort({X}, {Y})";
    public void Deconstruct(out ushort x, out ushort y) => (x, y) = (X, Y);
}