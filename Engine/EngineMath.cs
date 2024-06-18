// ReSharper disable InconsistentNaming
namespace Engine;

public static class EngineMath
{
    public static Short2 Abs(Short2 value) => new(Math.Abs(value.X), Math.Abs(value.Y));
    public static Int2 Abs(Int2 value) => new(Math.Abs(value.X), Math.Abs(value.Y));
    public static Long2 Abs(Long2 value) => new(Math.Abs(value.X), Math.Abs(value.Y));
    public static SByte2 Abs(SByte2 value) => new(Math.Abs(value.X), Math.Abs(value.Y));
    public static Decimal2 Abs(Decimal2 value) => new(Math.Abs(value.X), Math.Abs(value.Y));
    public static Double2 Abs(Double2 value) => new(Math.Abs(value.X), Math.Abs(value.Y));
    public static Float2 Abs(Float2 value) => new(Math.Abs(value.X), Math.Abs(value.Y));
    public static Double2 Acos(Double2 d) => new(Math.Acos(d.X), Math.Acos(d.Y));
    public static Double2 Acosh(Double2 d) => new(Math.Acosh(d.X), Math.Acosh(d.Y));
    public static Double2 Asin(Double2 d) => new(Math.Asin(d.X), Math.Asin(d.Y));
    public static Double2 Asinh(Double2 d) => new(Math.Asinh(d.X), Math.Asinh(d.Y));
    public static Double2 Atan(Double2 d) => new(Math.Atan(d.X), Math.Atan(d.Y));
    public static Double2 Atanh(Double2 d) => new(Math.Atanh(d.X), Math.Atanh(d.Y));
    public static Double2 BitDecrement(Double2 x) => new(Math.BitDecrement(x.X), Math.BitDecrement(x.Y));
    public static Double2 BitIncrement(Double2 x) => new(Math.BitIncrement(x.X), Math.BitIncrement(x.Y));
    public static Double2 Cbrt(Double2 d) => new(Math.Cbrt(d.X), Math.Cbrt(d.Y));
    public static Double2 Ceiling(Double2 a) => new(Math.Ceiling(a.X), Math.Ceiling(a.Y));
    public static Decimal2 Ceiling(Decimal2 d) => new(Math.Ceiling(d.X), Math.Ceiling(d.Y));
    public static Double2 Cos(Double2 d) => new(Math.Cos(d.X), Math.Cos(d.Y));
    public static Double2 Cosh(Double2 value) => new(Math.Cosh(value.X), Math.Cosh(value.Y));
    public static Double2 Exp(Double2 d) => new(Math.Exp(d.X), Math.Exp(d.Y));
    public static Double2 Floor(Double2 d) => new(Math.Floor(d.X), Math.Floor(d.Y));
    public static Decimal2 Floor(Decimal2 d) => new(Math.Floor(d.X), Math.Floor(d.Y));
    public static Int2 ILogB(Double2 x) => new(Math.ILogB(x.X), Math.ILogB(x.Y));
    public static Double2 Log(Double2 d) => new(Math.Log(d.X), Math.Log(d.Y));
    public static Double2 Log10(Double2 d) => new(Math.Log10(d.X), Math.Log10(d.Y));
    public static Double2 Log2(Double2 x) => new(Math.Log2(x.X), Math.Log2(x.Y));

    public static Double2 ReciprocalEstimate(Double2 d) =>
        new(Math.ReciprocalEstimate(d.X), Math.ReciprocalEstimate(d.Y));

    public static Double2 ReciprocalSqrtEstimate(Double2 d) =>
        new(Math.ReciprocalSqrtEstimate(d.X), Math.ReciprocalSqrtEstimate(d.Y));

    public static Decimal2 Round(Decimal2 d) => new(Math.Round(d.X), Math.Round(d.Y));
    public static Double2 Round(Double2 a) => new(Math.Round(a.X), Math.Round(a.Y));
    public static Int2 Sign(Decimal2 value) => new(Math.Sign(value.X), Math.Sign(value.Y));
    public static Int2 Sign(Double2 value) => new(Math.Sign(value.X), Math.Sign(value.Y));
    public static Int2 Sign(Short2 value) => new(Math.Sign(value.X), Math.Sign(value.Y));
    public static Int2 Sign(Int2 value) => new(Math.Sign(value.X), Math.Sign(value.Y));
    public static Int2 Sign(Long2 value) => new(Math.Sign(value.X), Math.Sign(value.Y));
    public static Int2 Sign(SByte2 value) => new(Math.Sign(value.X), Math.Sign(value.Y));
    public static Int2 Sign(Float2 value) => new(Math.Sign(value.X), Math.Sign(value.Y));
    public static Double2 Sin(Double2 a) => new(Math.Sin(a.X), Math.Sin(a.Y));
    public static Double2 Sinh(Double2 value) => new(Math.Sinh(value.X), Math.Sinh(value.Y));
    public static Double2 Sqrt(Double2 d) => new(Math.Sqrt(d.X), Math.Sqrt(d.Y));
    public static Double2 Tan(Double2 a) => new(Math.Tan(a.X), Math.Tan(a.Y));
    public static Double2 Tanh(Double2 value) => new(Math.Tanh(value.X), Math.Tanh(value.Y));
    public static Decimal2 Truncate(Decimal2 d) => new(Math.Truncate(d.X), Math.Truncate(d.Y));
    public static Double2 Truncate(Double2 d) => new(Math.Truncate(d.X), Math.Truncate(d.Y));

    public static (Double2 Sin, Double2 Cos) SinCos(Double2 v)
    {
        (double Sin, double Cos) x = Math.SinCos(v.X);
        (double Sin, double Cos) y = Math.SinCos(v.Y);
        return (new(x.Sin, y.Sin), new(x.Cos, y.Cos));
    }

    public static Double2 Atan2(Double2 y, Double2 x) => new(Math.Atan2(y.X, x.X), Math.Atan2(y.Y, x.Y));
    public static Long2 BigMul(Int2 a, Int2 b) => new(Math.BigMul(a.X, b.X), Math.BigMul(a.Y, b.Y));
    public static Double2 CopySign(Double2 x, Double2 y) => new(Math.CopySign(x.X, y.X), Math.CopySign(x.Y, y.Y));

    public static Double2 IEEERemainder(Double2 x, Double2 y) =>
        new(Math.IEEERemainder(x.X, y.X), Math.IEEERemainder(x.Y, y.Y));

    public static Double2 Log(Double2 a, Double2 newBase) => new(Math.Log(a.X, newBase.X), Math.Log(a.Y, newBase.Y));
    public static Byte2 Max(Byte2 val1, Byte2 val2) => new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y));
    public static Decimal2 Max(Decimal2 val1, Decimal2 val2) => new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y));
    public static Double2 Max(Double2 val1, Double2 val2) => new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y));
    public static Short2 Max(Short2 val1, Short2 val2) => new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y));
    public static Int2 Max(Int2 val1, Int2 val2) => new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y));
    public static Long2 Max(Long2 val1, Long2 val2) => new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y));
    public static SByte2 Max(SByte2 val1, SByte2 val2) => new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y));
    public static Float2 Max(Float2 val1, Float2 val2) => new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y));
    public static UShort2 Max(UShort2 val1, UShort2 val2) => new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y));
    public static UInt2 Max(UInt2 val1, UInt2 val2) => new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y));
    public static ULong2 Max(ULong2 val1, ULong2 val2) => new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y));

    public static Double2 MaxMagnitude(Double2 x, Double2 y) =>
        new(Math.MaxMagnitude(x.X, y.X), Math.MaxMagnitude(x.Y, y.Y));

    public static Byte2 Min(Byte2 val1, Byte2 val2) => new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y));
    public static Decimal2 Min(Decimal2 val1, Decimal2 val2) => new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y));
    public static Double2 Min(Double2 val1, Double2 val2) => new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y));
    public static Short2 Min(Short2 val1, Short2 val2) => new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y));
    public static Int2 Min(Int2 val1, Int2 val2) => new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y));
    public static Long2 Min(Long2 val1, Long2 val2) => new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y));
    public static SByte2 Min(SByte2 val1, SByte2 val2) => new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y));
    public static Float2 Min(Float2 val1, Float2 val2) => new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y));
    public static UShort2 Min(UShort2 val1, UShort2 val2) => new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y));
    public static UInt2 Min(UInt2 val1, UInt2 val2) => new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y));
    public static ULong2 Min(ULong2 val1, ULong2 val2) => new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y));

    public static Double2 MinMagnitude(Double2 x, Double2 y) =>
        new(Math.MinMagnitude(x.X, y.X), Math.MinMagnitude(x.Y, y.Y));

    public static Double2 Pow(Double2 x, Double2 y) => new(Math.Pow(x.X, y.X), Math.Pow(x.Y, y.Y));

    public static Decimal2 Round(Decimal2 d, Int2 decimals) =>
        new(Math.Round(d.X, decimals.X), Math.Round(d.Y, decimals.Y));

    public static Decimal2 Round(Decimal2 d, MidpointRounding mode) =>
        new(Math.Round(d.X, mode), Math.Round(d.Y, mode));

    public static Double2 Round(Double2 value, Int2 digits) =>
        new(Math.Round(value.X, digits.X), Math.Round(value.Y, digits.Y));

    public static Double2 Round(Double2 value, MidpointRounding mode) =>
        new(Math.Round(value.X, mode), Math.Round(value.Y, mode));

    public static Double2 ScaleB(Double2 x, Int2 n) => new(Math.ScaleB(x.X, n.X), Math.ScaleB(x.Y, n.Y));

    public static (SByte2 Quotient, SByte2 Remainder) DivRem(SByte2 left, SByte2 right)
    {
        (sbyte Quotient, sbyte Remainder) x = Math.DivRem(left.X, right.X);
        (sbyte Quotient, sbyte Remainder) y = Math.DivRem(left.Y, right.Y);
        return (new(x.Quotient, y.Quotient), new(x.Remainder, y.Remainder));
    }

    public static (Byte2 Quotient, Byte2 Remainder) DivRem(Byte2 left, Byte2 right)
    {
        (byte Quotient, byte Remainder) x = Math.DivRem(left.X, right.X);
        (byte Quotient, byte Remainder) y = Math.DivRem(left.Y, right.Y);
        return (new(x.Quotient, y.Quotient), new(x.Remainder, y.Remainder));
    }

    public static (UShort2 Quotient, UShort2 Remainder) DivRem(UShort2 left, UShort2 right)
    {
        (ushort Quotient, ushort Remainder) x = Math.DivRem(left.X, right.X);
        (ushort Quotient, ushort Remainder) y = Math.DivRem(left.Y, right.Y);
        return (new(x.Quotient, y.Quotient), new(x.Remainder, y.Remainder));
    }

    public static (Short2 Quotient, Short2 Remainder) DivRem(Short2 left, Short2 right)
    {
        (short Quotient, short Remainder) x = Math.DivRem(left.X, right.X);
        (short Quotient, short Remainder) y = Math.DivRem(left.Y, right.Y);
        return (new(x.Quotient, y.Quotient), new(x.Remainder, y.Remainder));
    }

    public static (UInt2 Quotient, UInt2 Remainder) DivRem(UInt2 left, UInt2 right)
    {
        (uint Quotient, uint Remainder) x = Math.DivRem(left.X, right.X);
        (uint Quotient, uint Remainder) y = Math.DivRem(left.Y, right.Y);
        return (new(x.Quotient, y.Quotient), new(x.Remainder, y.Remainder));
    }

    public static (Int2 Quotient, Int2 Remainder) DivRem(Int2 left, Int2 right)
    {
        (int Quotient, int Remainder) x = Math.DivRem(left.X, right.X);
        (int Quotient, int Remainder) y = Math.DivRem(left.Y, right.Y);
        return (new(x.Quotient, y.Quotient), new(x.Remainder, y.Remainder));
    }

    public static (ULong2 Quotient, ULong2 Remainder) DivRem(ULong2 left, ULong2 right)
    {
        (ulong Quotient, ulong Remainder) x = Math.DivRem(left.X, right.X);
        (ulong Quotient, ulong Remainder) y = Math.DivRem(left.Y, right.Y);
        return (new(x.Quotient, y.Quotient), new(x.Remainder, y.Remainder));
    }

    public static (Long2 Quotient, Long2 Remainder) DivRem(Long2 left, Long2 right)
    {
        (long Quotient, long Remainder) x = Math.DivRem(left.X, right.X);
        (long Quotient, long Remainder) y = Math.DivRem(left.Y, right.Y);
        return (new(x.Quotient, y.Quotient), new(x.Remainder, y.Remainder));
    }

    public static Byte2 Clamp(Byte2 value, Byte2 min, Byte2 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y));

    public static Decimal2 Clamp(Decimal2 value, Decimal2 min, Decimal2 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y));

    public static Double2 Clamp(Double2 value, Double2 min, Double2 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y));

    public static UShort2 Clamp(UShort2 value, UShort2 min, UShort2 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y));

    public static UInt2 Clamp(UInt2 value, UInt2 min, UInt2 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y));

    public static ULong2 Clamp(ULong2 value, ULong2 min, ULong2 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y));

    public static SByte2 Clamp(SByte2 value, SByte2 min, SByte2 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y));

    public static Float2 Clamp(Float2 value, Float2 min, Float2 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y));

    public static Short2 Clamp(Short2 value, Short2 min, Short2 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y));

    public static Int2 Clamp(Int2 value, Int2 min, Int2 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y));

    public static Long2 Clamp(Long2 value, Long2 min, Long2 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y));

    public static Double2 FusedMultiplyAdd(Double2 x, Double2 y, Double2 z) =>
        new(Math.FusedMultiplyAdd(x.X, y.X, z.X), Math.FusedMultiplyAdd(x.Y, y.Y, z.Y));

    public static Decimal2 Round(Decimal2 d, Int2 decimals, MidpointRounding mode) =>
        new(Math.Round(d.X, decimals.X, mode), Math.Round(d.Y, decimals.Y, mode));

    public static Double2 Round(Double2 value, Int2 digits, MidpointRounding mode) =>
        new(Math.Round(value.X, digits.X, mode), Math.Round(value.Y, digits.Y, mode));

    public static Long2 BigMul(Long2 a, Long2 b, out Long2 low)
    {
        long x = Math.BigMul(a.X, b.X, out long xOut);
        long y = Math.BigMul(a.Y, b.Y, out long yOut);
        low = new(xOut, yOut);
        return new(x, y);
    }

    public static ULong2 BigMul(ULong2 a, ULong2 b, out ULong2 low)
    {
        ulong x = Math.BigMul(a.X, b.X, out ulong xOut);
        ulong y = Math.BigMul(a.Y, b.Y, out ulong yOut);
        low = new(xOut, yOut);
        return new(x, y);
    }

    public static Int2 DivRem(Int2 a, Int2 b, out Int2 result)
    {
        int x = Math.DivRem(a.X, b.X, out int xOut);
        int y = Math.DivRem(a.Y, b.Y, out int yOut);
        result = new(xOut, yOut);
        return new(x, y);
    }

    public static Long2 DivRem(Long2 a, Long2 b, out Long2 result)
    {
        long x = Math.DivRem(a.X, b.X, out long xOut);
        long y = Math.DivRem(a.Y, b.Y, out long yOut);
        result = new(xOut, yOut);
        return new(x, y);
    }

    public static Bool2 ToBool2(this IEnumerable<bool> enumerable)
    {
        using IEnumerator<bool> enumerator = enumerable.GetEnumerator();
        Bool2 result = new();
        for (int i = 0; i < 2; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static Byte2 ToByte2(this IEnumerable<byte> enumerable)
    {
        using IEnumerator<byte> enumerator = enumerable.GetEnumerator();
        Byte2 result = new();
        for (int i = 0; i < 2; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static SByte2 ToSByte2(this IEnumerable<sbyte> enumerable)
    {
        using IEnumerator<sbyte> enumerator = enumerable.GetEnumerator();
        SByte2 result = new();
        for (int i = 0; i < 2; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static Short2 ToShort2(this IEnumerable<short> enumerable)
    {
        using IEnumerator<short> enumerator = enumerable.GetEnumerator();
        Short2 result = new();
        for (int i = 0; i < 2; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static UShort2 ToUShort2(this IEnumerable<ushort> enumerable)
    {
        using IEnumerator<ushort> enumerator = enumerable.GetEnumerator();
        UShort2 result = new();
        for (int i = 0; i < 2; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static Int2 ToInt2(this IEnumerable<int> enumerable)
    {
        using IEnumerator<int> enumerator = enumerable.GetEnumerator();
        Int2 result = new();
        for (int i = 0; i < 2; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static UInt2 ToUInt2(this IEnumerable<uint> enumerable)
    {
        using IEnumerator<uint> enumerator = enumerable.GetEnumerator();
        UInt2 result = new();
        for (int i = 0; i < 2; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static Long2 ToLong2(this IEnumerable<long> enumerable)
    {
        using IEnumerator<long> enumerator = enumerable.GetEnumerator();
        Long2 result = new();
        for (int i = 0; i < 2; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static ULong2 ToULong2(this IEnumerable<ulong> enumerable)
    {
        using IEnumerator<ulong> enumerator = enumerable.GetEnumerator();
        ULong2 result = new();
        for (int i = 0; i < 2; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static Float2 ToFloat2(this IEnumerable<float> enumerable)
    {
        using IEnumerator<float> enumerator = enumerable.GetEnumerator();
        Float2 result = new();
        for (int i = 0; i < 2; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static Double2 ToDouble2(this IEnumerable<double> enumerable)
    {
        using IEnumerator<double> enumerator = enumerable.GetEnumerator();
        Double2 result = new();
        for (int i = 0; i < 2; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static Decimal2 ToDecimal2(this IEnumerable<decimal> enumerable)
    {
        using IEnumerator<decimal> enumerator = enumerable.GetEnumerator();
        Decimal2 result = new();
        for (int i = 0; i < 2; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static Short3 Abs(Short3 value) => new(Math.Abs(value.X), Math.Abs(value.Y), Math.Abs(value.Z));
    public static Int3 Abs(Int3 value) => new(Math.Abs(value.X), Math.Abs(value.Y), Math.Abs(value.Z));
    public static Long3 Abs(Long3 value) => new(Math.Abs(value.X), Math.Abs(value.Y), Math.Abs(value.Z));
    public static SByte3 Abs(SByte3 value) => new(Math.Abs(value.X), Math.Abs(value.Y), Math.Abs(value.Z));
    public static Decimal3 Abs(Decimal3 value) => new(Math.Abs(value.X), Math.Abs(value.Y), Math.Abs(value.Z));
    public static Double3 Abs(Double3 value) => new(Math.Abs(value.X), Math.Abs(value.Y), Math.Abs(value.Z));
    public static Float3 Abs(Float3 value) => new(Math.Abs(value.X), Math.Abs(value.Y), Math.Abs(value.Z));
    public static Double3 Acos(Double3 d) => new(Math.Acos(d.X), Math.Acos(d.Y), Math.Acos(d.Z));
    public static Double3 Acosh(Double3 d) => new(Math.Acosh(d.X), Math.Acosh(d.Y), Math.Acosh(d.Z));
    public static Double3 Asin(Double3 d) => new(Math.Asin(d.X), Math.Asin(d.Y), Math.Asin(d.Z));
    public static Double3 Asinh(Double3 d) => new(Math.Asinh(d.X), Math.Asinh(d.Y), Math.Asinh(d.Z));
    public static Double3 Atan(Double3 d) => new(Math.Atan(d.X), Math.Atan(d.Y), Math.Atan(d.Z));
    public static Double3 Atanh(Double3 d) => new(Math.Atanh(d.X), Math.Atanh(d.Y), Math.Atanh(d.Z));

    public static Double3 BitDecrement(Double3 x) =>
        new(Math.BitDecrement(x.X), Math.BitDecrement(x.Y), Math.BitDecrement(x.Z));

    public static Double3 BitIncrement(Double3 x) =>
        new(Math.BitIncrement(x.X), Math.BitIncrement(x.Y), Math.BitIncrement(x.Z));

    public static Double3 Cbrt(Double3 d) => new(Math.Cbrt(d.X), Math.Cbrt(d.Y), Math.Cbrt(d.Z));
    public static Double3 Ceiling(Double3 a) => new(Math.Ceiling(a.X), Math.Ceiling(a.Y), Math.Ceiling(a.Z));
    public static Decimal3 Ceiling(Decimal3 d) => new(Math.Ceiling(d.X), Math.Ceiling(d.Y), Math.Ceiling(d.Z));
    public static Double3 Cos(Double3 d) => new(Math.Cos(d.X), Math.Cos(d.Y), Math.Cos(d.Z));
    public static Double3 Cosh(Double3 value) => new(Math.Cosh(value.X), Math.Cosh(value.Y), Math.Cosh(value.Z));
    public static Double3 Exp(Double3 d) => new(Math.Exp(d.X), Math.Exp(d.Y), Math.Exp(d.Z));
    public static Double3 Floor(Double3 d) => new(Math.Floor(d.X), Math.Floor(d.Y), Math.Floor(d.Z));
    public static Decimal3 Floor(Decimal3 d) => new(Math.Floor(d.X), Math.Floor(d.Y), Math.Floor(d.Z));
    public static Int3 ILogB(Double3 x) => new(Math.ILogB(x.X), Math.ILogB(x.Y), Math.ILogB(x.Z));
    public static Double3 Log(Double3 d) => new(Math.Log(d.X), Math.Log(d.Y), Math.Log(d.Z));
    public static Double3 Log10(Double3 d) => new(Math.Log10(d.X), Math.Log10(d.Y), Math.Log10(d.Z));
    public static Double3 Log2(Double3 x) => new(Math.Log2(x.X), Math.Log2(x.Y), Math.Log2(x.Z));

    public static Double3 ReciprocalEstimate(Double3 d) =>
        new(Math.ReciprocalEstimate(d.X), Math.ReciprocalEstimate(d.Y), Math.ReciprocalEstimate(d.Z));

    public static Double3 ReciprocalSqrtEstimate(Double3 d) =>
        new(Math.ReciprocalSqrtEstimate(d.X), Math.ReciprocalSqrtEstimate(d.Y), Math.ReciprocalSqrtEstimate(d.Z));

    public static Decimal3 Round(Decimal3 d) => new(Math.Round(d.X), Math.Round(d.Y), Math.Round(d.Z));
    public static Double3 Round(Double3 a) => new(Math.Round(a.X), Math.Round(a.Y), Math.Round(a.Z));
    public static Int3 Sign(Decimal3 value) => new(Math.Sign(value.X), Math.Sign(value.Y), Math.Sign(value.Z));
    public static Int3 Sign(Double3 value) => new(Math.Sign(value.X), Math.Sign(value.Y), Math.Sign(value.Z));
    public static Int3 Sign(Short3 value) => new(Math.Sign(value.X), Math.Sign(value.Y), Math.Sign(value.Z));
    public static Int3 Sign(Int3 value) => new(Math.Sign(value.X), Math.Sign(value.Y), Math.Sign(value.Z));
    public static Int3 Sign(Long3 value) => new(Math.Sign(value.X), Math.Sign(value.Y), Math.Sign(value.Z));
    public static Int3 Sign(SByte3 value) => new(Math.Sign(value.X), Math.Sign(value.Y), Math.Sign(value.Z));
    public static Int3 Sign(Float3 value) => new(Math.Sign(value.X), Math.Sign(value.Y), Math.Sign(value.Z));
    public static Double3 Sin(Double3 a) => new(Math.Sin(a.X), Math.Sin(a.Y), Math.Sin(a.Z));
    public static Double3 Sinh(Double3 value) => new(Math.Sinh(value.X), Math.Sinh(value.Y), Math.Sinh(value.Z));
    public static Double3 Sqrt(Double3 d) => new(Math.Sqrt(d.X), Math.Sqrt(d.Y), Math.Sqrt(d.Z));
    public static Double3 Tan(Double3 a) => new(Math.Tan(a.X), Math.Tan(a.Y), Math.Tan(a.Z));
    public static Double3 Tanh(Double3 value) => new(Math.Tanh(value.X), Math.Tanh(value.Y), Math.Tanh(value.Z));
    public static Decimal3 Truncate(Decimal3 d) => new(Math.Truncate(d.X), Math.Truncate(d.Y), Math.Truncate(d.Z));
    public static Double3 Truncate(Double3 d) => new(Math.Truncate(d.X), Math.Truncate(d.Y), Math.Truncate(d.Z));

    public static (Double3 Sin, Double3 Cos) SinCos(Double3 v)
    {
        (double Sin, double Cos) x = Math.SinCos(v.X);
        (double Sin, double Cos) y = Math.SinCos(v.Y);
        (double Sin, double Cos) z = Math.SinCos(v.Z);
        return (new(x.Sin, y.Sin, z.Sin), new(x.Cos, y.Cos, z.Cos));
    }

    public static Double3 Atan2(Double3 y, Double3 x) =>
        new(Math.Atan2(y.X, x.X), Math.Atan2(y.Y, x.Y), Math.Atan2(y.Z, x.Z));

    public static Long3 BigMul(Int3 a, Int3 b) =>
        new(Math.BigMul(a.X, b.X), Math.BigMul(a.Y, b.Y), Math.BigMul(a.Z, b.Z));

    public static Double3 CopySign(Double3 x, Double3 y) =>
        new(Math.CopySign(x.X, y.X), Math.CopySign(x.Y, y.Y), Math.CopySign(x.Z, y.Z));

    public static Double3 IEEERemainder(Double3 x, Double3 y) =>
        new(Math.IEEERemainder(x.X, y.X), Math.IEEERemainder(x.Y, y.Y), Math.IEEERemainder(x.Z, y.Z));

    public static Double3 Log(Double3 a, Double3 newBase) =>
        new(Math.Log(a.X, newBase.X), Math.Log(a.Y, newBase.Y), Math.Log(a.Z, newBase.Z));

    public static Byte3 Max(Byte3 val1, Byte3 val2) =>
        new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y), Math.Max(val1.Z, val2.Z));

    public static Decimal3 Max(Decimal3 val1, Decimal3 val2) =>
        new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y), Math.Max(val1.Z, val2.Z));

    public static Double3 Max(Double3 val1, Double3 val2) =>
        new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y), Math.Max(val1.Z, val2.Z));

    public static Short3 Max(Short3 val1, Short3 val2) =>
        new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y), Math.Max(val1.Z, val2.Z));

    public static Int3 Max(Int3 val1, Int3 val2) =>
        new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y), Math.Max(val1.Z, val2.Z));

    public static Long3 Max(Long3 val1, Long3 val2) =>
        new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y), Math.Max(val1.Z, val2.Z));

    public static SByte3 Max(SByte3 val1, SByte3 val2) =>
        new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y), Math.Max(val1.Z, val2.Z));

    public static Float3 Max(Float3 val1, Float3 val2) =>
        new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y), Math.Max(val1.Z, val2.Z));

    public static UShort3 Max(UShort3 val1, UShort3 val2) =>
        new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y), Math.Max(val1.Z, val2.Z));

    public static UInt3 Max(UInt3 val1, UInt3 val2) =>
        new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y), Math.Max(val1.Z, val2.Z));

    public static ULong3 Max(ULong3 val1, ULong3 val2) =>
        new(Math.Max(val1.X, val2.X), Math.Max(val1.Y, val2.Y), Math.Max(val1.Z, val2.Z));

    public static Double3 MaxMagnitude(Double3 x, Double3 y) =>
        new(Math.MaxMagnitude(x.X, y.X), Math.MaxMagnitude(x.Y, y.Y), Math.MaxMagnitude(x.Z, y.Z));

    public static Byte3 Min(Byte3 val1, Byte3 val2) =>
        new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y), Math.Min(val1.Z, val2.Z));

    public static Decimal3 Min(Decimal3 val1, Decimal3 val2) =>
        new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y), Math.Min(val1.Z, val2.Z));

    public static Double3 Min(Double3 val1, Double3 val2) =>
        new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y), Math.Min(val1.Z, val2.Z));

    public static Short3 Min(Short3 val1, Short3 val2) =>
        new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y), Math.Min(val1.Z, val2.Z));

    public static Int3 Min(Int3 val1, Int3 val2) =>
        new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y), Math.Min(val1.Z, val2.Z));

    public static Long3 Min(Long3 val1, Long3 val2) =>
        new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y), Math.Min(val1.Z, val2.Z));

    public static SByte3 Min(SByte3 val1, SByte3 val2) =>
        new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y), Math.Min(val1.Z, val2.Z));

    public static Float3 Min(Float3 val1, Float3 val2) =>
        new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y), Math.Min(val1.Z, val2.Z));

    public static UShort3 Min(UShort3 val1, UShort3 val2) =>
        new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y), Math.Min(val1.Z, val2.Z));

    public static UInt3 Min(UInt3 val1, UInt3 val2) =>
        new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y), Math.Min(val1.Z, val2.Z));

    public static ULong3 Min(ULong3 val1, ULong3 val2) =>
        new(Math.Min(val1.X, val2.X), Math.Min(val1.Y, val2.Y), Math.Min(val1.Z, val2.Z));

    public static Double3 MinMagnitude(Double3 x, Double3 y) =>
        new(Math.MinMagnitude(x.X, y.X), Math.MinMagnitude(x.Y, y.Y), Math.MinMagnitude(x.Z, y.Z));

    public static Double3 Pow(Double3 x, Double3 y) => new(Math.Pow(x.X, y.X), Math.Pow(x.Y, y.Y), Math.Pow(x.Z, y.Z));

    public static Decimal3 Round(Decimal3 d, Int3 decimals) =>
        new(Math.Round(d.X, decimals.X), Math.Round(d.Y, decimals.Y), Math.Round(d.Z, decimals.Z));

    public static Decimal3 Round(Decimal3 d, MidpointRounding mode) =>
        new(Math.Round(d.X, mode), Math.Round(d.Y, mode), Math.Round(d.Z, mode));

    public static Double3 Round(Double3 value, Int3 digits) =>
        new(Math.Round(value.X, digits.X), Math.Round(value.Y, digits.Y), Math.Round(value.Z, digits.Z));

    public static Double3 Round(Double3 value, MidpointRounding mode) =>
        new(Math.Round(value.X, mode), Math.Round(value.Y, mode), Math.Round(value.Z, mode));

    public static Double3 ScaleB(Double3 x, Int3 n) =>
        new(Math.ScaleB(x.X, n.X), Math.ScaleB(x.Y, n.Y), Math.ScaleB(x.Z, n.Z));

    public static (SByte3 Quotient, SByte3 Remainder) DivRem(SByte3 left, SByte3 right)
    {
        (sbyte Quotient, sbyte Remainder) x = Math.DivRem(left.X, right.X);
        (sbyte Quotient, sbyte Remainder) y = Math.DivRem(left.Y, right.Y);
        (sbyte Quotient, sbyte Remainder) z = Math.DivRem(left.Z, right.Z);
        return (new(x.Quotient, y.Quotient, z.Quotient), new(x.Remainder, y.Remainder, z.Remainder));
    }

    public static (Byte3 Quotient, Byte3 Remainder) DivRem(Byte3 left, Byte3 right)
    {
        (byte Quotient, byte Remainder) x = Math.DivRem(left.X, right.X);
        (byte Quotient, byte Remainder) y = Math.DivRem(left.Y, right.Y);
        (byte Quotient, byte Remainder) z = Math.DivRem(left.Z, right.Z);
        return (new(x.Quotient, y.Quotient, z.Quotient), new(x.Remainder, y.Remainder, z.Remainder));
    }

    public static (UShort3 Quotient, UShort3 Remainder) DivRem(UShort3 left, UShort3 right)
    {
        (ushort Quotient, ushort Remainder) x = Math.DivRem(left.X, right.X);
        (ushort Quotient, ushort Remainder) y = Math.DivRem(left.Y, right.Y);
        (ushort Quotient, ushort Remainder) z = Math.DivRem(left.Z, right.Z);
        return (new(x.Quotient, y.Quotient, z.Quotient), new(x.Remainder, y.Remainder, z.Remainder));
    }

    public static (Short3 Quotient, Short3 Remainder) DivRem(Short3 left, Short3 right)
    {
        (short Quotient, short Remainder) x = Math.DivRem(left.X, right.X);
        (short Quotient, short Remainder) y = Math.DivRem(left.Y, right.Y);
        (short Quotient, short Remainder) z = Math.DivRem(left.Z, right.Z);
        return (new(x.Quotient, y.Quotient, z.Quotient), new(x.Remainder, y.Remainder, z.Remainder));
    }

    public static (UInt3 Quotient, UInt3 Remainder) DivRem(UInt3 left, UInt3 right)
    {
        (uint Quotient, uint Remainder) x = Math.DivRem(left.X, right.X);
        (uint Quotient, uint Remainder) y = Math.DivRem(left.Y, right.Y);
        (uint Quotient, uint Remainder) z = Math.DivRem(left.Z, right.Z);
        return (new(x.Quotient, y.Quotient, z.Quotient), new(x.Remainder, y.Remainder, z.Remainder));
    }

    public static (Int3 Quotient, Int3 Remainder) DivRem(Int3 left, Int3 right)
    {
        (int Quotient, int Remainder) x = Math.DivRem(left.X, right.X);
        (int Quotient, int Remainder) y = Math.DivRem(left.Y, right.Y);
        (int Quotient, int Remainder) z = Math.DivRem(left.Z, right.Z);
        return (new(x.Quotient, y.Quotient, z.Quotient), new(x.Remainder, y.Remainder, z.Remainder));
    }

    public static (ULong3 Quotient, ULong3 Remainder) DivRem(ULong3 left, ULong3 right)
    {
        (ulong Quotient, ulong Remainder) x = Math.DivRem(left.X, right.X);
        (ulong Quotient, ulong Remainder) y = Math.DivRem(left.Y, right.Y);
        (ulong Quotient, ulong Remainder) z = Math.DivRem(left.Z, right.Z);
        return (new(x.Quotient, y.Quotient, z.Quotient), new(x.Remainder, y.Remainder, z.Remainder));
    }

    public static (Long3 Quotient, Long3 Remainder) DivRem(Long3 left, Long3 right)
    {
        (long Quotient, long Remainder) x = Math.DivRem(left.X, right.X);
        (long Quotient, long Remainder) y = Math.DivRem(left.Y, right.Y);
        (long Quotient, long Remainder) z = Math.DivRem(left.Z, right.Z);
        return (new(x.Quotient, y.Quotient, z.Quotient), new(x.Remainder, y.Remainder, z.Remainder));
    }

    public static Byte3 Clamp(Byte3 value, Byte3 min, Byte3 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y), Math.Clamp(value.Z, min.Z, max.Z));

    public static Decimal3 Clamp(Decimal3 value, Decimal3 min, Decimal3 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y), Math.Clamp(value.Z, min.Z, max.Z));

    public static Double3 Clamp(Double3 value, Double3 min, Double3 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y), Math.Clamp(value.Z, min.Z, max.Z));

    public static UShort3 Clamp(UShort3 value, UShort3 min, UShort3 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y), Math.Clamp(value.Z, min.Z, max.Z));

    public static UInt3 Clamp(UInt3 value, UInt3 min, UInt3 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y), Math.Clamp(value.Z, min.Z, max.Z));

    public static ULong3 Clamp(ULong3 value, ULong3 min, ULong3 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y), Math.Clamp(value.Z, min.Z, max.Z));

    public static SByte3 Clamp(SByte3 value, SByte3 min, SByte3 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y), Math.Clamp(value.Z, min.Z, max.Z));

    public static Float3 Clamp(Float3 value, Float3 min, Float3 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y), Math.Clamp(value.Z, min.Z, max.Z));

    public static Short3 Clamp(Short3 value, Short3 min, Short3 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y), Math.Clamp(value.Z, min.Z, max.Z));

    public static Int3 Clamp(Int3 value, Int3 min, Int3 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y), Math.Clamp(value.Z, min.Z, max.Z));

    public static Long3 Clamp(Long3 value, Long3 min, Long3 max) =>
        new(Math.Clamp(value.X, min.X, max.X), Math.Clamp(value.Y, min.Y, max.Y), Math.Clamp(value.Z, min.Z, max.Z));

    public static Double3 FusedMultiplyAdd(Double3 x, Double3 y, Double3 z) =>
        new(Math.FusedMultiplyAdd(x.X, y.X, z.X), Math.FusedMultiplyAdd(x.Y, y.Y, z.Y),
            Math.FusedMultiplyAdd(x.Z, y.Z, z.Z));

    public static Decimal3 Round(Decimal3 d, Int3 decimals, MidpointRounding mode) =>
        new(Math.Round(d.X, decimals.X, mode), Math.Round(d.Y, decimals.Y, mode), Math.Round(d.Z, decimals.Z, mode));

    public static Double3 Round(Double3 value, Int3 digits, MidpointRounding mode) =>
        new(Math.Round(value.X, digits.X, mode), Math.Round(value.Y, digits.Y, mode),
            Math.Round(value.Z, digits.Z, mode));

    public static Long3 BigMul(Long3 a, Long3 b, out Long3 low)
    {
        long x = Math.BigMul(a.X, b.X, out long xOut);
        long y = Math.BigMul(a.Y, b.Y, out long yOut);
        long z = Math.BigMul(a.Z, b.Z, out long zOut);
        low = new(xOut, yOut, zOut);
        return new(x, y, z);
    }

    public static ULong3 BigMul(ULong3 a, ULong3 b, out ULong3 low)
    {
        ulong x = Math.BigMul(a.X, b.X, out ulong xOut);
        ulong y = Math.BigMul(a.Y, b.Y, out ulong yOut);
        ulong z = Math.BigMul(a.Z, b.Z, out ulong zOut);
        low = new(xOut, yOut, zOut);
        return new(x, y, z);
    }

    public static Int3 DivRem(Int3 a, Int3 b, out Int3 result)
    {
        int x = Math.DivRem(a.X, b.X, out int xOut);
        int y = Math.DivRem(a.Y, b.Y, out int yOut);
        int z = Math.DivRem(a.Z, b.Z, out int zOut);
        result = new(xOut, yOut, zOut);
        return new(x, y, z);
    }

    public static Long3 DivRem(Long3 a, Long3 b, out Long3 result)
    {
        long x = Math.DivRem(a.X, b.X, out long xOut);
        long y = Math.DivRem(a.Y, b.Y, out long yOut);
        long z = Math.DivRem(a.Z, b.Z, out long zOut);
        result = new(xOut, yOut, zOut);
        return new(x, y, z);
    }

    public static Bool3 ToBool3(this IEnumerable<bool> enumerable)
    {
        using IEnumerator<bool> enumerator = enumerable.GetEnumerator();
        Bool3 result = new();
        for (int i = 0; i < 3; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static Byte3 ToByte3(this IEnumerable<byte> enumerable)
    {
        using IEnumerator<byte> enumerator = enumerable.GetEnumerator();
        Byte3 result = new();
        for (int i = 0; i < 3; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static SByte3 ToSByte3(this IEnumerable<sbyte> enumerable)
    {
        using IEnumerator<sbyte> enumerator = enumerable.GetEnumerator();
        SByte3 result = new();
        for (int i = 0; i < 3; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static Short3 ToShort3(this IEnumerable<short> enumerable)
    {
        using IEnumerator<short> enumerator = enumerable.GetEnumerator();
        Short3 result = new();
        for (int i = 0; i < 3; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static UShort3 ToUShort3(this IEnumerable<ushort> enumerable)
    {
        using IEnumerator<ushort> enumerator = enumerable.GetEnumerator();
        UShort3 result = new();
        for (int i = 0; i < 3; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static Int3 ToInt3(this IEnumerable<int> enumerable)
    {
        using IEnumerator<int> enumerator = enumerable.GetEnumerator();
        Int3 result = new();
        for (int i = 0; i < 3; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static UInt3 ToUInt3(this IEnumerable<uint> enumerable)
    {
        using IEnumerator<uint> enumerator = enumerable.GetEnumerator();
        UInt3 result = new();
        for (int i = 0; i < 3; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static Long3 ToLong3(this IEnumerable<long> enumerable)
    {
        using IEnumerator<long> enumerator = enumerable.GetEnumerator();
        Long3 result = new();
        for (int i = 0; i < 3; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static ULong3 ToULong3(this IEnumerable<ulong> enumerable)
    {
        using IEnumerator<ulong> enumerator = enumerable.GetEnumerator();
        ULong3 result = new();
        for (int i = 0; i < 3; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static Float3 ToFloat3(this IEnumerable<float> enumerable)
    {
        using IEnumerator<float> enumerator = enumerable.GetEnumerator();
        Float3 result = new();
        for (int i = 0; i < 3; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static Double3 ToDouble3(this IEnumerable<double> enumerable)
    {
        using IEnumerator<double> enumerator = enumerable.GetEnumerator();
        Double3 result = new();
        for (int i = 0; i < 3; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }

    public static Decimal3 ToDecimal3(this IEnumerable<decimal> enumerable)
    {
        using IEnumerator<decimal> enumerator = enumerable.GetEnumerator();
        Decimal3 result = new();
        for (int i = 0; i < 3; i++)
        {
            if (!enumerator.MoveNext())
                throw new ArgumentException();
            result[i] = enumerator.Current;
        }
        if (enumerator.MoveNext())
            throw new ArgumentException();
        return result;
    }
}