namespace PongGameSecondAttempt.util;

public class BasicRectangle : Label
{
    public BasicRectangle(int x, int y, int width, int height) : this(x, y, width, height, Color.White) { }
    
    public BasicRectangle(int x, int y, int width, int height, Color backColor) : base()
    {
        Location = new Point(x, y);
        Size = new Size(width, height);
        
        BackColor = backColor;
        ForeColor = Color.Transparent;
    }
}