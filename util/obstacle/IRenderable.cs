namespace PongGameSecondAttempt.util.obstacle;

public interface IRenderable<T> where T : Control
{
    T ControlToRender { get; }
}