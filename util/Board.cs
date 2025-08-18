using PongGameSecondAttempt.util.obstacle;

namespace PongGameSecondAttempt.util;

public class Board(PongGameEngine master, List<Obstacle> obstacles)
{
    public PongGameEngine Master { get; protected set; } = master;
    private List<Obstacle> _obstacles = obstacles.Slice(0, obstacles.Count - 1 < 0 ? 0 : obstacles.Count - 1);
    
    public Obstacle[] Obstacles => _obstacles.ToArray();
    
    public Board(PongGameEngine master) : this(master, new List<Obstacle>()) { }

    public void Update()
    {
        foreach (Obstacle obstacle in _obstacles)
        {
            obstacle.Update();
        }
    }

    public void AddObstacle(Obstacle obstacle)
    {
        _obstacles.Add(obstacle);
    }
}