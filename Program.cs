namespace HighwayManagementSystem;

// Application entry point - starts with Login form
static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new LoginForm());
    }
}
