using System.Collections;

namespace Engine;

public struct SByte3 : IEnumerable<sbyte>
{
    public sbyte X { get; set; }
    public sbyte Y { get; set; }
    public sbyte Z { get; set; }

    public sbyte this[int n]
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
    public SByte3(sbyte x, sbyte y, sbyte z) => (X, Y, Z) = (x, y, z);
    public static implicit operator SByte3(sbyte v) => new(v, v, v);

    public static explicit operator SByte3(Bool3 v) =>
        new((sbyte)(v.X ? 1 : 0), (sbyte)(v.Y ? 1 : 0), (sbyte)(v.Z ? 1 : 0));

    public static explicit operator SByte3(Byte3 v) => new((sbyte)v.X, (sbyte)v.Y, (sbyte)v.Z);
    public static explicit operator SByte3(Decimal3 v) => new((sbyte)v.X, (sbyte)v.Y, (sbyte)v.Z);
    public static explicit operator SByte3(Double3 v) => new((sbyte)v.X, (sbyte)v.Y, (sbyte)v.Z);
    public static explicit operator SByte3(Float3 v) => new((sbyte)v.X, (sbyte)v.Y, (sbyte)v.Z);
    public static explicit operator SByte3(Int3 v) => new((sbyte)v.X, (sbyte)v.Y, (sbyte)v.Z);
    public static explicit operator SByte3(UInt3 v) => new((sbyte)v.X, (sbyte)v.Y, (sbyte)v.Z);
    public static explicit operator SByte3(Long3 v) => new((sbyte)v.X, (sbyte)v.Y, (sbyte)v.Z);
    public static explicit operator SByte3(ULong3 v) => new((sbyte)v.X, (sbyte)v.Y, (sbyte)v.Z);
    public static explicit operator SByte3(Short3 v) => new((sbyte)v.X, (sbyte)v.Y, (sbyte)v.Z);
    public static explicit operator SByte3(UShort3 v) => new((sbyte)v.X, (sbyte)v.Y, (sbyte)v.Z);
    public static Int3 operator +(SByte3 v) => new(+v.X, +v.Y, +v.Z);
    public static Int3 operator -(SByte3 v) => new(-v.X, -v.Y, -v.Z);
    public static Int3 operator ~(SByte3 v) => new(~v.X, ~v.Y, ~v.Z);
    public static SByte3 operator ++(SByte3 v) => new((sbyte)(v.X + 1), (sbyte)(v.Y + 1), (sbyte)(v.Z + 1));
    public static SByte3 operator --(SByte3 v) => new((sbyte)(v.X + 1), (sbyte)(v.Y + 1), (sbyte)(v.Z + 1));

    public static Int3 operator +(SByte3 left, SByte3 right) =>
        new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    public static Int3 operator -(SByte3 left, SByte3 right) =>
        new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    public static Int3 operator *(SByte3 left, SByte3 right) =>
        new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

    public static Int3 operator /(SByte3 left, SByte3 right) =>
        new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

    public static Int3 operator %(SByte3 left, SByte3 right) =>
        new(left.X % right.X, left.Y % right.Y, left.Z % right.Z);

    public static Int3 operator &(SByte3 left, SByte3 right) =>
        new(left.X & right.X, left.Y & right.Y, left.Z & right.Z);

    public static Int3 operator |(SByte3 left, SByte3 right) =>
        new(left.X | right.X, left.Y | right.Y, left.Z | right.Z);

    public static Int3 operator ^(SByte3 left, SByte3 right) =>
        new(left.X ^ right.X, left.Y ^ right.Y, left.Z ^ right.Z);

    public static Int3 operator <<(SByte3 left, Int3 right) =>
        new(left.X << right.X, left.Y << right.Y, left.Z << right.Z);

    public static Int3 operator >> (SByte3 left, Int3 right) =>
        new(left.X >> right.X, left.Y >> right.Y, left.Z >> right.Z);

    public static Int3 operator >>> (SByte3 left, Int3 right) =>
        new(left.X >>> right.X, left.Y >>> right.Y, left.Z >>> right.Z);

    public static bool operator ==(SByte3 left, SByte3 right) =>
        left.X == right.X && left.Y == right.Y && left.Z == right.Z;

    public static bool operator !=(SByte3 left, SByte3 right) =>
        left.X != right.X && left.Y != right.Y && left.Z != right.Z;

    public static bool operator <(SByte3 left, SByte3 right) =>
        left.X < right.X && left.Y < right.Y && left.Z < right.Z;

    public static bool operator >(SByte3 left, SByte3 right) =>
        left.X > right.X && left.Y > right.Y && left.Z > right.Z;

    public static bool operator <=(SByte3 left, SByte3 right) =>
        left.X <= right.X && left.Y <= right.Y && left.Z <= right.Z;

    public static bool operator >=(SByte3 left, SByte3 right) =>
        left.X >= right.X && left.Y >= right.Y && left.Z >= right.Z;

    public override bool Equals(object? obj) => obj is SByte3 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<sbyte> GetEnumerator()
    {
        yield return X;
        yield return Y;
        yield return Z;
    }

    public override string ToString() => $"sbyte({X}, {Y}, {Z})";
    public void Deconstruct(out sbyte x, out sbyte y, out sbyte z) => (x, y, z) = (X, Y, Z);
}