using System.Collections;

namespace Engine;

public struct Long3 : IEnumerable<long>
{
    public long X { get; set; }
    public long Y { get; set; }
    public long Z { get; set; }

    public long this[int n]
    {
        get { return n switch { 0 => X, 1 => Y, 2 => Z, _ => throw new ArgumentOutOfRangeException() }; }
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
                case 2:
                    Z = value;
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }

    public double Length => Math.Sqrt(X * X + Y * Y + Z * Z);
    public Long3(long x, long y, long z) => (X, Y, Z) = (x, y, z);
    public static implicit operator Long3(long v) => new(v, v, v);
    public static explicit operator Long3(Bool3 v) => new(v.X ? 1 : 0, v.Y ? 1 : 0, v.Z ? 1 : 0);
    public static implicit operator Long3(Byte3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Long3(SByte3 v) => new(v.X, v.Y, v.Z);
    public static explicit operator Long3(Decimal3 v) => new((long)v.X, (long)v.Y, (long)v.Z);
    public static explicit operator Long3(Double3 v) => new((long)v.X, (long)v.Y, (long)v.Z);
    public static explicit operator Long3(Float3 v) => new((long)v.X, (long)v.Y, (long)v.Z);
    public static implicit operator Long3(Int3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Long3(UInt3 v) => new(v.X, v.Y, v.Z);
    public static explicit operator Long3(ULong3 v) => new((long)v.X, (long)v.Y, (long)v.Z);
    public static implicit operator Long3(Short3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Long3(UShort3 v) => new(v.X, v.Y, v.Z);
    public static Long3 operator +(Long3 v) => new(+v.X, +v.Y, +v.Z);
    public static Long3 operator -(Long3 v) => new(-v.X, -v.Y, -v.Z);
    public static Long3 operator ~(Long3 v) => new(~v.X, ~v.Y, ~v.Z);
    public static Long3 operator ++(Long3 v) => new(v.X + 1, v.Y + 1, v.Z + 1);
    public static Long3 operator --(Long3 v) => new(v.X + 1, v.Y + 1, v.Z + 1);

    public static Long3 operator +(Long3 left, Long3 right) =>
        new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    public static Long3 operator -(Long3 left, Long3 right) =>
        new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    public static Long3 operator *(Long3 left, Long3 right) =>
        new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

    public static Long3 operator /(Long3 left, Long3 right) =>
        new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

    public static Long3 operator %(Long3 left, Long3 right) =>
        new(left.X % right.X, left.Y % right.Y, left.Z % right.Z);

    public static Long3 operator &(Long3 left, Long3 right) =>
        new(left.X & right.X, left.Y & right.Y, left.Z & right.Z);

    public static Long3 operator |(Long3 left, Long3 right) =>
        new(left.X | right.X, left.Y | right.Y, left.Z | right.Z);

    public static Long3 operator ^(Long3 left, Long3 right) =>
        new(left.X ^ right.X, left.Y ^ right.Y, left.Z ^ right.Z);

    public static Long3 operator <<(Long3 left, Int3 right) =>
        new(left.X << right.X, left.Y << right.Y, left.Z << right.Z);

    public static Long3 operator >> (Long3 left, Int3 right) =>
        new(left.X >> right.X, left.Y >> right.Y, left.Z >> right.Z);

    public static Long3 operator >>> (Long3 left, Int3 right) =>
        new(left.X >>> right.X, left.Y >>> right.Y, left.Z >>> right.Z);

    public static bool operator ==(Long3 left, Long3 right) =>
        left.X == right.X && left.Y == right.Y && left.Z == right.Z;

    public static bool operator !=(Long3 left, Long3 right) =>
        left.X != right.X && left.Y != right.Y && left.Z != right.Z;

    public static bool operator <(Long3 left, Long3 right) => left.X < right.X && left.Y < right.Y && left.Z < right.Z;
    public static bool operator >(Long3 left, Long3 right) => left.X > right.X && left.Y > right.Y && left.Z > right.Z;

    public static bool operator <=(Long3 left, Long3 right) =>
        left.X <= right.X && left.Y <= right.Y && left.Z <= right.Z;

    public static bool operator >=(Long3 left, Long3 right) =>
        left.X >= right.X && left.Y >= right.Y && left.Z >= right.Z;

    public override bool Equals(object? obj) => obj is Long3 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<long> GetEnumerator()
    {
        yield return X;
        yield return Y;
        yield return Z;
    }

    public override string ToString() => $"long({X}, {Y}, {Z})";
    public void Deconstruct(out long x, out long y, out long z) => (x, y, z) = (X, Y, Z);
}