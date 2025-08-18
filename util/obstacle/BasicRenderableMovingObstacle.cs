namespace PongGameSecondAttempt.util.obstacle;

public abstract class BasicRenderableMovingObstacle(Board board, string name, int x, int y, int width, int height, Vector2Int startingVelocity) : MovingObstacle(board, name, x, y, width, height, startingVelocity), IRenderable<BasicRectangle>
{
    public BasicRectangle ControlToRender { get; private set; } = new BasicRectangle(x, y, width, height);

    public override void Move()
    {
        base.Move();
        
        ControlToRender.Location = new Point(X, Y);
        ControlToRender.Size = new Size(Width, Height);
    }
}