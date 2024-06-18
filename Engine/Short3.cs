using System.Collections;

namespace Engine;

public struct Short3 : IEnumerable<short>
{
    public short X { get; set; }
    public short Y { get; set; }
    public short Z { get; set; }

    public short this[int n]
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
    public Short3(short x, short y, short z) => (X, Y, Z) = (x, y, z);
    public static implicit operator Short3(short v) => new(v, v, v);

    public static explicit operator Short3(Bool3 v) =>
        new((short)(v.X ? 1 : 0), (short)(v.Y ? 1 : 0), (short)(v.Z ? 1 : 0));

    public static implicit operator Short3(Byte3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Short3(SByte3 v) => new(v.X, v.Y, v.Z);
    public static explicit operator Short3(Decimal3 v) => new((short)v.X, (short)v.Y, (short)v.Z);
    public static explicit operator Short3(Double3 v) => new((short)v.X, (short)v.Y, (short)v.Z);
    public static explicit operator Short3(Float3 v) => new((short)v.X, (short)v.Y, (short)v.Z);
    public static explicit operator Short3(Int3 v) => new((short)v.X, (short)v.Y, (short)v.Z);
    public static explicit operator Short3(UInt3 v) => new((short)v.X, (short)v.Y, (short)v.Z);
    public static explicit operator Short3(Long3 v) => new((short)v.X, (short)v.Y, (short)v.Z);
    public static explicit operator Short3(ULong3 v) => new((short)v.X, (short)v.Y, (short)v.Z);
    public static explicit operator Short3(UShort3 v) => new((short)v.X, (short)v.Y, (short)v.Z);
    public static Int3 operator +(Short3 v) => new(+v.X, +v.Y, +v.Z);
    public static Int3 operator -(Short3 v) => new(-v.X, -v.Y, -v.Z);
    public static Int3 operator ~(Short3 v) => new(~v.X, ~v.Y, ~v.Z);
    public static Short3 operator ++(Short3 v) => new((short)(v.X + 1), (short)(v.Y + 1), (short)(v.Z + 1));
    public static Short3 operator --(Short3 v) => new((short)(v.X + 1), (short)(v.Y + 1), (short)(v.Z + 1));

    public static Int3 operator +(Short3 left, Short3 right) =>
        new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    public static Int3 operator -(Short3 left, Short3 right) =>
        new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    public static Int3 operator *(Short3 left, Short3 right) =>
        new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

    public static Int3 operator /(Short3 left, Short3 right) =>
        new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

    public static Int3 operator %(Short3 left, Short3 right) =>
        new(left.X % right.X, left.Y % right.Y, left.Z % right.Z);

    public static Int3 operator &(Short3 left, Short3 right) =>
        new(left.X & right.X, left.Y & right.Y, left.Z & right.Z);

    public static Int3 operator |(Short3 left, Short3 right) =>
        new(left.X | right.X, left.Y | right.Y, left.Z | right.Z);

    public static Int3 operator ^(Short3 left, Short3 right) =>
        new(left.X ^ right.X, left.Y ^ right.Y, left.Z ^ right.Z);

    public static Int3 operator <<(Short3 left, Int3 right) =>
        new(left.X << right.X, left.Y << right.Y, left.Z << right.Z);

    public static Int3 operator >> (Short3 left, Int3 right) =>
        new(left.X >> right.X, left.Y >> right.Y, left.Z >> right.Z);

    public static Int3 operator >>> (Short3 left, Int3 right) =>
        new(left.X >>> right.X, left.Y >>> right.Y, left.Z >>> right.Z);

    public static bool operator ==(Short3 left, Short3 right) =>
        left.X == right.X && left.Y == right.Y && left.Z == right.Z;

    public static bool operator !=(Short3 left, Short3 right) =>
        left.X != right.X && left.Y != right.Y && left.Z != right.Z;

    public static bool operator <(Short3 left, Short3 right) =>
        left.X < right.X && left.Y < right.Y && left.Z < right.Z;

    public static bool operator >(Short3 left, Short3 right) =>
        left.X > right.X && left.Y > right.Y && left.Z > right.Z;

    public static bool operator <=(Short3 left, Short3 right) =>
        left.X <= right.X && left.Y <= right.Y && left.Z <= right.Z;

    public static bool operator >=(Short3 left, Short3 right) =>
        left.X >= right.X && left.Y >= right.Y && left.Z >= right.Z;

    public override bool Equals(object? obj) => obj is Short3 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<short> GetEnumerator()
    {
        yield return X;
        yield return Y;
        yield return Z;
    }

    public override string ToString() => $"short({X}, {Y}, {Z})";
    public void Deconstruct(out short x, out short y, out short z) => (x, y, z) = (X, Y, Z);
}