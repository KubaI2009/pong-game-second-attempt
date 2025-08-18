namespace PongGameSecondAttempt.util.obstacle;

public abstract class MovingObstacle(Board board, string name, int x, int y, int width, int height, Vector2Int startingVelocity) : Obstacle(board, name, x, y, width, height)
{
    public Vector2Int Velocity { get; set; } = startingVelocity.Copy();

    public virtual void Move()
    {
        (HashSet<CardinalDirection> reboundDirections, Vector2Int reboundCoordinates) = GetReboundDirections();
        
        foreach (CardinalDirection direction in reboundDirections)
        {
            Velocity.Rebound(direction);
        }
        
        Position.Add(Velocity);
    }

    private (HashSet<CardinalDirection> directions, Vector2Int coordinates) GetReboundDirections()
    {
        int coordinateIndex = 0;
        HashSet<CardinalDirection> directions = new HashSet<CardinalDirection>();
        List<Vector2Int> coordinates = new List<Vector2Int>();
        
        int newWest = West + Velocity.X;
        int newNorth = North + Velocity.Y;
        int newEast = East + Velocity.X;
        int newSouth = South + Velocity.Y;

        foreach (CardinalDirection direction in GetReboundDirectionsForCoordinates(newWest, newNorth, newEast, newSouth))
        {
            directions.Add(direction);
        }
        
        return (directions, new Vector2Int(newWest, newNorth));
    }

    private HashSet<CardinalDirection> GetReboundDirectionsForCoordinates(int newWest, int newNorth, int newEast, int newSouth)
    {
        HashSet<CardinalDirection> directions = new HashSet<CardinalDirection>();

        foreach (Obstacle obstacle in Board.Obstacles)
        {
            HashSet<CardinalDirection> reboundDirections = GetReboundDirectionsForObstacle(newWest, newNorth, newEast, newSouth, obstacle);
            
            if (reboundDirections.Count > 0)
            {
                OnRebound(obstacle);
            }
            
            foreach (CardinalDirection direction in reboundDirections)
            {
                directions.Add(direction);
                
                //Console.WriteLine(direction);
            }
        }
        
        return directions;
    }

    public override void Update()
    {
        base.Update();
        Move();
    }
    
    public virtual void OnRebound(Obstacle obstacle) { }

    private static HashSet<CardinalDirection> GetReboundDirectionsForObstacle(int newWest, int newNorth, int newEast, int newSouth, Obstacle obstacle)
    {
        HashSet<CardinalDirection> directions = new HashSet<CardinalDirection>();
        
        if (!obstacle.Overlaps(newWest, newNorth, newEast, newSouth))
        {
            return directions;
        }

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