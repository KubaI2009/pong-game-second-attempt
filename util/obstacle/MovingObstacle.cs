namespace PongGameSecondAttempt.util.obstacle;

public abstract class MovingObstacle(Board board, string name, int x, int y, int width, int height, Vector2Int startingVelocity) : Obstacle(board, name, x, y, width, height)
{
    public Vector2Int Velocity { get; set; } = startingVelocity.Copy();

    public virtual void Move()
    {
        (HashSet<CardinalDirection> reboundDirections, Vector2Int displacement) = GetReboundDirections();
        
        foreach (CardinalDirection direction in reboundDirections)
        {
            Velocity.Rebound(direction);
        }
        
        Position.Add(displacement);
    }

    private (HashSet<CardinalDirection> directions, Vector2Int coordinates) GetReboundDirections()
    {
        int coordinateIndex = 0;
        HashSet<CardinalDirection> directions = new HashSet<CardinalDirection>();
        Vector2Int[] coordinates = GetMovementCoordinates();
        
        //experimental
        foreach (Vector2Int v in coordinates)
        {
            HashSet<CardinalDirection> reboundDirections = GetReboundDirectionsForCoordinates(West + v.X, North + v.Y, East + v.X, South + v.Y);

            if (reboundDirections.Count > 0)
            {
                return (reboundDirections, v);
            }
        }
        
        // int newWest = West + Velocity.X;
        // int newNorth = North + Velocity.Y;
        // int newEast = East + Velocity.X;
        // int newSouth = South + Velocity.Y;
        //
        // foreach (CardinalDirection direction in GetReboundDirectionsForCoordinates(newWest, newNorth, newEast, newSouth))
        // {
        //     directions.Add(direction);
        // }
        
        return (directions, new Vector2Int(Velocity.X, Velocity.Y));
    }

    private Vector2Int[] GetMovementCoordinates()
    {
        List<Vector2Int> coordinates = new List<Vector2Int>();

        if (Velocity.X == 0)
        {
            for (int i = 0; i < Velocity.Y; i++)
            {
                coordinates.Add(new Vector2Int(0, i + 1));
            }
            
            return coordinates.ToArray();
        }
        
        float m = Velocity.Y / Velocity.X;

        for (int i = 0; i < Velocity.X; i++)
        {
            int x = i + 1;
            int y = (int) (m * i + 0.1f);
            
            coordinates.Add(new Vector2Int(x, y));
        }
        
        return coordinates.ToArray();
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