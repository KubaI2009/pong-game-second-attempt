namespace PongGameSecondAttempt.util;

public struct CardinalDirection
{
    private static readonly Vector2Int s_WestNormalizedVelocity = new Vector2Int(-1, 0);
    private static readonly Vector2Int s_NorthNormalizedVelocity = new Vector2Int(0, -1);
    private static readonly Vector2Int s_EastNormalizedVelocity = new Vector2Int(1, 0);
    private static readonly Vector2Int s_SouthNormalizedVelocity = new Vector2Int(0, 1);
    
    private static readonly Vector2Int s_WestReboundCoefficient = new Vector2Int(-1, 1);
    private static readonly Vector2Int s_NorthReboundCoefficient = new Vector2Int(1, -1);
    private static readonly Vector2Int s_EastReboundCoefficient = new Vector2Int(-1, 1);
    private static readonly Vector2Int s_SouthReboundCoefficient = new Vector2Int(1, -1);

    public static CardinalDirection West => new("west", s_WestNormalizedVelocity, s_WestReboundCoefficient);
    public static CardinalDirection North => new("north", s_NorthNormalizedVelocity, s_NorthReboundCoefficient);
    public static CardinalDirection East => new("east", s_EastNormalizedVelocity, s_EastReboundCoefficient);
    public static CardinalDirection South => new("south", s_SouthNormalizedVelocity, s_SouthReboundCoefficient);
    
    public string Name { get; private set; }
    public Vector2Int NormalizedVelocity { get; private set; }
    public Vector2Int ReboundCoefficient { get; private set; }

    private CardinalDirection(string name, Vector2Int normalizedVelocity, Vector2Int reboundCoefficient)
    {
        Name = name;
        NormalizedVelocity = normalizedVelocity;
        ReboundCoefficient = reboundCoefficient;
    }

    public override string ToString()
    {
        return $"CardinalDirection(Name = {Name}, NormalizedVelocity = {NormalizedVelocity}, ReboundCoefficient = {ReboundCoefficient})";
    }
}