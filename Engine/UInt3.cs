using System.Collections;

namespace Engine;

public struct UInt3 : IEnumerable<uint>
{
    public uint X { get; set; }
    public uint Y { get; set; }
    public uint Z { get; set; }

    public uint this[int n]
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
    public UInt3(uint x, uint y, uint z) => (X, Y, Z) = (x, y, z);
    public static implicit operator UInt3(uint v) => new(v, v, v);
    public static explicit operator UInt3(Bool3 v) => new(v.X ? 1u : 0, v.Y ? 1u : 0, v.Z ? 1u : 0);
    public static implicit operator UInt3(Byte3 v) => new(v.X, v.Y, v.Z);
    public static explicit operator UInt3(SByte3 v) => new((uint)v.X, (uint)v.Y, (uint)v.Z);
    public static explicit operator UInt3(Decimal3 v) => new((uint)v.X, (uint)v.Y, (uint)v.Z);
    public static explicit operator UInt3(Double3 v) => new((uint)v.X, (uint)v.Y, (uint)v.Z);
    public static explicit operator UInt3(Float3 v) => new((uint)v.X, (uint)v.Y, (uint)v.Z);
    public static explicit operator UInt3(Int3 v) => new((uint)v.X, (uint)v.Y, (uint)v.Z);
    public static explicit operator UInt3(Long3 v) => new((uint)v.X, (uint)v.Y, (uint)v.Z);
    public static explicit operator UInt3(ULong3 v) => new((uint)v.X, (uint)v.Y, (uint)v.Z);
    public static explicit operator UInt3(Short3 v) => new((uint)v.X, (uint)v.Y, (uint)v.Z);
    public static implicit operator UInt3(UShort3 v) => new(v.X, v.Y, v.Z);
    public static UInt3 operator +(UInt3 v) => new(+v.X, +v.Y, +v.Z);
    public static Long3 operator -(UInt3 v) => new(-v.X, -v.Y, -v.Z);
    public static UInt3 operator ~(UInt3 v) => new(~v.X, ~v.Y, ~v.Z);
    public static UInt3 operator ++(UInt3 v) => new(v.X + 1, v.Y + 1, v.Z + 1);
    public static UInt3 operator --(UInt3 v) => new(v.X + 1, v.Y + 1, v.Z + 1);

    public static UInt3 operator +(UInt3 left, UInt3 right) =>
        new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    public static UInt3 operator -(UInt3 left, UInt3 right) =>
        new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    public static UInt3 operator *(UInt3 left, UInt3 right) =>
        new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

    public static UInt3 operator /(UInt3 left, UInt3 right) =>
        new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

    public static UInt3 operator %(UInt3 left, UInt3 right) =>
        new(left.X % right.X, left.Y % right.Y, left.Z % right.Z);

    public static UInt3 operator &(UInt3 left, UInt3 right) =>
        new(left.X & right.X, left.Y & right.Y, left.Z & right.Z);

    public static UInt3 operator |(UInt3 left, UInt3 right) =>
        new(left.X | right.X, left.Y | right.Y, left.Z | right.Z);

    public static UInt3 operator ^(UInt3 left, UInt3 right) =>
        new(left.X ^ right.X, left.Y ^ right.Y, left.Z ^ right.Z);

    public static UInt3 operator <<(UInt3 left, Int3 right) =>
        new(left.X << right.X, left.Y << right.Y, left.Z << right.Z);

    public static UInt3 operator >> (UInt3 left, Int3 right) =>
        new(left.X >> right.X, left.Y >> right.Y, left.Z >> right.Z);

    public static UInt3 operator >>> (UInt3 left, Int3 right) =>
        new(left.X >>> right.X, left.Y >>> right.Y, left.Z >>> right.Z);

    public static bool operator ==(UInt3 left, UInt3 right) =>
        left.X == right.X && left.Y == right.Y && left.Z == right.Z;

    public static bool operator !=(UInt3 left, UInt3 right) =>
        left.X != right.X && left.Y != right.Y && left.Z != right.Z;

    public static bool operator <(UInt3 left, UInt3 right) => left.X < right.X && left.Y < right.Y && left.Z < right.Z;
    public static bool operator >(UInt3 left, UInt3 right) => left.X > right.X && left.Y > right.Y && left.Z > right.Z;

    public static bool operator <=(UInt3 left, UInt3 right) =>
        left.X <= right.X && left.Y <= right.Y && left.Z <= right.Z;

    public static bool operator >=(UInt3 left, UInt3 right) =>
        left.X >= right.X && left.Y >= right.Y && left.Z >= right.Z;

    public override bool Equals(object? obj) => obj is UInt3 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<uint> GetEnumerator()
    {
        yield return X;
        yield return Y;
        yield return Z;
    }

    public override string ToString() => $"uint({X}, {Y}, {Z})";
    public void Deconstruct(out uint x, out uint y, out uint z) => (x, y, z) = (X, Y, Z);
}