namespace PongGameSecondAttempt;

partial class PongGameEngine
{
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
        BoardX = 0;
        BoardY = 0;
        BoardWidth = 400;
        BoardHeight = 300;
        InfoLabelHeight = 0;
        WallSize = 10;
        DeathZoneWidth = 2;
        RacketWidth = 4;
        
        FormWidth = BoardWidth;
        FormHeight = BoardHeight + InfoLabelHeight;
        
        SuspendLayout();
        
        //form customization
        Size = new Size(FormWidth, FormHeight);
        Text = "Pong Game";
        BackColor = Color.Black;
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        
        ResumeLayout();
    }
}