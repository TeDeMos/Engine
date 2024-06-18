using System.Collections;

namespace Engine;

public struct Float3 : IEnumerable<float>
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public float this[int n]
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
    public Float3(float x, float y, float z) => (X, Y, Z) = (x, y, z);
    public static implicit operator Float3(float v) => new(v, v, v);
    public static explicit operator Float3(Bool3 v) => new(v.X ? 1 : 0, v.Y ? 1 : 0, v.Z ? 1 : 0);
    public static implicit operator Float3(Byte3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Float3(SByte3 v) => new(v.X, v.Y, v.Z);
    public static explicit operator Float3(Decimal3 v) => new((float)v.X, (float)v.Y, (float)v.Z);
    public static explicit operator Float3(Double3 v) => new((float)v.X, (float)v.Y, (float)v.Z);
    public static implicit operator Float3(Int3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Float3(UInt3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Float3(Long3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Float3(ULong3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Float3(Short3 v) => new(v.X, v.Y, v.Z);
    public static implicit operator Float3(UShort3 v) => new(v.X, v.Y, v.Z);
    public static Float3 operator +(Float3 v) => new(+v.X, +v.Y, +v.Z);
    public static Float3 operator -(Float3 v) => new(-v.X, -v.Y, -v.Z);
    public static Float3 operator ++(Float3 v) => new(v.X + 1, v.Y + 1, v.Z + 1);
    public static Float3 operator --(Float3 v) => new(v.X + 1, v.Y + 1, v.Z + 1);

    public static Float3 operator +(Float3 left, Float3 right) =>
        new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    public static Float3 operator -(Float3 left, Float3 right) =>
        new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    public static Float3 operator *(Float3 left, Float3 right) =>
        new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

    public static Float3 operator /(Float3 left, Float3 right) =>
        new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

    public static Float3 operator %(Float3 left, Float3 right) =>
        new(left.X % right.X, left.Y % right.Y, left.Z % right.Z);

    public static bool operator ==(Float3 left, Float3 right) =>
        left.X == right.X && left.Y == right.Y && left.Z == right.Z;

    public static bool operator !=(Float3 left, Float3 right) =>
        left.X != right.X && left.Y != right.Y && left.Z != right.Z;

    public static bool operator <(Float3 left, Float3 right) =>
        left.X < right.X && left.Y < right.Y && left.Z < right.Z;

    public static bool operator >(Float3 left, Float3 right) =>
        left.X > right.X && left.Y > right.Y && left.Z > right.Z;

    public static bool operator <=(Float3 left, Float3 right) =>
        left.X <= right.X && left.Y <= right.Y && left.Z <= right.Z;

    public static bool operator >=(Float3 left, Float3 right) =>
        left.X >= right.X && left.Y >= right.Y && left.Z >= right.Z;

    public override bool Equals(object? obj) => obj is Float3 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<float> GetEnumerator()
    {
        yield return X;
        yield return Y;
        yield return Z;
    }

    public override string ToString() => $"float({X}, {Y}, {Z})";
    public void Deconstruct(out float x, out float y, out float z) => (x, y, z) = (X, Y, Z);
}