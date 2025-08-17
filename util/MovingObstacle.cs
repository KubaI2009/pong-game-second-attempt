namespace PongGameSecondAttempt.util;

public class MovingObstacle(Board board, int x, int y, int width, int height, Vector2Int startingVelocity) : Obstacle(board, x, y, width, height)
{
    public Vector2Int Velocity { get; set; } = startingVelocity.Copy();

    public void Move()
    {
        HashSet<CardinalDirection> reboundDirections = GetReboundDirections();

        foreach (CardinalDirection direction in reboundDirections)
        {
            Velocity.Rebound(direction);
        }
        
        Position.Add(Velocity);
    }

    private HashSet<CardinalDirection> GetReboundDirections()
    {
        HashSet<CardinalDirection> directions = new HashSet<CardinalDirection>();
        int newWest = X + Velocity.X;
        int newNorth = Y + Velocity.Y;
        int newEast = newWest + Width;
        int newSouth = newNorth + Height;

        foreach (Obstacle obstacle in Board.Obstacles)
        {
            foreach (CardinalDirection direction in GetReboundDirectionsForObstacle(newWest, newNorth, newEast, newSouth, obstacle))
            {
                directions.Add(direction);
            }
        }
        
        return directions;
    }

    public override void Update() => Move();

    private static HashSet<CardinalDirection> GetReboundDirectionsForObstacle(int newWest, int newNorth, int newEast, int newSouth, Obstacle obstacle)
    {
        HashSet<CardinalDirection> directions = new HashSet<CardinalDirection>();

        if (newWest == obstacle.East)
        {
            directions.Add(CardinalDirection.West);
        }

        if (newNorth == obstacle.South)
        {
            directions.Add(CardinalDirection.North);
        }

        if (newEast == obstacle.West)
        {
            directions.Add(CardinalDirection.East);
        }

        if (newSouth == obstacle.North)
        {
            directions.Add(CardinalDirection.South);
        }

        return directions;
    }
}