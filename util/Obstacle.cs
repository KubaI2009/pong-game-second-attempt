namespace PongGameSecondAttempt.util;

public class Obstacle(Board board, int x, int y, int width, int height)
{
    public Board Board { get; protected set; } = board;
    public Vector2Int Position { get; set; } = new(x, y);
    public Vector2Int Size { get; set; } = new(width, height);

    public int X
    {
        get => Position.X;
    }

    public int Y
    {
        get => Position.Y;
    }

    public int Width
    {
        get => Size.X;
    }

    public int Height
    {
        get => Size.Y;
    }
    
    public int West
    {
        get => X;
    }

    public int North
    {
        get => Y;
    }

    public int East
    {
        get => West + Width;
    }

    public int South
    {
        get => North + Height;
    }
    
    public bool Overlaps(Obstacle other) => Overlaps(other.West, other.North, other.East, other.South);

    public bool Overlaps(int otherWest, int otherNorth, int otherEast, int otherSouth)
    {
        return !(West > otherEast || North > otherSouth || East < otherWest || South < otherNorth);
    }
    
    public virtual void Update() { }
}