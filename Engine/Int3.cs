using System.Collections;

namespace Engine;

public struct Int3 : IEnumerable<int>
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public int this[int n]
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
    public Int3(int x, int y, int z) => (X, Y, Z) = (x, y, z);
    public static implicit operator Int3(int v) => new(v, v, v);
    public static explicit operator Int3(Bool3 v) => new(v.X ? 1 : 0, v.Y ? 1 : 0, v.Z ? 1 : 0);
    public static implicit operator Int3(Byte3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Int3(SByte3 v) => new(v.X, v.Y, v.Z);
    public static explicit operator Int3(Decimal3 v) => new((int)v.X, (int)v.Y, (int)v.Z);
    public static explicit operator Int3(Double3 v) => new((int)v.X, (int)v.Y, (int)v.Z);
    public static explicit operator Int3(Float3 v) => new((int)v.X, (int)v.Y, (int)v.Z);
    public static explicit operator Int3(UInt3 v) => new((int)v.X, (int)v.Y, (int)v.Z);
    public static explicit operator Int3(Long3 v) => new((int)v.X, (int)v.Y, (int)v.Z);
    public static explicit operator Int3(ULong3 v) => new((int)v.X, (int)v.Y, (int)v.Z);
    public static implicit operator Int3(Short3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Int3(UShort3 v) => new(v.X, v.Y, v.Z);
    public static Int3 operator +(Int3 v) => new(+v.X, +v.Y, +v.Z);
    public static Int3 operator -(Int3 v) => new(-v.X, -v.Y, -v.Z);
    public static Int3 operator ~(Int3 v) => new(~v.X, ~v.Y, ~v.Z);
    public static Int3 operator ++(Int3 v) => new(v.X + 1, v.Y + 1, v.Z + 1);
    public static Int3 operator --(Int3 v) => new(v.X + 1, v.Y + 1, v.Z + 1);
    public static Int3 operator +(Int3 left, Int3 right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
    public static Int3 operator -(Int3 left, Int3 right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
    public static Int3 operator *(Int3 left, Int3 right) => new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
    public static Int3 operator /(Int3 left, Int3 right) => new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
    public static Int3 operator %(Int3 left, Int3 right) => new(left.X % right.X, left.Y % right.Y, left.Z % right.Z);
    public static Int3 operator &(Int3 left, Int3 right) => new(left.X & right.X, left.Y & right.Y, left.Z & right.Z);
    public static Int3 operator |(Int3 left, Int3 right) => new(left.X | right.X, left.Y | right.Y, left.Z | right.Z);
    public static Int3 operator ^(Int3 left, Int3 right) => new(left.X ^ right.X, left.Y ^ right.Y, left.Z ^ right.Z);

    public static Int3 operator <<(Int3 left, Int3 right) =>
        new(left.X << right.X, left.Y << right.Y, left.Z << right.Z);

    public static Int3 operator >> (Int3 left, Int3 right) =>
        new(left.X >> right.X, left.Y >> right.Y, left.Z >> right.Z);

    public static Int3 operator >>> (Int3 left, Int3 right) =>
        new(left.X >>> right.X, left.Y >>> right.Y, left.Z >>> right.Z);

    public static bool operator ==(Int3 left, Int3 right) =>
        left.X == right.X && left.Y == right.Y && left.Z == right.Z;

    public static bool operator !=(Int3 left, Int3 right) =>
        left.X != right.X && left.Y != right.Y && left.Z != right.Z;

    public static bool operator <(Int3 left, Int3 right) => left.X < right.X && left.Y < right.Y && left.Z < right.Z;
    public static bool operator >(Int3 left, Int3 right) => left.X > right.X && left.Y > right.Y && left.Z > right.Z;

    public static bool operator <=(Int3 left, Int3 right) =>
        left.X <= right.X && left.Y <= right.Y && left.Z <= right.Z;

    public static bool operator >=(Int3 left, Int3 right) =>
        left.X >= right.X && left.Y >= right.Y && left.Z >= right.Z;

    public override bool Equals(object? obj) => obj is Int3 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<int> GetEnumerator()
    {
        yield return X;
        yield return Y;
        yield return Z;
    }

    public override string ToString() => $"int({X}, {Y}, {Z})";
    public void Deconstruct(out int x, out int y, out int z) => (x, y, z) = (X, Y, Z);
}