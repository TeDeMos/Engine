using System.Collections;

namespace Engine;

public struct Double3 : IEnumerable<double>
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public double this[int n]
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
    public Double3(double x, double y, double z) => (X, Y, Z) = (x, y, z);
    public static implicit operator Double3(double v) => new(v, v, v);
    public static explicit operator Double3(Bool3 v) => new(v.X ? 1 : 0, v.Y ? 1 : 0, v.Z ? 1 : 0);
    public static implicit operator Double3(Byte3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Double3(SByte3 v) => new(v.X, v.Y, v.Z);
    public static explicit operator Double3(Decimal3 v) => new((double)v.X, (double)v.Y, (double)v.Z);
    public static implicit operator Double3(Float3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Double3(Int3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Double3(UInt3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Double3(Long3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Double3(ULong3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Double3(Short3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Double3(UShort3 v) => new(v.X, v.Y, v.Z);
    public static Double3 operator +(Double3 v) => new(+v.X, +v.Y, +v.Z);
    public static Double3 operator -(Double3 v) => new(-v.X, -v.Y, -v.Z);
    public static Double3 operator ++(Double3 v) => new(v.X + 1, v.Y + 1, v.Z + 1);
    public static Double3 operator --(Double3 v) => new(v.X + 1, v.Y + 1, v.Z + 1);

    public static Double3 operator +(Double3 left, Double3 right) =>
        new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    public static Double3 operator -(Double3 left, Double3 right) =>
        new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    public static Double3 operator *(Double3 left, Double3 right) =>
        new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

    public static Double3 operator /(Double3 left, Double3 right) =>
        new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

    public static Double3 operator %(Double3 left, Double3 right) =>
        new(left.X % right.X, left.Y % right.Y, left.Z % right.Z);

    public static bool operator ==(Double3 left, Double3 right) =>
        left.X == right.X && left.Y == right.Y && left.Z == right.Z;

    public static bool operator !=(Double3 left, Double3 right) =>
        left.X != right.X && left.Y != right.Y && left.Z != right.Z;

    public static bool operator <(Double3 left, Double3 right) =>
        left.X < right.X && left.Y < right.Y && left.Z < right.Z;

    public static bool operator >(Double3 left, Double3 right) =>
        left.X > right.X && left.Y > right.Y && left.Z > right.Z;

    public static bool operator <=(Double3 left, Double3 right) =>
        left.X <= right.X && left.Y <= right.Y && left.Z <= right.Z;

    public static bool operator >=(Double3 left, Double3 right) =>
        left.X >= right.X && left.Y >= right.Y && left.Z >= right.Z;

    public override bool Equals(object? obj) => obj is Double3 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<double> GetEnumerator()
    {
        yield return X;
        yield return Y;
        yield return Z;
    }

    public override string ToString() => $"double({X}, {Y}, {Z})";
    public void Deconstruct(out double x, out double y, out double z) => (x, y, z) = (X, Y, Z);
}