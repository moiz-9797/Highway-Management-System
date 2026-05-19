namespace HighwayManagementSystem;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblUsername = new Label();
        lblPassword = new Label();
        txtUsername = new TextBox();
        txtPassword = new TextBox();
        btnLogin = new Button();
        SuspendLayout();

        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.Location = new Point(70, 25);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(280, 25);
        lblTitle.Text = "Highway Management System";

        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(50, 80);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(63, 15);
        lblUsername.Text = "Username:";

        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(50, 120);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(60, 15);
        lblPassword.Text = "Password:";

        txtUsername.Location = new Point(130, 77);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(220, 23);

        txtPassword.Location = new Point(130, 117);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '*';
        txtPassword.Size = new Size(220, 23);

        btnLogin.Location = new Point(150, 165);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(100, 35);
        btnLogin.Text = "Login";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(420, 230);
        Controls.Add(btnLogin);
        Controls.Add(txtPassword);
        Controls.Add(txtUsername);
        Controls.Add(lblPassword);
        Controls.Add(lblUsername);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Login";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Label lblUsername;
    private Label lblPassword;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private Button btnLogin;
}
