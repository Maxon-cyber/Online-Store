using System.ComponentModel;

namespace OnlineStore.Windows.Controls.CustomProgressBar;

public sealed class OnlineStoreProgressBar : ProgressBar
{
    private Color _channelColor = Color.LightSteelBlue;
    private Color _sliderColor = Color.RoyalBlue;
    private Color _foreBacklColor = Color.RoyalBlue;

    private int _channelHeight = 6;
    private int _sliderHeight = 6;

    private string _symbolBefore = string.Empty;
    private string _symbolAfter = string.Empty;
    private bool _showMaximum = false;

    private TextPosition _showValue = TextPosition.Right;

    private bool _paintedBack = false;
    private bool _stopPainting = false;

    [Category("Custom ProgressBase By Maxim Tumakov")]
    public Color ChannelColor
    {
        get => _channelColor;
        set { _channelColor = value; Invalidate(); }
    }

    [Category("Custom ProgressBase By Maxim Tumakov")]
    public Color SliderlColor
    {
        get => _sliderColor;
        set { _sliderColor = value; Invalidate(); }
    }

    [Category("Custom ProgressBase By Maxim Tumakov")]
    public Color ForeBacklColor
    {
        get => _foreBacklColor;
        set { _foreBacklColor = value; Invalidate(); }
    }

    [Category("Custom ProgressBase By Maxim Tumakov")]
    public TextPosition ShowValue
    {
        get => _showValue;
        set { _showValue = value; Invalidate(); }
    }

    [Category("Custom ProgressBase By Maxim Tumakov")]
    public string SymbolBefore
    {
        get => _symbolBefore;
        set { _symbolBefore = value; Invalidate(); }
    }

    [Category("Custom ProgressBase By Maxim Tumakov")]
    public string SymbolAfter
    {
        get => _symbolAfter;
        set { _symbolAfter = value; Invalidate(); }
    }

    [Category("Custom ProgressBase By Maxim Tumakov")]
    public bool ShowMaximum
    {
        get => _showMaximum;
        set { _showMaximum = value; Invalidate(); }
    }

    [Category("Custom ProgressBase By Maxim Tumakov")]
    public int ChannelHeight
    {
        get => _channelHeight;
        set { _channelHeight = value; Invalidate(); }
    }

    [Category("Custom ProgressBase By Maxim Tumakov")]
    public int SliderHeight
    {
        get => _sliderHeight;
        set { _sliderHeight = value; Invalidate(); }
    }

    [Category("Custom ProgressBase By Maxim Tumakov")]
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public override Font Font 
    { 
        get => base.Font; 
        set => base.Font = value; 
    }

    [Category("Custom ProgressBase By Maxim Tumakov")]
    public override Color ForeColor 
    { 
        get => base.ForeColor; 
        set => base.ForeColor = value; 
    }

    public OnlineStoreProgressBar()
    {
        SetStyle(ControlStyles.UserPaint, true);
        ForeColor = Color.White;
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        if (!_stopPainting)
        {
            if (!_paintedBack)
            {
                Graphics graphics = e.Graphics;
                Rectangle rectangleChannel = new Rectangle(0, 0, Width, _channelHeight);

                using SolidBrush solidBrush = new SolidBrush(_channelColor);

                if (_channelHeight > _sliderHeight)
                    rectangleChannel.Y = Height - _channelHeight;
                else
                    rectangleChannel.Y = Height - ((_channelHeight + _sliderHeight) / 2);

                graphics.Clear(Parent.BackColor);
                graphics.FillRectangle(solidBrush, rectangleChannel);

                if (!DesignMode)
                    _paintedBack = true;
            }

            if (Value == Maximum || Value == Minimum)
                _paintedBack = false;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (!_stopPainting)
        {
            Graphics graphics = e.Graphics;
            double scaleFactor = (((double)Value - Minimum) / ((double)Maximum - Minimum));
            int sliderWidth = (int)(Width * scaleFactor);
            Rectangle rectangle = new Rectangle(0, 0, sliderWidth, _sliderHeight);

            using SolidBrush solidBrush = new SolidBrush(_sliderColor);

            if (_sliderHeight >= _channelHeight)
                rectangle.Y = Height - _sliderHeight;
            else
                rectangle.Y = Height - ((_sliderHeight + _channelHeight) / 2);

            if (_sliderHeight > 1)
                graphics.FillRectangle(solidBrush, rectangle);
            if (_showValue != TextPosition.None)
                DrawValueText(graphics, sliderWidth, rectangle);
        }

        if (Value == Maximum)
            _stopPainting = true;
        else
            _stopPainting = false;
    }

    private void DrawValueText(Graphics graphics, int sliderWidth, Rectangle rectangle)
    {
        string text = Value.ToString() + _symbolAfter;

        if (_showMaximum)
            text = text + "/" + _symbolBefore + Maximum.ToString() + _symbolAfter;

        Size textSize = TextRenderer.MeasureText(text, Font);
        Rectangle rectangleText = new Rectangle(0, 0, textSize.Width, textSize.Height + 2);

        using SolidBrush brushText = new SolidBrush(ForeColor);
        using SolidBrush brushTextBack = new SolidBrush(_foreBacklColor);
        using StringFormat textFormat = new StringFormat();

        switch (_showValue) 
        {
            case TextPosition.Right:
                rectangleText.X = Width - textSize.Width;
                textFormat.Alignment = StringAlignment.Far;
                break;
            case TextPosition.Left:
                rectangleText.X = 0;
                textFormat.Alignment = StringAlignment.Near;
                break;
            case TextPosition.Center:
                rectangleText.X = (Width - textSize.Width) / 2;
                textFormat.Alignment = StringAlignment.Center;
                break;
            case TextPosition.Sliding:
                rectangleText.X = sliderWidth - textSize.Width;
                textFormat.Alignment = StringAlignment.Center;

                using (SolidBrush solidBrush = new SolidBrush(Parent.BackColor))
                {
                    Rectangle rect = rectangle;
                    rect.Y = rectangleText.Y;
                    rect.Height = rectangleText.Height;
                    graphics.FillRectangle(solidBrush, rect);
                }
                break;
        }

        graphics.FillRectangle(brushTextBack, rectangleText);
        graphics.DrawString(text, this.Font, brushText, rectangleText, textFormat);
    }
}