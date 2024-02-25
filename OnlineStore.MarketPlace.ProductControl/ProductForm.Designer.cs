namespace OnlineStore.MarketPlace.ProductControl;

public sealed partial class ProductForm
{
    private System.ComponentModel.IContainer _components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (_components != null))
            _components.Dispose();

        base.Dispose(disposing);
    }

    #region Component Designer generated code
    private void InitializeComponent()
    {
        tableLayoutPanelViewProducts = new TableLayoutPanel();
        textBoxSearch = new TextBox();
        buttonSearch = new Button();
        progressBar = new Windows.Controls.CustomProgressBar.OnlineStoreProgressBar();
        SuspendLayout();
        // 
        // tableLayoutPanelViewProducts
        // 
        tableLayoutPanelViewProducts.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        tableLayoutPanelViewProducts.AutoScroll = true;
        tableLayoutPanelViewProducts.ColumnCount = 3;
        tableLayoutPanelViewProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanelViewProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanelViewProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanelViewProducts.Location = new Point(0, 158);
        tableLayoutPanelViewProducts.Name = "tableLayoutPanelViewProducts";
        tableLayoutPanelViewProducts.Padding = new Padding(0, 0, 17, 0);
        tableLayoutPanelViewProducts.RowCount = 2;
        tableLayoutPanelViewProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanelViewProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanelViewProducts.Size = new Size(745, 297);
        tableLayoutPanelViewProducts.TabIndex = 0;
        // 
        // textBoxSearch
        // 
        textBoxSearch.Location = new Point(3, 42);
        textBoxSearch.Name = "textBoxSearch";
        textBoxSearch.Size = new Size(363, 23);
        textBoxSearch.TabIndex = 1;
        // 
        // buttonSearch
        // 
        buttonSearch.Location = new Point(372, 42);
        buttonSearch.Name = "buttonSearch";
        buttonSearch.Size = new Size(75, 23);
        buttonSearch.TabIndex = 2;
        buttonSearch.Text = "button1";
        buttonSearch.UseVisualStyleBackColor = true;
        buttonSearch.Click += BtnSearch_Click;
        // 
        // progressBar
        // 
        progressBar.BackColor = Color.Black;
        progressBar.ChannelColor = Color.Crimson;
        progressBar.ChannelHeight = 15;
        progressBar.ForeBacklColor = Color.RoyalBlue;
        progressBar.ForeColor = Color.White;
        progressBar.Location = new Point(3, 129);
        progressBar.Name = "progressBar";
        progressBar.ShowMaximum = true;
        progressBar.ShowValue = Windows.Controls.CustomProgressBar.TextPosition.Sliding;
        progressBar.Size = new Size(739, 23);
        progressBar.SliderHeight = 6;
        progressBar.SliderlColor = Color.RoyalBlue;
        progressBar.Style = ProgressBarStyle.Continuous;
        progressBar.SymbolAfter = "";
        progressBar.SymbolBefore = "%";
        progressBar.TabIndex = 3;
        // 
        // ProductForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        Controls.Add(progressBar);
        Controls.Add(buttonSearch);
        Controls.Add(textBoxSearch);
        Controls.Add(tableLayoutPanelViewProducts);
        DoubleBuffered = true;
        Name = "ProductForm";
        Size = new Size(745, 455);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TableLayoutPanel tableLayoutPanelViewProducts;
    private System.ComponentModel.IContainer components;
    private TextBox textBoxSearch;
    private Button buttonSearch;
    private Windows.Controls.CustomProgressBar.OnlineStoreProgressBar progressBar;
}