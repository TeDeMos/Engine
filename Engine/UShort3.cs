using System.Collections;

namespace Engine;

public struct UShort3 : IEnumerable<ushort>
{
    public ushort X { get; set; }
    public ushort Y { get; set; }
    public ushort Z { get; set; }

    public ushort this[int n]
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
    public UShort3(ushort x, ushort y, ushort z) => (X, Y, Z) = (x, y, z);
    public static implicit operator UShort3(ushort v) => new(v, v, v);

    public static explicit operator UShort3(Bool3 v) =>
        new((ushort)(v.X ? 1 : 0), (ushort)(v.Y ? 1 : 0), (ushort)(v.Z ? 1 : 0));

    public static implicit operator UShort3(Byte3 v) => new(v.X, v.Y, v.Z);
    public static explicit operator UShort3(SByte3 v) => new((ushort)v.X, (ushort)v.Y, (ushort)v.Z);
    public static explicit operator UShort3(Decimal3 v) => new((ushort)v.X, (ushort)v.Y, (ushort)v.Z);
    public static explicit operator UShort3(Double3 v) => new((ushort)v.X, (ushort)v.Y, (ushort)v.Z);
    public static explicit operator UShort3(Float3 v) => new((ushort)v.X, (ushort)v.Y, (ushort)v.Z);
    public static explicit operator UShort3(Int3 v) => new((ushort)v.X, (ushort)v.Y, (ushort)v.Z);
    public static explicit operator UShort3(UInt3 v) => new((ushort)v.X, (ushort)v.Y, (ushort)v.Z);
    public static explicit operator UShort3(Long3 v) => new((ushort)v.X, (ushort)v.Y, (ushort)v.Z);
    public static explicit operator UShort3(ULong3 v) => new((ushort)v.X, (ushort)v.Y, (ushort)v.Z);
    public static explicit operator UShort3(Short3 v) => new((ushort)v.X, (ushort)v.Y, (ushort)v.Z);
    public static Int3 operator +(UShort3 v) => new(+v.X, +v.Y, +v.Z);
    public static Int3 operator -(UShort3 v) => new(-v.X, -v.Y, -v.Z);
    public static Int3 operator ~(UShort3 v) => new(~v.X, ~v.Y, ~v.Z);
    public static UShort3 operator ++(UShort3 v) => new((ushort)(v.X + 1), (ushort)(v.Y + 1), (ushort)(v.Z + 1));
    public static UShort3 operator --(UShort3 v) => new((ushort)(v.X + 1), (ushort)(v.Y + 1), (ushort)(v.Z + 1));

    public static Int3 operator +(UShort3 left, UShort3 right) =>
        new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    public static Int3 operator -(UShort3 left, UShort3 right) =>
        new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    public static Int3 operator *(UShort3 left, UShort3 right) =>
        new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

    public static Int3 operator /(UShort3 left, UShort3 right) =>
        new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

    public static Int3 operator %(UShort3 left, UShort3 right) =>
        new(left.X % right.X, left.Y % right.Y, left.Z % right.Z);

    public static Int3 operator &(UShort3 left, UShort3 right) =>
        new(left.X & right.X, left.Y & right.Y, left.Z & right.Z);

    public static Int3 operator |(UShort3 left, UShort3 right) =>
        new(left.X | right.X, left.Y | right.Y, left.Z | right.Z);

    public static Int3 operator ^(UShort3 left, UShort3 right) =>
        new(left.X ^ right.X, left.Y ^ right.Y, left.Z ^ right.Z);

    public static Int3 operator <<(UShort3 left, Int3 right) =>
        new(left.X << right.X, left.Y << right.Y, left.Z << right.Z);

    public static Int3 operator >> (UShort3 left, Int3 right) =>
        new(left.X >> right.X, left.Y >> right.Y, left.Z >> right.Z);

    public static Int3 operator >>> (UShort3 left, Int3 right) =>
        new(left.X >>> right.X, left.Y >>> right.Y, left.Z >>> right.Z);

    public static bool operator ==(UShort3 left, UShort3 right) =>
        left.X == right.X && left.Y == right.Y && left.Z == right.Z;

    public static bool operator !=(UShort3 left, UShort3 right) =>
        left.X != right.X && left.Y != right.Y && left.Z != right.Z;

    public static bool operator <(UShort3 left, UShort3 right) =>
        left.X < right.X && left.Y < right.Y && left.Z < right.Z;

    public static bool operator >(UShort3 left, UShort3 right) =>
        left.X > right.X && left.Y > right.Y && left.Z > right.Z;

    public static bool operator <=(UShort3 left, UShort3 right) =>
        left.X <= right.X && left.Y <= right.Y && left.Z <= right.Z;

    public static bool operator >=(UShort3 left, UShort3 right) =>
        left.X >= right.X && left.Y >= right.Y && left.Z >= right.Z;

    public override bool Equals(object? obj) => obj is UShort3 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<ushort> GetEnumerator()
    {
        yield return X;
        yield return Y;
        yield return Z;
    }

    public override string ToString() => $"ushort({X}, {Y}, {Z})";
    public void Deconstruct(out ushort x, out ushort y, out ushort z) => (x, y, z) = (X, Y, Z);
}