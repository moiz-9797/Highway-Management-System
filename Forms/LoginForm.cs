namespace HighwayManagementSystem;

public partial class LoginForm : Form
{
    // Login details (simple hard-coded check for demo)
    private string correctUser = "HighwayAdmin"; // idher humne username rakh kr dia hai
    private string correctPass = "Highway123"; // idher humne password rakh dia hai

    public LoginForm()
    {
        InitializeComponent();
    }

    // Button click - check username and password
    private void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim(); // trim = remove extra spaces or white spaces from start and end but centre wali space remain same
        string password = txtPassword.Text.Trim();

        if (username == correctUser && password == correctPass) // username = HighwayAdmin and password = Highway123
        {
            DashboardForm dashboard = new DashboardForm(); // new object bna, new dashboardform bna
            dashboard.Show(); // dashboard show kr dia 
            this.Hide(); // current form = loginform hide ho jaye ga
        }
        else
        {
            MessageBox.Show("Invalid username or password!", "Login Failed",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
