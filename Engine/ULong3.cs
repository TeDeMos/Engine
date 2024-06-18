using System.Collections;

namespace Engine;

public struct ULong3 : IEnumerable<ulong>
{
    public ulong X { get; set; }
    public ulong Y { get; set; }
    public ulong Z { get; set; }

    public ulong this[int n]
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
    public ULong3(ulong x, ulong y, ulong z) => (X, Y, Z) = (x, y, z);
    public static implicit operator ULong3(ulong v) => new(v, v, v);
    public static explicit operator ULong3(Bool3 v) => new(v.X ? 1u : 0, v.Y ? 1u : 0, v.Z ? 1u : 0);
    public static implicit operator ULong3(Byte3 v) => new(v.X, v.Y, v.Z);
    public static explicit operator ULong3(SByte3 v) => new((ulong)v.X, (ulong)v.Y, (ulong)v.Z);
    public static explicit operator ULong3(Decimal3 v) => new((ulong)v.X, (ulong)v.Y, (ulong)v.Z);
    public static explicit operator ULong3(Double3 v) => new((ulong)v.X, (ulong)v.Y, (ulong)v.Z);
    public static explicit operator ULong3(Float3 v) => new((ulong)v.X, (ulong)v.Y, (ulong)v.Z);
    public static explicit operator ULong3(Int3 v) => new((ulong)v.X, (ulong)v.Y, (ulong)v.Z);
    public static implicit operator ULong3(UInt3 v) => new(v.X, v.Y, v.Z);
    public static explicit operator ULong3(Long3 v) => new((ulong)v.X, (ulong)v.Y, (ulong)v.Z);
    public static explicit operator ULong3(Short3 v) => new((ulong)v.X, (ulong)v.Y, (ulong)v.Z);
    public static implicit operator ULong3(UShort3 v) => new(v.X, v.Y, v.Z);
    public static ULong3 operator +(ULong3 v) => new(+v.X, +v.Y, +v.Z);
    public static ULong3 operator ~(ULong3 v) => new(~v.X, ~v.Y, ~v.Z);
    public static ULong3 operator ++(ULong3 v) => new(v.X + 1, v.Y + 1, v.Z + 1);
    public static ULong3 operator --(ULong3 v) => new(v.X + 1, v.Y + 1, v.Z + 1);

    public static ULong3 operator +(ULong3 left, ULong3 right) =>
        new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    public static ULong3 operator -(ULong3 left, ULong3 right) =>
        new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    public static ULong3 operator *(ULong3 left, ULong3 right) =>
        new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

    public static ULong3 operator /(ULong3 left, ULong3 right) =>
        new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

    public static ULong3 operator %(ULong3 left, ULong3 right) =>
        new(left.X % right.X, left.Y % right.Y, left.Z % right.Z);

    public static ULong3 operator &(ULong3 left, ULong3 right) =>
        new(left.X & right.X, left.Y & right.Y, left.Z & right.Z);

    public static ULong3 operator |(ULong3 left, ULong3 right) =>
        new(left.X | right.X, left.Y | right.Y, left.Z | right.Z);

    public static ULong3 operator ^(ULong3 left, ULong3 right) =>
        new(left.X ^ right.X, left.Y ^ right.Y, left.Z ^ right.Z);

    public static ULong3 operator <<(ULong3 left, Int3 right) =>
        new(left.X << right.X, left.Y << right.Y, left.Z << right.Z);

    public static ULong3 operator >> (ULong3 left, Int3 right) =>
        new(left.X >> right.X, left.Y >> right.Y, left.Z >> right.Z);

    public static ULong3 operator >>> (ULong3 left, Int3 right) =>
        new(left.X >>> right.X, left.Y >>> right.Y, left.Z >>> right.Z);

    public static bool operator ==(ULong3 left, ULong3 right) =>
        left.X == right.X && left.Y == right.Y && left.Z == right.Z;

    public static bool operator !=(ULong3 left, ULong3 right) =>
        left.X != right.X && left.Y != right.Y && left.Z != right.Z;

    public static bool operator <(ULong3 left, ULong3 right) =>
        left.X < right.X && left.Y < right.Y && left.Z < right.Z;

    public static bool operator >(ULong3 left, ULong3 right) =>
        left.X > right.X && left.Y > right.Y && left.Z > right.Z;

    public static bool operator <=(ULong3 left, ULong3 right) =>
        left.X <= right.X && left.Y <= right.Y && left.Z <= right.Z;

    public static bool operator >=(ULong3 left, ULong3 right) =>
        left.X >= right.X && left.Y >= right.Y && left.Z >= right.Z;

    public override bool Equals(object? obj) => obj is ULong3 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<ulong> GetEnumerator()
    {
        yield return X;
        yield return Y;
        yield return Z;
    }

    public override string ToString() => $"ulong({X}, {Y}, {Z})";
    public void Deconstruct(out ulong x, out ulong y, out ulong z) => (x, y, z) = (X, Y, Z);
}