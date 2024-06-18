// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global
namespace Engine;

public class Font
{
    public Texture Texture { get; }
    public HashSet<char> AvailableChars { get; }
    private readonly Dictionary<char, IntRect> _charPositions;

    public IntRect this[char c] => _charPositions.GetValueOrDefault(c, _charPositions[' ']);

    public Font(Texture texture, Dictionary<char, IntRect> charPositions)
    {
        Texture = texture;
        _charPositions = new(charPositions);
        if (charPositions.Values.Any(rect => rect.X < 0 || rect.Y < 0 || rect.BottomRight.X > texture.Width ||
                                             rect.BottomRight.Y > texture.Height))
            throw new ArgumentException("Char positions point outside of the texture");
        AvailableChars = charPositions.Keys.ToHashSet();
    }

    public static Dictionary<char, IntRect> ParsePositions(string s)
    {
        string[] split = s.ReplaceLineEndings().Split('\n');
        Dictionary<char, IntRect> result = new();
        foreach (string str in split)
        {
            if (str.Length < 8)
                throw new ArgumentException($"Length error at: {str}");
            string[] rectString = str[1..].Split(';');
            if (rectString.Length != 4)
                throw new ArgumentException($"Rect values count error at: {str}");
            int[] rect = new int[4];
            if (rectString.Where((t, i) => !int.TryParse(t, out rect[i])).Any())
                throw new ArgumentException($"Rect values int parsing error at: {str}");
            result.Add(str[0], new(rect[0], rect[1], rect[2], rect[3]));
        }
        if (!result.ContainsKey(' '))
            throw new ArgumentException("Font has to contain a space character");
        return result;
    }

    public static Func<Pixel?, Pixel, Pixel?> Blend(Pixel fontColor)
    {
        Pixel? Function(Pixel? texture, Pixel background)
        {
            if (!texture.HasValue)
                return background;
            double ratio = 1 - texture.Value.R / 255d;
            return (Byte3)((Byte3)fontColor * (Double3)ratio);
        }

        return Function;
    }
    
    protected int GetStringLength(string s) => s.Sum(c => this[c].Width);
}