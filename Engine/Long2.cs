using System.Collections;

namespace Engine;

public struct Long2 : IEnumerable<long>
{
    public long X { get; set; }
    public long Y { get; set; }

    public long this[int n]
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
    public Long2(long x, long y) => (X, Y) = (x, y);
    public static implicit operator Long2(long v) => new(v, v);
    public static explicit operator Long2(Bool2 v) => new(v.X ? 1 : 0, v.Y ? 1 : 0);
    public static implicit operator Long2(Byte2 v) => new(v.X, v.Y);
    public static implicit operator Long2(SByte2 v) => new(v.X, v.Y);
    public static explicit operator Long2(Decimal2 v) => new((long)v.X, (long)v.Y);
    public static explicit operator Long2(Double2 v) => new((long)v.X, (long)v.Y);
    public static explicit operator Long2(Float2 v) => new((long)v.X, (long)v.Y);
    public static implicit operator Long2(Int2 v) => new(v.X, v.Y);
    public static implicit operator Long2(UInt2 v) => new(v.X, v.Y);
    public static explicit operator Long2(ULong2 v) => new((long)v.X, (long)v.Y);
    public static implicit operator Long2(Short2 v) => new(v.X, v.Y);
    public static implicit operator Long2(UShort2 v) => new(v.X, v.Y);
    public static Long2 operator +(Long2 v) => new(+v.X, +v.Y);
    public static Long2 operator -(Long2 v) => new(-v.X, -v.Y);
    public static Long2 operator ~(Long2 v) => new(~v.X, ~v.Y);
    public static Long2 operator ++(Long2 v) => new(v.X + 1, v.Y + 1);
    public static Long2 operator --(Long2 v) => new(v.X + 1, v.Y + 1);
    public static Long2 operator +(Long2 left, Long2 right) => new(left.X + right.X, left.Y + right.Y);
    public static Long2 operator -(Long2 left, Long2 right) => new(left.X - right.X, left.Y - right.Y);
    public static Long2 operator *(Long2 left, Long2 right) => new(left.X * right.X, left.Y * right.Y);
    public static Long2 operator /(Long2 left, Long2 right) => new(left.X / right.X, left.Y / right.Y);
    public static Long2 operator %(Long2 left, Long2 right) => new(left.X % right.X, left.Y % right.Y);
    public static Long2 operator &(Long2 left, Long2 right) => new(left.X & right.X, left.Y & right.Y);
    public static Long2 operator |(Long2 left, Long2 right) => new(left.X | right.X, left.Y | right.Y);
    public static Long2 operator ^(Long2 left, Long2 right) => new(left.X ^ right.X, left.Y ^ right.Y);
    public static Long2 operator <<(Long2 left, Int2 right) => new(left.X << right.X, left.Y << right.Y);
    public static Long2 operator >> (Long2 left, Int2 right) => new(left.X >> right.X, left.Y >> right.Y);
    public static Long2 operator >>> (Long2 left, Int2 right) => new(left.X >>> right.X, left.Y >>> right.Y);
    public static bool operator ==(Long2 left, Long2 right) => left.X == right.X && left.Y == right.Y;
    public static bool operator !=(Long2 left, Long2 right) => left.X != right.X && left.Y != right.Y;
    public static bool operator <(Long2 left, Long2 right) => left.X < right.X && left.Y < right.Y;
    public static bool operator >(Long2 left, Long2 right) => left.X > right.X && left.Y > right.Y;
    public static bool operator <=(Long2 left, Long2 right) => left.X <= right.X && left.Y <= right.Y;
    public static bool operator >=(Long2 left, Long2 right) => left.X >= right.X && left.Y >= right.Y;
    public override bool Equals(object? obj) => obj is Long2 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<long> GetEnumerator()
    {
        yield return X;
        yield return Y;
    }

    public override string ToString() => $"long({X}, {Y})";
    public void Deconstruct(out long x, out long y) => (x, y) = (X, Y);
}