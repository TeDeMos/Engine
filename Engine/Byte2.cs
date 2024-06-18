using System.Collections;

namespace Engine;

public struct Byte2 : IEnumerable<byte>
{
    public byte X { get; set; }
    public byte Y { get; set; }

    public byte this[int n]
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
    public Byte2(byte x, byte y) => (X, Y) = (x, y);
    public static implicit operator Byte2(byte v) => new(v, v);
    public static explicit operator Byte2(Bool2 v) => new((byte)(v.X ? 1 : 0), (byte)(v.Y ? 1 : 0));
    public static explicit operator Byte2(SByte2 v) => new((byte)v.X, (byte)v.Y);
    public static explicit operator Byte2(Decimal2 v) => new((byte)v.X, (byte)v.Y);
    public static explicit operator Byte2(Double2 v) => new((byte)v.X, (byte)v.Y);
    public static explicit operator Byte2(Float2 v) => new((byte)v.X, (byte)v.Y);
    public static explicit operator Byte2(Int2 v) => new((byte)v.X, (byte)v.Y);
    public static explicit operator Byte2(UInt2 v) => new((byte)v.X, (byte)v.Y);
    public static explicit operator Byte2(Long2 v) => new((byte)v.X, (byte)v.Y);
    public static explicit operator Byte2(ULong2 v) => new((byte)v.X, (byte)v.Y);
    public static explicit operator Byte2(Short2 v) => new((byte)v.X, (byte)v.Y);
    public static explicit operator Byte2(UShort2 v) => new((byte)v.X, (byte)v.Y);
    public static Int2 operator +(Byte2 v) => new(+v.X, +v.Y);
    public static Int2 operator -(Byte2 v) => new(-v.X, -v.Y);
    public static Int2 operator ~(Byte2 v) => new(~v.X, ~v.Y);
    public static Byte2 operator ++(Byte2 v) => new((byte)(v.X + 1), (byte)(v.Y + 1));
    public static Byte2 operator --(Byte2 v) => new((byte)(v.X + 1), (byte)(v.Y + 1));
    public static Int2 operator +(Byte2 left, Byte2 right) => new(left.X + right.X, left.Y + right.Y);
    public static Int2 operator -(Byte2 left, Byte2 right) => new(left.X - right.X, left.Y - right.Y);
    public static Int2 operator *(Byte2 left, Byte2 right) => new(left.X * right.X, left.Y * right.Y);
    public static Int2 operator /(Byte2 left, Byte2 right) => new(left.X / right.X, left.Y / right.Y);
    public static Int2 operator %(Byte2 left, Byte2 right) => new(left.X % right.X, left.Y % right.Y);
    public static Int2 operator &(Byte2 left, Byte2 right) => new(left.X & right.X, left.Y & right.Y);
    public static Int2 operator |(Byte2 left, Byte2 right) => new(left.X | right.X, left.Y | right.Y);
    public static Int2 operator ^(Byte2 left, Byte2 right) => new(left.X ^ right.X, left.Y ^ right.Y);
    public static Int2 operator <<(Byte2 left, Int2 right) => new(left.X << right.X, left.Y << right.Y);
    public static Int2 operator >> (Byte2 left, Int2 right) => new(left.X >> right.X, left.Y >> right.Y);
    public static Int2 operator >>> (Byte2 left, Int2 right) => new(left.X >>> right.X, left.Y >>> right.Y);
    public static bool operator ==(Byte2 left, Byte2 right) => left.X == right.X && left.Y == right.Y;
    public static bool operator !=(Byte2 left, Byte2 right) => left.X != right.X && left.Y != right.Y;
    public static bool operator <(Byte2 left, Byte2 right) => left.X < right.X && left.Y < right.Y;
    public static bool operator >(Byte2 left, Byte2 right) => left.X > right.X && left.Y > right.Y;
    public static bool operator <=(Byte2 left, Byte2 right) => left.X <= right.X && left.Y <= right.Y;
    public static bool operator >=(Byte2 left, Byte2 right) => left.X >= right.X && left.Y >= right.Y;
    public override bool Equals(object? obj) => obj is Byte2 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<byte> GetEnumerator()
    {
        yield return X;
        yield return Y;
    }

    public override string ToString() => $"byte({X}, {Y})";
    public void Deconstruct(out byte x, out byte y) => (x, y) = (X, Y);
}