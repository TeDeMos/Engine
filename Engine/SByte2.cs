using System.Collections;

namespace Engine;

public struct SByte2 : IEnumerable<sbyte>
{
    public sbyte X { get; set; }
    public sbyte Y { get; set; }

    public sbyte this[int n]
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
    public SByte2(sbyte x, sbyte y) => (X, Y) = (x, y);
    public static implicit operator SByte2(sbyte v) => new(v, v);
    public static explicit operator SByte2(Bool2 v) => new((sbyte)(v.X ? 1 : 0), (sbyte)(v.Y ? 1 : 0));
    public static explicit operator SByte2(Byte2 v) => new((sbyte)v.X, (sbyte)v.Y);
    public static explicit operator SByte2(Decimal2 v) => new((sbyte)v.X, (sbyte)v.Y);
    public static explicit operator SByte2(Double2 v) => new((sbyte)v.X, (sbyte)v.Y);
    public static explicit operator SByte2(Float2 v) => new((sbyte)v.X, (sbyte)v.Y);
    public static explicit operator SByte2(Int2 v) => new((sbyte)v.X, (sbyte)v.Y);
    public static explicit operator SByte2(UInt2 v) => new((sbyte)v.X, (sbyte)v.Y);
    public static explicit operator SByte2(Long2 v) => new((sbyte)v.X, (sbyte)v.Y);
    public static explicit operator SByte2(ULong2 v) => new((sbyte)v.X, (sbyte)v.Y);
    public static explicit operator SByte2(Short2 v) => new((sbyte)v.X, (sbyte)v.Y);
    public static explicit operator SByte2(UShort2 v) => new((sbyte)v.X, (sbyte)v.Y);
    public static Int2 operator +(SByte2 v) => new(+v.X, +v.Y);
    public static Int2 operator -(SByte2 v) => new(-v.X, -v.Y);
    public static Int2 operator ~(SByte2 v) => new(~v.X, ~v.Y);
    public static SByte2 operator ++(SByte2 v) => new((sbyte)(v.X + 1), (sbyte)(v.Y + 1));
    public static SByte2 operator --(SByte2 v) => new((sbyte)(v.X + 1), (sbyte)(v.Y + 1));
    public static Int2 operator +(SByte2 left, SByte2 right) => new(left.X + right.X, left.Y + right.Y);
    public static Int2 operator -(SByte2 left, SByte2 right) => new(left.X - right.X, left.Y - right.Y);
    public static Int2 operator *(SByte2 left, SByte2 right) => new(left.X * right.X, left.Y * right.Y);
    public static Int2 operator /(SByte2 left, SByte2 right) => new(left.X / right.X, left.Y / right.Y);
    public static Int2 operator %(SByte2 left, SByte2 right) => new(left.X % right.X, left.Y % right.Y);
    public static Int2 operator &(SByte2 left, SByte2 right) => new(left.X & right.X, left.Y & right.Y);
    public static Int2 operator |(SByte2 left, SByte2 right) => new(left.X | right.X, left.Y | right.Y);
    public static Int2 operator ^(SByte2 left, SByte2 right) => new(left.X ^ right.X, left.Y ^ right.Y);
    public static Int2 operator <<(SByte2 left, Int2 right) => new(left.X << right.X, left.Y << right.Y);
    public static Int2 operator >> (SByte2 left, Int2 right) => new(left.X >> right.X, left.Y >> right.Y);
    public static Int2 operator >>> (SByte2 left, Int2 right) => new(left.X >>> right.X, left.Y >>> right.Y);
    public static bool operator ==(SByte2 left, SByte2 right) => left.X == right.X && left.Y == right.Y;
    public static bool operator !=(SByte2 left, SByte2 right) => left.X != right.X && left.Y != right.Y;
    public static bool operator <(SByte2 left, SByte2 right) => left.X < right.X && left.Y < right.Y;
    public static bool operator >(SByte2 left, SByte2 right) => left.X > right.X && left.Y > right.Y;
    public static bool operator <=(SByte2 left, SByte2 right) => left.X <= right.X && left.Y <= right.Y;
    public static bool operator >=(SByte2 left, SByte2 right) => left.X >= right.X && left.Y >= right.Y;
    public override bool Equals(object? obj) => obj is SByte2 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<sbyte> GetEnumerator()
    {
        yield return X;
        yield return Y;
    }

    public override string ToString() => $"sbyte({X}, {Y})";
    public void Deconstruct(out sbyte x, out sbyte y) => (x, y) = (X, Y);
}