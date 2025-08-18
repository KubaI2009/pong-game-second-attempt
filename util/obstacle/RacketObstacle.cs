namespace PongGameSecondAttempt.util.obstacle;

public class RacketObstacle : BasicRenderableMovingObstacle
{
    private static Dictionary<Keys, CardinalDirection> s_DirectionOfKey = new Dictionary<Keys, CardinalDirection>()
    {
        { Keys.W, CardinalDirection.North },
        { Keys.Up, CardinalDirection.North },
        { Keys.S, CardinalDirection.South },
        { Keys.Down, CardinalDirection.South }
    };
    
    private int _velocityCoefficient;

    public RacketObstacle(Board board, string name, int x, int y, int width, int height, int velocityCoefficient) : base(board, name, x, y, width, height, Vector2Int.Zero)
    {
        _velocityCoefficient = velocityCoefficient;

        Board.Master.KeyDown += StartMovingEvent;
        Board.Master.KeyUp += StopMovingEvent;
    }
    
    public RacketObstacle(Board board, string name, int x, int y, int width, int height) : this(board, name, x, y, width, height, 1) { }
    
    public void StartMoving(CardinalDirection? direction)
    {
        if (direction == null)
        {
            return;
        }
        
        if (direction is CardinalDirection cardinalDirection)
        {
            Velocity = Vector2Int.Scale(cardinalDirection.NormalizedVelocity, _velocityCoefficient);
        }
    }

    public void StopMoving()
    {
        Velocity = Vector2Int.Zero;
    }

    private void StartMovingEvent(object? sender, KeyEventArgs e) => StartMoving(DirectionOfKey(e.KeyCode));
    
    private void StopMovingEvent(object? sender, KeyEventArgs e) => StopMoving();

    public static CardinalDirection? DirectionOfKey(Keys key)
    {
        try
        {
            return s_DirectionOfKey[key];
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
}