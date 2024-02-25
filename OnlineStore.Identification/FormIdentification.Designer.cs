namespace OnlineStore.Identification;

public sealed partial class FormIdentification
{
    private System.ComponentModel.IContainer _components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (_components != null))
            _components.Dispose();

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    private void InitializeComponent()
    {
        textBoxLogin = new TextBox();
        textBoxPassword = new TextBox();
        buttonAuthetication = new Button();
        SuspendLayout();
        // 
        // textBoxLogin
        // 
        textBoxLogin.Location = new Point(237, 144);
        textBoxLogin.Name = "textBoxLogin";
        textBoxLogin.Size = new Size(100, 23);
        textBoxLogin.TabIndex = 0;
        // 
        // textBoxPassword
        // 
        textBoxPassword.Location = new Point(216, 206);
        textBoxPassword.Name = "textBoxPassword";
        textBoxPassword.Size = new Size(100, 23);
        textBoxPassword.TabIndex = 1;
        // 
        // buttonAuthetication
        // 
        buttonAuthetication.Location = new Point(321, 336);
        buttonAuthetication.Name = "buttonAuthetication";
        buttonAuthetication.Size = new Size(75, 23);
        buttonAuthetication.TabIndex = 2;
        buttonAuthetication.Text = "button1";
        buttonAuthetication.UseVisualStyleBackColor = true;
        buttonAuthetication.Click += BtnLogin_Click;
        // 
        // FormIdentification
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(buttonAuthetication);
        Controls.Add(textBoxPassword);
        Controls.Add(textBoxLogin);
        Name = "FormIdentification";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }
    #endregion

    private TextBox textBoxLogin;
    private TextBox textBoxPassword;
    private Button buttonAuthetication;
}