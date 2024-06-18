// ReSharper disable UnusedMember.Global
namespace Engine;

public record struct Pixel(byte R, byte G, byte B)
{
    public static Pixel Random(Random r) => new((byte)r.Next(255), (byte)r.Next(255), (byte)r.Next(255));

    public static implicit operator Byte3(Pixel pixel) => new(pixel.R, pixel.G, pixel.B);
    public static implicit operator Pixel(Byte3 vector) => new(vector.X, vector.Y, vector.Z);
}