using System.Collections;

namespace Engine;

public struct Bool3 : IEnumerable<bool>
{
    public bool X { get; set; }
    public bool Y { get; set; }
    public bool Z { get; set; }

    public bool this[int n]
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

    public Bool3(bool x, bool y, bool z) => (X, Y, Z) = (x, y, z);
    public static implicit operator Bool3(bool v) => new(v, v, v);
    public static explicit operator Bool3(Byte3 v) => new(v.X != 0, v.Y != 0, v.Z != 0);
    public static explicit operator Bool3(SByte3 v) => new(v.X != 0, v.Y != 0, v.Z != 0);
    public static explicit operator Bool3(Decimal3 v) => new(v.X != 0, v.Y != 0, v.Z != 0);
    public static explicit operator Bool3(Double3 v) => new(v.X != 0, v.Y != 0, v.Z != 0);
    public static explicit operator Bool3(Float3 v) => new(v.X != 0, v.Y != 0, v.Z != 0);
    public static explicit operator Bool3(Int3 v) => new(v.X != 0, v.Y != 0, v.Z != 0);
    public static explicit operator Bool3(UInt3 v) => new(v.X != 0, v.Y != 0, v.Z != 0);
    public static explicit operator Bool3(Long3 v) => new(v.X != 0, v.Y != 0, v.Z != 0);
    public static explicit operator Bool3(ULong3 v) => new(v.X != 0, v.Y != 0, v.Z != 0);
    public static explicit operator Bool3(Short3 v) => new(v.X != 0, v.Y != 0, v.Z != 0);
    public static explicit operator Bool3(UShort3 v) => new(v.X != 0, v.Y != 0, v.Z != 0);
    public static Bool3 operator !(Bool3 v) => new(!v.X, !v.Y, !v.Z);

    public static Bool3 operator &(Bool3 left, Bool3 right) =>
        new(left.X & right.X, left.Y & right.Y, left.Z & right.Z);

    public static Bool3 operator |(Bool3 left, Bool3 right) =>
        new(left.X | right.X, left.Y | right.Y, left.Z | right.Z);

    public static Bool3 operator ^(Bool3 left, Bool3 right) =>
        new(left.X ^ right.X, left.Y ^ right.Y, left.Z ^ right.Z);

    public static bool operator ==(Bool3 left, Bool3 right) =>
        left.X == right.X && left.Y == right.Y && left.Z == right.Z;

    public static bool operator !=(Bool3 left, Bool3 right) =>
        left.X != right.X && left.Y != right.Y && left.Z != right.Z;

    public override bool Equals(object? obj) => obj is Bool3 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<bool> GetEnumerator()
    {
        yield return X;
        yield return Y;
        yield return Z;
    }

    public override string ToString() => $"bool({X}, {Y}, {Z})";
    public void Deconstruct(out bool x, out bool y, out bool z) => (x, y, z) = (X, Y, Z);
}