using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace OnlineStore.Windows.Controls.CustomButton;

public sealed class OnlineStoreButton : Button
{
    private int _borderSize = 0;
    private int _borderRadius = 0;
    private Color _borderColor = Color.PaleVioletRed;

    [Category("Custom Button By Maxim Tumakov")]
    public int BorderSize
    {
        get { return _borderSize; }
        set { _borderSize = value; Invalidate(); }
    }

    [Category("Custom Button By Maxim Tumakov")]
    public int BorderRadius
    {
        get { return _borderRadius; }
        set { _borderRadius = value; Invalidate(); }
    }

    [Category("Custom Button By Maxim Tumakov")]
    public Color BorderColor
    {
        get { return _borderColor; }
        set { _borderColor = value; Invalidate(); }
    }

    [Category("Custom Button By Maxim Tumakov")]
    public Color BackgroundColor
    {
        get { return BackColor; }
        set { BackColor = value; }
    }

    [Category("Custom Button By Maxim Tumakov")]
    public Color TextColor
    {
        get { return ForeColor; }
        set { ForeColor = value; }
    }

    public OnlineStoreButton()
    {
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;

        this.Size = new Size(150, 40);
        this.BackColor = Color.MediumSlateBlue;
        this.ForeColor = Color.White;

        this.Resize += new EventHandler(Button_Resize);
    }

    private GraphicsPath GetFigurePath(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        float curveSize = radius * 2F;

        path.StartFigure();

        path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
        path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
        path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
        path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);

        path.CloseFigure();

        return path;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        Rectangle rectSurface = ClientRectangle;
        Rectangle rectBorder = Rectangle.Inflate(rectSurface, -_borderSize, -_borderSize);

        int smoothSize = 2;

        if (_borderSize > 0)
            smoothSize = _borderSize;

        if (_borderRadius > 2)
        {
            using GraphicsPath pathSurface = GetFigurePath(rectSurface, _borderRadius);
            using GraphicsPath pathBorder = GetFigurePath(rectBorder, _borderRadius - _borderSize);
            using Pen penSurface = new Pen(Parent.BackColor, smoothSize);
            using Pen penBorder = new Pen(_borderColor, _borderSize);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Region = new Region(pathSurface);
            pevent.Graphics.DrawPath(penSurface, pathSurface);

            if (_borderSize >= 1)
                pevent.Graphics.DrawPath(penBorder, pathBorder);
        }
        else
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.None;
            Region = new Region(rectSurface);

            if (_borderSize >= 1)
            {
                using Pen penBorder = new Pen(_borderColor, _borderSize);
                penBorder.Alignment = PenAlignment.Inset;
                pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
            }
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
    }

    private void Container_BackColorChanged(object sender, EventArgs e)
        => Invalidate();

    private void Button_Resize(object sender, EventArgs e)
    {
        if (_borderRadius > Height)
            _borderRadius = Height;
    }
}