namespace PongGameRoot.util;

public class CardinalDirection
{
    private static readonly Vector2Int s_WestNormalizedVelocity = new Vector2Int(-1, 0);
    private static readonly Vector2Int s_NorthNormalizedVelocity = new Vector2Int(0, -1);
    private static readonly Vector2Int s_EastNormalizedVelocity = new Vector2Int(1, 0);
    private static readonly Vector2Int s_SouthNormalizedVelocity = new Vector2Int(0, 1);
    
    private static readonly Vector2Int s_WestReboundCoefficient = new Vector2Int(-1, 1);
    private static readonly Vector2Int s_NorthReboundCoefficient = new Vector2Int(1, -1);
    private static readonly Vector2Int s_EastReboundCoefficient = new Vector2Int(-1, 1);
    private static readonly Vector2Int s_SouthReboundCoefficient = new Vector2Int(1, -1);

    public static readonly CardinalDirection West = new CardinalDirection("west", s_WestNormalizedVelocity, s_NorthNormalizedVelocity);
    public static readonly CardinalDirection North = new CardinalDirection("north", s_NorthNormalizedVelocity, s_NorthReboundCoefficient);
    private static readonly CardinalDirection East = new CardinalDirection("east", s_EastNormalizedVelocity, s_EastReboundCoefficient);
    private static readonly CardinalDirection South = new CardinalDirection("south", s_SouthNormalizedVelocity, s_SouthReboundCoefficient);
    
    public string Name { get; private set; }
    public Vector2Int NormalizedVelocity { get; private set; }
    public Vector2Int ReboundCoefficient { get; private set; }

    private CardinalDirection(string name, Vector2Int normalizedVelocity, Vector2Int reboundCoefficient)
    {
        Name = name;
        NormalizedVelocity = normalizedVelocity;
        ReboundCoefficient = reboundCoefficient;
    }
}