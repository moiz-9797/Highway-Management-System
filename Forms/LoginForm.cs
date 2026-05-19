namespace HighwayManagementSystem;

public partial class LoginForm : Form
{
    // Login details (simple hard-coded check for demo)
    private string correctUser = "HighwayAdmin";
    private string correctPass = "Highway123";

    public LoginForm()
    {
        InitializeComponent();
    }

    // Button click - check username and password
    private void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();

        if (username == correctUser && password == correctPass)
        {
            DashboardForm dashboard = new DashboardForm();
            dashboard.Show();
            this.Hide();
        }
        else
        {
            MessageBox.Show("Invalid username or password!", "Login Failed",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
