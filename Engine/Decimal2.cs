using System.Collections;

namespace Engine;

public struct Decimal2 : IEnumerable<decimal>
{
    public decimal X { get; set; }
    public decimal Y { get; set; }

    public decimal this[int n]
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

    public double Length => Math.Sqrt((double)(X * X + Y * Y));
    public Decimal2(decimal x, decimal y) => (X, Y) = (x, y);
    public static implicit operator Decimal2(decimal v) => new(v, v);
    public static explicit operator Decimal2(Bool2 v) => new(v.X ? 1 : 0, v.Y ? 1 : 0);
    public static implicit operator Decimal2(Byte2 v) => new(v.X, v.Y);
    public static implicit operator Decimal2(SByte2 v) => new(v.X, v.Y);
    public static explicit operator Decimal2(Double2 v) => new((decimal)v.X, (decimal)v.Y);
    public static explicit operator Decimal2(Float2 v) => new((decimal)v.X, (decimal)v.Y);
    public static implicit operator Decimal2(Int2 v) => new(v.X, v.Y);
    public static implicit operator Decimal2(UInt2 v) => new(v.X, v.Y);
    public static implicit operator Decimal2(Long2 v) => new(v.X, v.Y);
    public static implicit operator Decimal2(ULong2 v) => new(v.X, v.Y);
    public static implicit operator Decimal2(Short2 v) => new(v.X, v.Y);
    public static implicit operator Decimal2(UShort2 v) => new(v.X, v.Y);
    public static Decimal2 operator +(Decimal2 v) => new(+v.X, +v.Y);
    public static Decimal2 operator -(Decimal2 v) => new(-v.X, -v.Y);
    public static Decimal2 operator ++(Decimal2 v) => new(v.X + 1, v.Y + 1);
    public static Decimal2 operator --(Decimal2 v) => new(v.X + 1, v.Y + 1);
    public static Decimal2 operator +(Decimal2 left, Decimal2 right) => new(left.X + right.X, left.Y + right.Y);
    public static Decimal2 operator -(Decimal2 left, Decimal2 right) => new(left.X - right.X, left.Y - right.Y);
    public static Decimal2 operator *(Decimal2 left, Decimal2 right) => new(left.X * right.X, left.Y * right.Y);
    public static Decimal2 operator /(Decimal2 left, Decimal2 right) => new(left.X / right.X, left.Y / right.Y);
    public static Decimal2 operator %(Decimal2 left, Decimal2 right) => new(left.X % right.X, left.Y % right.Y);
    public static bool operator ==(Decimal2 left, Decimal2 right) => left.X == right.X && left.Y == right.Y;
    public static bool operator !=(Decimal2 left, Decimal2 right) => left.X != right.X && left.Y != right.Y;
    public static bool operator <(Decimal2 left, Decimal2 right) => left.X < right.X && left.Y < right.Y;
    public static bool operator >(Decimal2 left, Decimal2 right) => left.X > right.X && left.Y > right.Y;
    public static bool operator <=(Decimal2 left, Decimal2 right) => left.X <= right.X && left.Y <= right.Y;
    public static bool operator >=(Decimal2 left, Decimal2 right) => left.X >= right.X && left.Y >= right.Y;
    public override bool Equals(object? obj) => obj is Decimal2 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<decimal> GetEnumerator()
    {
        yield return X;
        yield return Y;
    }

    public override string ToString() => $"decimal({X}, {Y})";
    public void Deconstruct(out decimal x, out decimal y) => (x, y) = (X, Y);
}