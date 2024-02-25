namespace OnlineStore.Registration;

public sealed partial class RegistrationForm
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
        components = new System.ComponentModel.Container();
        errorProvider = new ErrorProvider(components);
        textBoxLogin = new TextBox();
        textBoxPassword = new TextBox();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();
        // 
        // errorProvider
        // 
        errorProvider.ContainerControl = this;
        // 
        // textBoxLogin
        // 
        textBoxLogin.Location = new Point(237, 99);
        textBoxLogin.Name = "textBoxLogin";
        textBoxLogin.Size = new Size(100, 23);
        textBoxLogin.TabIndex = 0;
        // 
        // textBoxPassword
        // 
        textBoxPassword.Location = new Point(350, 214);
        textBoxPassword.Name = "textBoxPassword";
        textBoxPassword.Size = new Size(100, 23);
        textBoxPassword.TabIndex = 1;
        // 
        // RegistrationForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(textBoxPassword);
        Controls.Add(textBoxLogin);
        Name = "RegistrationForm";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
    #endregion

    private ErrorProvider errorProvider;
    private System.ComponentModel.IContainer components;
    private TextBox textBoxLogin;
    private TextBox textBoxPassword;
}