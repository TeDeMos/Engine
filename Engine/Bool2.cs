namespace Engine;

using System.Collections;

public struct Bool2 : IEnumerable<bool>
{
    public bool X { get; set; }
    public bool Y { get; set; }

    public bool this[int n]
    {
        get { return n switch { 0 => X, 1 => Y, _ => throw new ArgumentOutOfRangeException() }; }
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
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }

    public Bool2(bool x, bool y) => (X, Y) = (x, y);
    public static implicit operator Bool2(bool v) => new(v, v);
    public static explicit operator Bool2(Byte2 v) => new(v.X != 0, v.Y != 0);
    public static explicit operator Bool2(SByte2 v) => new(v.X != 0, v.Y != 0);
    public static explicit operator Bool2(Decimal2 v) => new(v.X != 0, v.Y != 0);
    public static explicit operator Bool2(Double2 v) => new(v.X != 0, v.Y != 0);
    public static explicit operator Bool2(Float2 v) => new(v.X != 0, v.Y != 0);
    public static explicit operator Bool2(Int2 v) => new(v.X != 0, v.Y != 0);
    public static explicit operator Bool2(UInt2 v) => new(v.X != 0, v.Y != 0);
    public static explicit operator Bool2(Long2 v) => new(v.X != 0, v.Y != 0);
    public static explicit operator Bool2(ULong2 v) => new(v.X != 0, v.Y != 0);
    public static explicit operator Bool2(Short2 v) => new(v.X != 0, v.Y != 0);
    public static explicit operator Bool2(UShort2 v) => new(v.X != 0, v.Y != 0);
    public static Bool2 operator !(Bool2 v) => new(!v.X, !v.Y);
    public static Bool2 operator &(Bool2 left, Bool2 right) => new(left.X & right.X, left.Y & right.Y);
    public static Bool2 operator |(Bool2 left, Bool2 right) => new(left.X | right.X, left.Y | right.Y);
    public static Bool2 operator ^(Bool2 left, Bool2 right) => new(left.X ^ right.X, left.Y ^ right.Y);
    public static bool operator ==(Bool2 left, Bool2 right) => left.X == right.X && left.Y == right.Y;
    public static bool operator !=(Bool2 left, Bool2 right) => left.X != right.X && left.Y != right.Y;
    public override bool Equals(object? obj) => obj is Bool2 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<bool> GetEnumerator()
    {
        yield return X;
        yield return Y;
    }

    public override string ToString() => $"bool({X}, {Y})";
    public void Deconstruct(out bool x, out bool y) => (x, y) = (X, Y);
}
