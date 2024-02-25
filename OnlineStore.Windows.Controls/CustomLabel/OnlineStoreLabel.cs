using System.Drawing.Drawing2D;

namespace OnlineStore.Windows.Controls.CustomLabel;

public sealed class OnlineStoreRoundLabel : Label
{
    public OnlineStoreRoundLabel()
        => DoubleBuffered = true;

    protected override void OnPaint(PaintEventArgs e)
    {
        GraphicsPath gp = new GraphicsPath();

        gp.AddEllipse(0, 0, Width, Height);

        Region = new Region(gp);

        Invalidate();
    }
}