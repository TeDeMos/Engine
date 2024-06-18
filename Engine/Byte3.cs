using System.Collections;

namespace Engine;

public struct Byte3 : IEnumerable<byte>
{
    public byte X { get; set; }
    public byte Y { get; set; }
    public byte Z { get; set; }

    public byte this[int n]
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
    public Byte3(byte x, byte y, byte z) => (X, Y, Z) = (x, y, z);
    public static implicit operator Byte3(byte v) => new(v, v, v);

    public static explicit operator Byte3(Bool3 v) =>
        new((byte)(v.X ? 1 : 0), (byte)(v.Y ? 1 : 0), (byte)(v.Z ? 1 : 0));

    public static explicit operator Byte3(SByte3 v) => new((byte)v.X, (byte)v.Y, (byte)v.Z);
    public static explicit operator Byte3(Decimal3 v) => new((byte)v.X, (byte)v.Y, (byte)v.Z);
    public static explicit operator Byte3(Double3 v) => new((byte)v.X, (byte)v.Y, (byte)v.Z);
    public static explicit operator Byte3(Float3 v) => new((byte)v.X, (byte)v.Y, (byte)v.Z);
    public static explicit operator Byte3(Int3 v) => new((byte)v.X, (byte)v.Y, (byte)v.Z);
    public static explicit operator Byte3(UInt3 v) => new((byte)v.X, (byte)v.Y, (byte)v.Z);
    public static explicit operator Byte3(Long3 v) => new((byte)v.X, (byte)v.Y, (byte)v.Z);
    public static explicit operator Byte3(ULong3 v) => new((byte)v.X, (byte)v.Y, (byte)v.Z);
    public static explicit operator Byte3(Short3 v) => new((byte)v.X, (byte)v.Y, (byte)v.Z);
    public static explicit operator Byte3(UShort3 v) => new((byte)v.X, (byte)v.Y, (byte)v.Z);
    public static Int3 operator +(Byte3 v) => new(+v.X, +v.Y, +v.Z);
    public static Int3 operator -(Byte3 v) => new(-v.X, -v.Y, -v.Z);
    public static Int3 operator ~(Byte3 v) => new(~v.X, ~v.Y, ~v.Z);
    public static Byte3 operator ++(Byte3 v) => new((byte)(v.X + 1), (byte)(v.Y + 1), (byte)(v.Z + 1));
    public static Byte3 operator --(Byte3 v) => new((byte)(v.X + 1), (byte)(v.Y + 1), (byte)(v.Z + 1));
    public static Int3 operator +(Byte3 left, Byte3 right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
    public static Int3 operator -(Byte3 left, Byte3 right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
    public static Int3 operator *(Byte3 left, Byte3 right) => new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
    public static Int3 operator /(Byte3 left, Byte3 right) => new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
    public static Int3 operator %(Byte3 left, Byte3 right) => new(left.X % right.X, left.Y % right.Y, left.Z % right.Z);
    public static Int3 operator &(Byte3 left, Byte3 right) => new(left.X & right.X, left.Y & right.Y, left.Z & right.Z);
    public static Int3 operator |(Byte3 left, Byte3 right) => new(left.X | right.X, left.Y | right.Y, left.Z | right.Z);
    public static Int3 operator ^(Byte3 left, Byte3 right) => new(left.X ^ right.X, left.Y ^ right.Y, left.Z ^ right.Z);

    public static Int3 operator <<(Byte3 left, Int3 right) =>
        new(left.X << right.X, left.Y << right.Y, left.Z << right.Z);

    public static Int3 operator >> (Byte3 left, Int3 right) =>
        new(left.X >> right.X, left.Y >> right.Y, left.Z >> right.Z);

    public static Int3 operator >>> (Byte3 left, Int3 right) =>
        new(left.X >>> right.X, left.Y >>> right.Y, left.Z >>> right.Z);

    public static bool operator ==(Byte3 left, Byte3 right) =>
        left.X == right.X && left.Y == right.Y && left.Z == right.Z;

    public static bool operator !=(Byte3 left, Byte3 right) =>
        left.X != right.X && left.Y != right.Y && left.Z != right.Z;

    public static bool operator <(Byte3 left, Byte3 right) => left.X < right.X && left.Y < right.Y && left.Z < right.Z;
    public static bool operator >(Byte3 left, Byte3 right) => left.X > right.X && left.Y > right.Y && left.Z > right.Z;

    public static bool operator <=(Byte3 left, Byte3 right) =>
        left.X <= right.X && left.Y <= right.Y && left.Z <= right.Z;

    public static bool operator >=(Byte3 left, Byte3 right) =>
        left.X >= right.X && left.Y >= right.Y && left.Z >= right.Z;

    public override bool Equals(object? obj) => obj is Byte3 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<byte> GetEnumerator()
    {
        yield return X;
        yield return Y;
        yield return Z;
    }

    public override string ToString() => $"byte({X}, {Y}, {Z})";
    public void Deconstruct(out byte x, out byte y, out byte z) => (x, y, z) = (X, Y, Z);
}