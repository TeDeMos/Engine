// ReSharper disable MemberCanBePrivate.Global
namespace Engine;

public static class Intersections
{
    public static double DistanceTo(this Int2 a, Int2 b) => (a - b).Length;

    public static double DistanceTo(this Int2 point, IntLine line)
    {
        Int2 ab = line.Offset;
        Int2 bp = point - line.End;
        Int2 ap = point - line.Start;
        int abBp = ab.X * bp.X + ab.Y * bp.Y;
        int abAp = ab.X * ap.X + ab.Y * ap.Y;
        if (abBp > 0)
            return point.DistanceTo(line.End);
        if (abAp < 0)
            return point.DistanceTo(line.Start);
        return Math.Abs(ab.X * ap.Y - ab.Y * ap.X) / ab.Length;
    }

    public static double DistanceTo(this Int2 point, IntCircle circle) =>
        Math.Max(0, circle.Center.DistanceTo(point) - circle.Radius);

    public static double DistanceTo(this Int2 point, IntTriangle triangle) =>
        triangle.Contains(point) ? 0 : triangle.Sides.Min(side => point.DistanceTo(side));

    public static double DistanceTo(this Int2 point, IntRect rect)
    {
        if (point.X < rect.X)
        {
            if (point.Y < rect.Y)
                return point.DistanceTo(rect.TopLeft);
            if (point.Y > rect.Bottom)
                return point.DistanceTo(rect.BottomLeft);
            return rect.X - point.X;
        }
        if (point.X > rect.Right)
        {
            if (point.Y < rect.Y)
                return point.DistanceTo(rect.TopRight);
            if (point.Y > rect.Bottom)
                return point.DistanceTo(rect.BottomRight);
            return point.X - rect.Right;
        }
        if (point.Y < rect.Y)
            return rect.Y - point.Y;
        if (point.Y > rect.Bottom)
            return point.Y - rect.Bottom;
        return 0;
    }

    public static double DistanceTo(this IntLine line, Int2 point) => point.DistanceTo(line);

    public static double DistanceTo(this IntLine a, IntLine b)
    {
        if (a.Intersects(b))
            return 0;
        return Math.Min(a.Vertices.Min(vertex => vertex.DistanceTo(b)), b.Vertices.Min(vertex => vertex.DistanceTo(a)));
    }

    public static double DistanceTo(this IntLine line, IntCircle circle) =>
        Math.Max(0, circle.Center.DistanceTo(line) - circle.Radius);

    public static double DistanceTo(this IntLine line, IntTriangle triangle)
    {
        if (line.Start.IsInside(triangle) || line.End.IsInside(triangle))
            return 0;
        double min = double.MaxValue;
        foreach (IntLine side in triangle.Sides)
        {
            min = Math.Min(min, line.DistanceTo(side));
            if (min == 0)
                return 0;
        }
        return min;
    }

    public static double DistanceTo(this IntLine line, IntRect rect)
    {
        if (line.Start.IsInside(rect) || line.End.IsInside(rect))
            return 0;
        double min = double.MaxValue;
        foreach (IntLine side in rect.Sides)
        {
            min = Math.Min(min, line.DistanceTo(side));
            if (min == 0)
                return 0;
        }
        return min;
    }

    public static double DistanceTo(this IntCircle circle, Int2 point) => point.DistanceTo(circle);
    public static double DistanceTo(this IntCircle circle, IntLine line) => line.DistanceTo(circle);

    public static double DistanceTo(this IntCircle a, IntCircle b) =>
        Math.Max(0, a.Center.DistanceTo(b.Center) - a.Radius - b.Radius);

    public static double DistanceTo(this IntCircle circle, IntTriangle triangle)
    {
        if (circle.Center.IsInside(triangle))
            return 0;
        double min = double.MaxValue;
        foreach (IntLine side in triangle.Sides)
        {
            min = Math.Min(min, circle.DistanceTo(side));
            if (min == 0)
                return 0;
        }
        return min;
    }

    public static double DistanceTo(this IntCircle circle, IntRect rect)
    {
        if (circle.X < rect.X)
        {
            if (circle.Y < rect.Y)
                return circle.DistanceTo(rect.TopLeft);
            if (circle.Y > rect.Bottom)
                return circle.DistanceTo(rect.BottomLeft);
            return Math.Max(0, rect.X - circle.X - circle.Radius);
        }
        if (circle.X > rect.Right)
        {
            if (circle.Y < rect.Y)
                return circle.DistanceTo(rect.TopRight);
            if (circle.Y > rect.Bottom)
                return circle.DistanceTo(rect.BottomRight);
            return Math.Max(0, circle.X - rect.Right - circle.Radius);
        }
        if (circle.Y < rect.Y)
            return Math.Max(0, rect.Y - circle.Y - circle.Radius);
        if (circle.Y > rect.Bottom)
            return Math.Max(0, circle.Y - rect.Bottom - circle.Radius);
        return 0;
    }

    public static double DistanceTo(this IntTriangle triangle, Int2 point) => point.DistanceTo(triangle);
    public static double DistanceTo(this IntTriangle triangle, IntLine line) => line.DistanceTo(triangle);
    public static double DistanceTo(this IntTriangle triangle, IntCircle circle) => circle.DistanceTo(triangle);

    public static double DistanceTo(this IntTriangle a, IntTriangle b)
    {
        double min = double.MaxValue;
        foreach (IntLine aSide in a.Sides)
        {
            min = Math.Min(min, aSide.DistanceTo(b));
            if (min == 0)
                return 0;
        }
        return min;
    }

    public static double DistanceTo(this IntTriangle triangle, IntRect rect)
    {
        double min = double.MaxValue;
        foreach (IntLine side in triangle.Sides)
        {
            min = Math.Min(min, side.DistanceTo(rect));
            if (min == 0)
                return 0;
        }
        return min;
    }

    public static double DistanceTo(this IntRect rect, Int2 point) => point.DistanceTo(rect);
    public static double DistanceTo(this IntRect rect, IntLine line) => line.DistanceTo(rect);
    public static double DistanceTo(this IntRect rect, IntCircle circle) => circle.DistanceTo(rect);
    public static double DistanceTo(this IntRect rect, IntTriangle triangle) => triangle.DistanceTo(rect);

    public static double DistanceTo(this IntRect a, IntRect b)
    {
        if (b.Right < a.X)
        {
            if (b.Bottom < a.Y)
                return b.BottomRight.DistanceTo(a.TopLeft);
            if (b.Y > a.Bottom)
                return b.TopRight.DistanceTo(a.BottomLeft);
            return a.X - b.Right;
        }
        if (b.X > a.Right)
        {
            if (b.Bottom < a.Y)
                return b.BottomLeft.DistanceTo(a.TopRight);
            if (b.Y > a.Bottom)
                return b.TopLeft.DistanceTo(a.BottomRight);
            return b.X - a.Right;
        }
        if (b.Bottom < a.Y)
            return a.Y - b.Bottom;
        if (b.Y > b.Bottom)
            return b.Y - a.Bottom;
        return 0;
    }

    public static bool Intersects(this IntLine a, IntLine b)
    {
        bool FractionCheck(int x, int y) =>
            y != 0 && (x == 0 || Math.Sign(x) == Math.Sign(y) && Math.Abs(x) <= Math.Abs(y));

        int tTop = (a.Start.X - b.Start.X) * (b.Start.Y - b.End.Y) - (a.Start.Y - b.Start.Y) * (b.Start.X - b.End.X);
        int tBottom = (a.Start.X - a.End.X) * (b.Start.Y - b.End.Y) - (a.Start.Y - a.End.Y) * (b.Start.X - b.End.X);
        int uTop = (a.Start.X - b.Start.X) * (a.Start.Y - a.End.Y) - (a.Start.Y - b.Start.Y) * (a.Start.X - a.End.X);
        int uBottom = (a.Start.X - a.End.X) * (b.Start.Y - b.End.Y) - (a.Start.Y - a.End.Y) * (b.Start.X - b.End.X);
        return FractionCheck(tTop, tBottom) && FractionCheck(uTop, uBottom);
    }

    public static bool Intersects(this IntLine line, IntCircle circle) =>
        circle.Center.DistanceTo(line) <= circle.Radius;

    public static bool Intersects(this IntLine line, IntTriangle triangle) =>
        line.Start.IsInside(triangle) || line.End.IsInside(triangle) ||
        triangle.Sides.Any(side => line.Intersects(side));

    public static bool Intersects(this IntLine line, IntRect rect) =>
        line.Start.IsInside(rect) || line.End.IsInside(rect) || rect.Sides.Any(side => line.Intersects(side));

    public static bool Intersects(this IntCircle circle, IntLine line) => line.Intersects(circle);

    public static bool Intersects(this IntCircle a, IntCircle b) =>
        a.Center.DistanceTo(b.Center) <= a.Radius + b.Radius;

    public static bool Intersects(this IntCircle circle, IntTriangle triangle) =>
        circle.Center.IsInside(triangle) || triangle.Sides.Any(side => circle.Intersects(side));

    public static bool Intersects(this IntCircle circle, IntRect rect) =>
        circle.Center + circle.Radius >= rect.TopLeft && circle.Center - circle.Radius <= rect.BottomRight;

    public static bool Intersects(this IntTriangle triangle, IntLine line) => line.Intersects(triangle);
    public static bool Intersects(this IntTriangle triangle, IntCircle circle) => circle.Intersects(triangle);
    public static bool Intersects(this IntTriangle a, IntTriangle b) => a.Sides.Any(side => side.Intersects(b));

    public static bool Intersects(this IntTriangle triangle, IntRect rect) =>
        triangle.Sides.Any(side => side.Intersects(rect));

    public static bool Intersects(this IntRect rect, IntLine line) => line.Intersects(rect);
    public static bool Intersects(this IntRect rect, IntCircle circle) => circle.Intersects(rect);
    public static bool Intersects(this IntRect rect, IntTriangle triangle) => triangle.Intersects(rect);

    public static bool Intersects(this IntRect a, IntRect b) =>
        b.BottomRight >= a.TopLeft && b.TopLeft <= a.BottomRight;

    public static Int2? Intersection(this IntLine a, IntLine b)
    {
        bool FractionCheck(int x, int y) =>
            y != 0 && (x == 0 || Math.Sign(x) == Math.Sign(y) && Math.Abs(x) <= Math.Abs(y));

        int tTop = (a.Start.X - b.Start.X) * (b.Start.Y - b.End.Y) - (a.Start.Y - b.Start.Y) * (b.Start.X - b.End.X);
        int tBottom = (a.Start.X - a.End.X) * (b.Start.Y - b.End.Y) - (a.Start.Y - a.End.Y) * (b.Start.X - b.End.X);
        int uTop = (a.Start.X - b.Start.X) * (a.Start.Y - a.End.Y) - (a.Start.Y - b.Start.Y) * (a.Start.X - a.End.X);
        int uBottom = (a.Start.X - a.End.X) * (b.Start.Y - b.End.Y) - (a.Start.Y - a.End.Y) * (b.Start.X - b.End.X);
        if (!(FractionCheck(tTop, tBottom) && FractionCheck(uTop, uBottom)))
            return null;
        double t = (double)tTop / tBottom;
        return new(a.Start.X + (int)((a.End.X - a.Start.X) * t), a.Start.Y + (int)((a.End.Y - a.Start.Y) * t));
    }

    // public static IntLine? Intersection(this IntLine line, IntCircle circle) => throw new NotImplementedException();
    //
    // public static IntLine? Intersection(this IntLine line, IntTriangle triangle)
    //     => throw new NotImplementedException();
    //
    // public static IntLine? Intersection(this IntLine line, IntRect rect) => throw new NotImplementedException();
    // public static IntLine? Intersection(this IntCircle circle, IntLine line) => line.Intersection(circle);
    // public static IntLine? Intersection(this IntTriangle triangle, IntLine line) => line.Intersection(triangle);
    // public static IntLine? Intersection(this IntRect rect, IntLine line) => line.Intersection(rect);

    public static IntRect? Intersection(this IntRect a, IntRect b)
    {
        int left = Math.Max(a.X, b.X);
        int right = Math.Min(a.Right, b.Right);
        int top = Math.Max(a.Y, b.Y);
        int bottom = Math.Min(a.Bottom, b.Bottom);
        if (right <= left || bottom <= top)
            return null;
        return new(left, top, right - left + 1, bottom - top + 1);
    }

    public static bool Contains(this IntCircle circle, Int2 point) => point.IsInside(circle);
    public static bool Contains(this IntCircle circle, IntLine line) => line.IsInside(circle);
    public static bool Contains(this IntCircle a, IntCircle b) => b.IsInside(a);
    public static bool Contains(this IntCircle circle, IntTriangle triangle) => triangle.IsInside(circle);
    public static bool Contains(this IntCircle circle, IntRect rect) => rect.IsInside(circle);
    public static bool Contains(this IntTriangle triangle, Int2 point) => point.IsInside(triangle);
    public static bool Contains(this IntTriangle triangle, IntLine line) => line.IsInside(triangle);
    public static bool Contains(this IntTriangle triangle, IntCircle circle) => circle.IsInside(triangle);
    public static bool Contains(this IntTriangle a, IntTriangle b) => b.IsInside(a);
    public static bool Contains(this IntTriangle triangle, IntRect rect) => rect.IsInside(triangle);
    public static bool Contains(this IntRect rect, Int2 point) => point.IsInside(rect);
    public static bool Contains(this IntRect rect, IntLine line) => line.IsInside(rect);
    public static bool Contains(this IntRect rect, IntCircle circle) => circle.IsInside(rect);
    public static bool Contains(this IntRect rect, IntTriangle triangle) => triangle.IsInside(rect);
    public static bool Contains(this IntRect a, IntRect b) => b.IsInside(a);

    public static bool IsInside(this Int2 point, IntCircle circle) => circle.Center.DistanceTo(point) <= circle.Radius;

    public static bool IsInside(this Int2 point, IntTriangle triangle)
    {
        int Sign(IntLine line) =>
            (point.X - line.End.X) * (line.Start.Y - line.End.Y) - (line.Start.X - line.End.X) * (point.Y - line.End.Y);

        int d1 = Sign(triangle.AB);
        int d2 = Sign(triangle.BC);
        int d3 = Sign(triangle.CA);
        bool hasNeg = d1 < 0 || d2 < 0 || d3 < 0;
        bool hasPos = d1 >= 0 || d2 >= 0 || d3 >= 0;
        return !(hasNeg && hasPos);
    }

    public static bool IsInside(this Int2 point, IntRect rect) => point >= rect.TopLeft && point <= rect.BottomRight;

    public static bool IsInside(this IntLine line, IntCircle circle) =>
        line.Start.IsInside(circle) && line.End.IsInside(circle);

    public static bool IsInside(this IntLine line, IntTriangle triangle) =>
        line.Start.IsInside(triangle) && line.End.IsInside(triangle);

    public static bool IsInside(this IntLine line, IntRect rect) =>
        line.Start.IsInside(rect) && line.End.IsInside(rect);

    public static bool IsInside(this IntCircle a, IntCircle b) => a.Center.DistanceTo(b.Center) <= b.Radius - a.Radius;

    public static bool IsInside(this IntCircle circle, IntTriangle triangle) =>
        circle.Center.IsInside(triangle) && triangle.Sides.All(side => !side.Intersects(circle));

    public static bool IsInside(this IntCircle circle, IntRect rect) =>
        circle.Center - circle.Radius >= rect.TopLeft && circle.Center + circle.Radius <= rect.BottomRight;

    public static bool IsInside(this IntTriangle triangle, IntCircle circle) =>
        triangle.Vertices.All(vertex => vertex.IsInside(circle));

    public static bool IsInside(this IntTriangle a, IntTriangle b) => a.Vertices.All(vertex => vertex.IsInside(b));

    public static bool IsInside(this IntTriangle triangle, IntRect rect) =>
        triangle.Vertices.All(vertex => vertex.IsInside(rect));

    public static bool IsInside(this IntRect rect, IntCircle circle) =>
        rect.Vertices.All(vertex => vertex.IsInside(circle));

    public static bool IsInside(this IntRect rect, IntTriangle triangle) =>
        rect.Vertices.All(vertex => vertex.IsInside(triangle));

    public static bool IsInside(this IntRect a, IntRect b) => a.TopLeft >= b.TopLeft && a.BottomRight <= b.BottomRight;
}
