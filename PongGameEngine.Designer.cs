using PongGameSecondAttempt.util;
using PongGameSecondAttempt.util.obstacle;
using System.Timers;

namespace PongGameSecondAttempt;

partial class PongGameEngine
{
    private System.Timers.Timer _timer;
    private long _ticks;
    
    private RacketObstacle _westRacket;
    private RacketObstacle _eastRacket;
    
    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int FormWidth { get; private set; }
    public int FormHeight { get; private set; }
    public int InfoLabelHeight { get; private set; }
    public int BoardX { get; private set; }
    public int BoardY { get; private set; }
    public int BoardWidth { get; private set; }
    public int BoardHeight { get; private set; }
    public int WallSize { get; private set; }
    public int DeathZoneWidth { get; private set; }
    public int RacketWidth { get; private set; }
    public int RacketHeight { get; private set; }
    public int RacketVelocityCoefficient { get; private set; }
    public int BallSize { get; private set; } //I know this sounds horrible without context
    
    public Board Board { get; private set; }
    
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PongGameEngine));
        SuspendLayout();
        // 
        // PongGameEngine
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        Text = "";
        ResumeLayout(false);
    }

    #endregion

    protected void CustomizeComponent()
    {
        //setting properties
        BoardX = 60;
        BoardY = 60;
        BoardWidth = 400;
        BoardHeight = 300;
        InfoLabelHeight = 0;
        WallSize = 30;
        DeathZoneWidth = 4;
        RacketWidth = 10;
        RacketHeight = BoardHeight / 4;
        RacketVelocityCoefficient = 3;
        BallSize = 15;
        
        FormWidth = BoardWidth + 400;
        FormHeight = BoardHeight + InfoLabelHeight + 400;
        
        SuspendLayout();
        
        //form customization
        Size = new Size(FormWidth, FormHeight);
        Text = "Pong Game";
        BackColor = Color.Black;
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        
        //board initialization
        Board = new Board(this);
        
        //invisible walls initialization
        Board.AddObstacle(new InvisibleWallObstacle(Board, "wWest", BoardX - WallSize, BoardY, WallSize, BoardHeight));
        Board.AddObstacle(new InvisibleWallObstacle(Board, "wNorth", BoardX - WallSize, BoardY - WallSize, BoardWidth + 2 * WallSize, WallSize));
        Board.AddObstacle(new InvisibleWallObstacle(Board, "wEast", BoardX + BoardWidth, BoardY, WallSize, BoardHeight));
        Board.AddObstacle(new InvisibleWallObstacle(Board, "wSouth", BoardX - WallSize, BoardY + BoardHeight, BoardWidth + 2 * WallSize, WallSize));
        
        //Board.AddObstacle(new InvisibleWallObstacle(Board, "wTest", BoardX + BoardWidth / 2, BoardY + BoardHeight / 2, BoardWidth / 2, WallSize));
        
        //racket initialization
        _westRacket = new RacketObstacle(Board, "rWest", BoardX, BoardY + (BoardHeight - RacketHeight) / 2, RacketWidth, RacketHeight, RacketVelocityCoefficient);
        _eastRacket = new RacketObstacle(Board, "rEast", BoardX + BoardWidth - RacketWidth, BoardY + (BoardHeight - RacketHeight) / 2, RacketWidth, RacketHeight, RacketVelocityCoefficient);
            
        Board.AddObstacle(_westRacket);
        Board.AddObstacle(_eastRacket);
        
        //pong ball initialization
        Board.AddObstacle(new PongBallObstacle(Board, "pongBall", BoardX + RacketWidth, BoardY + BoardHeight / 2, BallSize, BallSize, new Vector2Int(1, 1)));

        //rendering
        RenderObstacles();
        
        //dunno
        AddVelocityCorrection();
        
        //timer initialization
        InitTimer();
        
        ResumeLayout();
    }

    private void AddVelocityCorrection()
    {
        KeyUp += VelocityCorrectionEvent;
    }

    private void VelocityCorrectionEvent(object? sender, KeyEventArgs e)
    {
        if (RacketObstacle.DirectionOfKey(e.KeyCode) == null)
        {
            return;
        }

        _eastRacket.Y = _westRacket.Y;
    }

    private void RenderObstacles()
    {
        foreach (Obstacle obstacle in Board.Obstacles)
        {
            if (obstacle is IRenderable<BasicRectangle> renderable)
            {
                Controls.Add(renderable.ControlToRender);
            }
        }
        
        //for debugging purposes
        foreach (Obstacle obstacle in Board.Obstacles)
        {
            if (obstacle is InvisibleWallObstacle)
            {
                Controls.Add(new BasicRectangle(obstacle.X, obstacle.Y, obstacle.Width, obstacle.Height, Color.Green));
            }
        }
    }

    public void Update()
    {
        Board.Update();
    }

    private void InitTimer()
    {
        _timer = new System.Timers.Timer();
        _timer.Interval = 15;
        _timer.Elapsed += UpdateEvent;
        _timer.Start();
    }

    private void UpdateEvent(object? sender, EventArgs e)
    {
        _ticks++;

        //Console.WriteLine(_ticks);
        
        Update();
    }
}