namespace PongGameSecondAttempt.util.obstacle;

public abstract class Obstacle(Board board, string name, int x, int y, int width, int height)
{
    public Board Board { get; protected set; } = board;
    public string Name { get; protected set; } = name;
    public Vector2Int Position { get; set; } = new(x, y);
    public Vector2Int Size { get; set; } = new(width, height);

    public int X
    {
        get => Position.X;
        set => Position.X = value;
    }

    public int Y
    {
        get => Position.Y;
        set => Position.Y = value;
    }

    public int Width
    {
        get => Size.X;
        set => Size.X = value;
    }

    public int Height
    {
        get => Size.Y;
        set => Size.Y = value;
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
    
    public virtual void Affect(Obstacle other) { }

    public override string ToString()
    {
        return $"Obstacle(Name = {Name}, Position = {Position}, Size = {Size})";
    }
}