namespace WindowApplications;

public class SheepsWorld
{
    int sheepsCount;
    public event EventHandler Changed;

    public int SheepsCount
    {
        get { return sheepsCount; }
        set
        {
            sheepsCount = value;
            Changed?.Invoke(this, EventArgs.Empty);
        }
    }
}

public partial class SheepsWindow : Form
{
    SheepsWorld world;

    public SheepsWindow(SheepsWorld world)
    {
        this.world = world;
        world.Changed += (_, __) => Invalidate();
        KeyDown += (_, __) => world.SheepsCount++;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.DrawString(
            "Sheeps alive: " + world.SheepsCount,
            new Font("Arial", 14), Brushes.Black, new Point(0, 0)
        );
    }
}