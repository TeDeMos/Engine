using System.Collections;

namespace Engine;

public struct Decimal3 : IEnumerable<decimal>
{
    public decimal X { get; set; }
    public decimal Y { get; set; }
    public decimal Z { get; set; }

    public decimal this[int n]
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

    public double Length => Math.Sqrt((double)(X * X + Y * Y + Z * Z));
    public Decimal3(decimal x, decimal y, decimal z) => (X, Y, Z) = (x, y, z);
    public static implicit operator Decimal3(decimal v) => new(v, v, v);
    public static explicit operator Decimal3(Bool3 v) => new(v.X ? 1 : 0, v.Y ? 1 : 0, v.Z ? 1 : 0);
    public static implicit operator Decimal3(Byte3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Decimal3(SByte3 v) => new(v.X, v.Y, v.Z);
    public static explicit operator Decimal3(Double3 v) => new((decimal)v.X, (decimal)v.Y, (decimal)v.Z);
    public static explicit operator Decimal3(Float3 v) => new((decimal)v.X, (decimal)v.Y, (decimal)v.Z);
    public static implicit operator Decimal3(Int3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Decimal3(UInt3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Decimal3(Long3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Decimal3(ULong3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Decimal3(Short3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Decimal3(UShort3 v) => new(v.X, v.Y, v.Z);
    public static Decimal3 operator +(Decimal3 v) => new(+v.X, +v.Y, +v.Z);
    public static Decimal3 operator -(Decimal3 v) => new(-v.X, -v.Y, -v.Z);
    public static Decimal3 operator ++(Decimal3 v) => new(v.X + 1, v.Y + 1, v.Z + 1);
    public static Decimal3 operator --(Decimal3 v) => new(v.X + 1, v.Y + 1, v.Z + 1);

    public static Decimal3 operator +(Decimal3 left, Decimal3 right) =>
        new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    public static Decimal3 operator -(Decimal3 left, Decimal3 right) =>
        new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    public static Decimal3 operator *(Decimal3 left, Decimal3 right) =>
        new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

    public static Decimal3 operator /(Decimal3 left, Decimal3 right) =>
        new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

    public static Decimal3 operator %(Decimal3 left, Decimal3 right) =>
        new(left.X % right.X, left.Y % right.Y, left.Z % right.Z);

    public static bool operator ==(Decimal3 left, Decimal3 right) =>
        left.X == right.X && left.Y == right.Y && left.Z == right.Z;

    public static bool operator !=(Decimal3 left, Decimal3 right) =>
        left.X != right.X && left.Y != right.Y && left.Z != right.Z;

    public static bool operator <(Decimal3 left, Decimal3 right) =>
        left.X < right.X && left.Y < right.Y && left.Z < right.Z;

    public static bool operator >(Decimal3 left, Decimal3 right) =>
        left.X > right.X && left.Y > right.Y && left.Z > right.Z;

    public static bool operator <=(Decimal3 left, Decimal3 right) =>
        left.X <= right.X && left.Y <= right.Y && left.Z <= right.Z;

    public static bool operator >=(Decimal3 left, Decimal3 right) =>
        left.X >= right.X && left.Y >= right.Y && left.Z >= right.Z;

    public override bool Equals(object? obj) => obj is Decimal3 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<decimal> GetEnumerator()
    {
        yield return X;
        yield return Y;
        yield return Z;
    }

    public override string ToString() => $"decimal({X}, {Y}, {Z})";
    public void Deconstruct(out decimal x, out decimal y, out decimal z) => (x, y, z) = (X, Y, Z);
}