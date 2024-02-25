namespace OnlineStore.MarketPlace;

public sealed partial class MarketPlaceForm
{
    private System.ComponentModel.IContainer _components = null;

    private static readonly Color ActivateButtonBackColor = Color.FromArgb(234, 12, 234);
    private static readonly Color ActivateButtonForeColor = Color.White;
    private static readonly Font ActiveButtonFont = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, (byte)0);

    private static readonly Color DisableButtonBackColor = Color.FromArgb(190, 12, 234);
    private static readonly Color DisableButtonForeColor = Color.Gainsboro;
    private static readonly Font DisableButtonFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, (byte)0);

    private void ActivateButton(Button button)
    {
        if (button == null)
            throw new NullReferenceException();

        DisableButton();
        button.BackColor = ActivateButtonBackColor;
        button.ForeColor = ActivateButtonForeColor;
        button.Font = ActiveButtonFont;

        panelTitle.BackColor = button.BackColor;
        panelTitle.ForeColor = Color.Black;
    }

    private void DisableButton()
    {
        foreach (Button button in panelMenu.Controls.OfType<Button>())
        {
            button.BackColor = DisableButtonBackColor;
            button.ForeColor = DisableButtonForeColor;
            button.Font = DisableButtonFont;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (_components != null))
            _components.Dispose();

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketPlaceForm));
        panelMenu = new Panel();
        buttonOrders = new Button();
        buttonProducts = new Button();
        buttonPersonalAccount = new Button();
        panelLogo = new Panel();
        pictureBoxLogo = new PictureBox();
        panelTitle = new Panel();
        labelTitle = new Label();
        panelDesktop = new Panel();
        panelMenu.SuspendLayout();
        panelLogo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
        panelTitle.SuspendLayout();
        SuspendLayout();
        // 
        // panelMenu
        // 
        panelMenu.BackColor = Color.FromArgb(190, 12, 234);
        panelMenu.Controls.Add(buttonOrders);
        panelMenu.Controls.Add(buttonProducts);
        panelMenu.Controls.Add(buttonPersonalAccount);
        panelMenu.Controls.Add(panelLogo);
        panelMenu.Dock = DockStyle.Left;
        panelMenu.Location = new Point(0, 0);
        panelMenu.Name = "panelMenu";
        panelMenu.Size = new Size(214, 521);
        panelMenu.TabIndex = 0;
        // 
        // buttonOrders
        // 
        buttonOrders.BackColor = Color.FromArgb(190, 12, 234);
        buttonOrders.Dock = DockStyle.Top;
        buttonOrders.FlatAppearance.BorderSize = 0;
        buttonOrders.FlatStyle = FlatStyle.Flat;
        buttonOrders.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        buttonOrders.ForeColor = Color.Gainsboro;
        buttonOrders.Image = (Image)resources.GetObject("buttonOrders.Image");
        buttonOrders.ImageAlign = ContentAlignment.MiddleLeft;
        buttonOrders.Location = new Point(0, 165);
        buttonOrders.Name = "buttonOrders";
        buttonOrders.Padding = new Padding(9, 0, 0, 0);
        buttonOrders.Size = new Size(214, 50);
        buttonOrders.TabIndex = 4;
        buttonOrders.Text = "   Заказы";
        buttonOrders.TextAlign = ContentAlignment.MiddleLeft;
        buttonOrders.TextImageRelation = TextImageRelation.ImageBeforeText;
        buttonOrders.UseVisualStyleBackColor = false;
        buttonOrders.Click += BtnOrder_Click;
        // 
        // buttonProducts
        // 
        buttonProducts.BackColor = Color.FromArgb(190, 12, 234);
        buttonProducts.Dock = DockStyle.Top;
        buttonProducts.FlatAppearance.BorderSize = 0;
        buttonProducts.FlatStyle = FlatStyle.Flat;
        buttonProducts.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        buttonProducts.ForeColor = Color.Gainsboro;
        buttonProducts.Image = (Image)resources.GetObject("buttonProducts.Image");
        buttonProducts.ImageAlign = ContentAlignment.MiddleLeft;
        buttonProducts.Location = new Point(0, 115);
        buttonProducts.Name = "buttonProducts";
        buttonProducts.Padding = new Padding(9, 0, 0, 0);
        buttonProducts.Size = new Size(214, 50);
        buttonProducts.TabIndex = 3;
        buttonProducts.Text = "   Продукты";
        buttonProducts.TextAlign = ContentAlignment.MiddleLeft;
        buttonProducts.TextImageRelation = TextImageRelation.ImageBeforeText;
        buttonProducts.UseVisualStyleBackColor = false;
        buttonProducts.Click += BtnProducts_Click;
        // 
        // buttonPersonalAccount
        // 
        buttonPersonalAccount.BackColor = Color.FromArgb(190, 12, 234);
        buttonPersonalAccount.Dock = DockStyle.Top;
        buttonPersonalAccount.FlatAppearance.BorderSize = 0;
        buttonPersonalAccount.FlatStyle = FlatStyle.Flat;
        buttonPersonalAccount.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        buttonPersonalAccount.ForeColor = Color.Gainsboro;
        buttonPersonalAccount.Image = (Image)resources.GetObject("buttonPersonalAccount.Image");
        buttonPersonalAccount.ImageAlign = ContentAlignment.MiddleLeft;
        buttonPersonalAccount.Location = new Point(0, 65);
        buttonPersonalAccount.Name = "buttonPersonalAccount";
        buttonPersonalAccount.Padding = new Padding(9, 0, 0, 0);
        buttonPersonalAccount.Size = new Size(214, 50);
        buttonPersonalAccount.TabIndex = 2;
        buttonPersonalAccount.Text = "   Личный кабинет";
        buttonPersonalAccount.TextAlign = ContentAlignment.MiddleLeft;
        buttonPersonalAccount.TextImageRelation = TextImageRelation.ImageBeforeText;
        buttonPersonalAccount.UseVisualStyleBackColor = false;
        buttonPersonalAccount.Click += BtnPersonalAccount_Click;
        // 
        // panelLogo
        // 
        panelLogo.BackColor = Color.FromArgb(229, 41, 229);
        panelLogo.Controls.Add(pictureBoxLogo);
        panelLogo.Dock = DockStyle.Top;
        panelLogo.ForeColor = Color.White;
        panelLogo.Location = new Point(0, 0);
        panelLogo.Name = "panelLogo";
        panelLogo.Size = new Size(214, 65);
        panelLogo.TabIndex = 1;
        // 
        // pictureBoxLogo
        // 
        pictureBoxLogo.BackColor = Color.FromArgb(229, 41, 229);
        pictureBoxLogo.BackgroundImageLayout = ImageLayout.Center;
        pictureBoxLogo.Dock = DockStyle.Fill;
        pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
        pictureBoxLogo.Location = new Point(0, 0);
        pictureBoxLogo.Name = "pictureBoxLogo";
        pictureBoxLogo.Size = new Size(214, 65);
        pictureBoxLogo.SizeMode = PictureBoxSizeMode.CenterImage;
        pictureBoxLogo.TabIndex = 0;
        pictureBoxLogo.TabStop = false;
        // 
        // panelTitle
        // 
        panelTitle.BackColor = Color.FromArgb(237, 16, 134);
        panelTitle.Controls.Add(labelTitle);
        panelTitle.Dock = DockStyle.Top;
        panelTitle.Location = new Point(214, 0);
        panelTitle.Name = "panelTitle";
        panelTitle.Size = new Size(767, 65);
        panelTitle.TabIndex = 1;
        // 
        // labelTitle
        // 
        labelTitle.Anchor = AnchorStyles.None;
        labelTitle.AutoSize = true;
        labelTitle.Font = new Font("Dubai Medium", 15F, FontStyle.Regular, GraphicsUnit.Point);
        labelTitle.ForeColor = Color.Black;
        labelTitle.Location = new Point(339, 18);
        labelTitle.Name = "labelTitle";
        labelTitle.Size = new Size(108, 34);
        labelTitle.TabIndex = 0;
        labelTitle.Text = "Главная";
        // 
        // panelDesktop
        // 
        panelDesktop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        panelDesktop.Location = new Point(214, 65);
        panelDesktop.Name = "panelDesktop";
        panelDesktop.Size = new Size(767, 456);
        panelDesktop.TabIndex = 2;
        // 
        // MarketPlaceForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(981, 521);
        Controls.Add(panelDesktop);
        Controls.Add(panelTitle);
        Controls.Add(panelMenu);
        ForeColor = SystemColors.ControlText;
        Name = "MarketPlaceForm";
        Text = "Form1";
        panelMenu.ResumeLayout(false);
        panelLogo.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
        panelTitle.ResumeLayout(false);
        panelTitle.PerformLayout();
        ResumeLayout(false);
    }
    #endregion

    private Panel panelMenu;
    private Button buttonPersonalAccount;
    private Panel panelLogo;
    private Button buttonProducts;
    private Button buttonOrders;
    private Panel panelTitle;
    private Label labelTitle;
    private PictureBox pictureBoxLogo;
    private Windows.Controls.CustomProgressBar.OnlineStoreProgressBar progressBar;
    private Panel panelDesktop;
}