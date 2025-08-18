namespace PongGameSecondAttempt.util.obstacle;

public class PongBallObstacle(Board board, string name, int x, int y, int width, int height, Vector2Int startingVelocity) : BasicRenderableMovingObstacle(board, name, x, y, width, height, startingVelocity)
{
    public override void Move()
    {
        base.Move();

        //Console.WriteLine(Velocity);
    }

    public override void OnRebound(Obstacle obstacle)
    {
        base.OnRebound(obstacle);

        //Console.WriteLine(obstacle);
    }
}