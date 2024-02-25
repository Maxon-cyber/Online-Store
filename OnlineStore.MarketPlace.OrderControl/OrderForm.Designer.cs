namespace OnlineStore.MarketPlace.OrderControl;

public sealed partial class OrderForm
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
        tableLayoutPanelViewOrders = new TableLayoutPanel();
        SuspendLayout();
        // 
        // tableLayoutPanelViewOrders
        // 
        tableLayoutPanelViewOrders.AutoScroll = true;
        tableLayoutPanelViewOrders.ColumnCount = 2;
        tableLayoutPanelViewOrders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanelViewOrders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanelViewOrders.Dock = DockStyle.Fill;
        tableLayoutPanelViewOrders.Location = new Point(0, 0);
        tableLayoutPanelViewOrders.Name = "tableLayoutPanelViewOrders";
        tableLayoutPanelViewOrders.Padding = new Padding(0, 0, 17, 0);
        tableLayoutPanelViewOrders.RowCount = 2;
        tableLayoutPanelViewOrders.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanelViewOrders.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanelViewOrders.Size = new Size(745, 455);
        tableLayoutPanelViewOrders.TabIndex = 0;
        // 
        // OrderForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(tableLayoutPanelViewOrders);
        DoubleBuffered = true;
        Name = "OrderForm";
        Size = new Size(745, 455);
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanelViewOrders;
}