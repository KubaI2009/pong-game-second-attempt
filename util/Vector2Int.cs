namespace PongGameSecondAttempt.util;

public class Vector2Int(int x, int y)
{
    public static Vector2Int Zero => new(0, 0);

    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    public int Magnitude
    {
        get => (int) Math.Sqrt(X * X + Y * Y);
    }
    
    public Vector2Int(Vector2Int v) : this(v.X, v.Y) { }

    public void Add(Vector2Int v)
    {
        X += v.X;
        Y += v.Y;
    }

    public void Scale(int c)
    {
        X *= c;
        Y *= c;
    }

    public void EntryWiseMultiply(Vector2Int v)
    {
        X *= v.X;
        Y *= v.Y;
    }

    public void Rebound(CardinalDirection direction)
    {
        EntryWiseMultiply(direction.ReboundCoefficient);
    }

    public override bool Equals(object obj)
    {
        return obj is Vector2Int v && X == v.X && Y == v.Y;
    }
    
    public override string ToString()
    {
        return $"Vector2Int({X}, {Y})";
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public Vector2Int Copy()
    {
        return new Vector2Int(X, Y);
    }

    public static Vector2Int Sum(Vector2Int v1, Vector2Int v2)
    {
        return new Vector2Int(v1.X + v2.X, v1.Y + v2.Y);
    }
    
    public static Vector2Int Scale(int c, Vector2Int v) => Scale(v, c);

    public static Vector2Int Scale(Vector2Int v, int c)
    {
        return new Vector2Int(v.X * c, v.Y * c);
    }

    public static Vector2Int EntryWiseProduct(Vector2Int v1, Vector2Int v2)
    {
        return new Vector2Int(v1.X * v2.X, v1.Y * v2.Y);
    }
}