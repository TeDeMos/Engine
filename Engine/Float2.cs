using System.Collections;

namespace Engine;

public struct Float2 : IEnumerable<float>
{
    public float X { get; set; }
    public float Y { get; set; }

    public float this[int n]
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

    public double Length => Math.Sqrt(X * X + Y * Y);
    public Float2(float x, float y) => (X, Y) = (x, y);
    public static implicit operator Float2(float v) => new(v, v);
    public static explicit operator Float2(Bool2 v) => new(v.X ? 1 : 0, v.Y ? 1 : 0);
    public static implicit operator Float2(Byte2 v) => new(v.X, v.Y);
    public static implicit operator Float2(SByte2 v) => new(v.X, v.Y);
    public static explicit operator Float2(Decimal2 v) => new((float)v.X, (float)v.Y);
    public static explicit operator Float2(Double2 v) => new((float)v.X, (float)v.Y);
    public static implicit operator Float2(Int2 v) => new(v.X, v.Y);
    public static implicit operator Float2(UInt2 v) => new(v.X, v.Y);
    public static implicit operator Float2(Long2 v) => new(v.X, v.Y);
    public static implicit operator Float2(ULong2 v) => new(v.X, v.Y);
    public static implicit operator Float2(Short2 v) => new(v.X, v.Y);
    public static implicit operator Float2(UShort2 v) => new(v.X, v.Y);
    public static Float2 operator +(Float2 v) => new(+v.X, +v.Y);
    public static Float2 operator -(Float2 v) => new(-v.X, -v.Y);
    public static Float2 operator ++(Float2 v) => new(v.X + 1, v.Y + 1);
    public static Float2 operator --(Float2 v) => new(v.X + 1, v.Y + 1);
    public static Float2 operator +(Float2 left, Float2 right) => new(left.X + right.X, left.Y + right.Y);
    public static Float2 operator -(Float2 left, Float2 right) => new(left.X - right.X, left.Y - right.Y);
    public static Float2 operator *(Float2 left, Float2 right) => new(left.X * right.X, left.Y * right.Y);
    public static Float2 operator /(Float2 left, Float2 right) => new(left.X / right.X, left.Y / right.Y);
    public static Float2 operator %(Float2 left, Float2 right) => new(left.X % right.X, left.Y % right.Y);
    public static bool operator ==(Float2 left, Float2 right) => left.X == right.X && left.Y == right.Y;
    public static bool operator !=(Float2 left, Float2 right) => left.X != right.X && left.Y != right.Y;
    public static bool operator <(Float2 left, Float2 right) => left.X < right.X && left.Y < right.Y;
    public static bool operator >(Float2 left, Float2 right) => left.X > right.X && left.Y > right.Y;
    public static bool operator <=(Float2 left, Float2 right) => left.X <= right.X && left.Y <= right.Y;
    public static bool operator >=(Float2 left, Float2 right) => left.X >= right.X && left.Y >= right.Y;
    public override bool Equals(object? obj) => obj is Float2 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<float> GetEnumerator()
    {
        yield return X;
        yield return Y;
    }

    public override string ToString() => $"float({X}, {Y})";
    public void Deconstruct(out float x, out float y) => (x, y) = (X, Y);
}