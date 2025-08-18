namespace PongGameSecondAttempt.util.obstacle;

public class PongBallObstacle(Board board, string name, int x, int y, int width, int height, Vector2Int startingVelocity) : BasicRenderableMovingObstacle(board, name, x, y, width, height, startingVelocity)
{
}