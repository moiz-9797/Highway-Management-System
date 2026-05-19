namespace HighwayManagementSystem;

// Dashboard - main menu with navigation buttons
public partial class DashboardForm : Form
{
    public DashboardForm()
    {
        InitializeComponent();
        // Create SQLite database and tables on first load
        DatabaseHelper.CreateDatabase();
    }

    // Button click - open Highway / Vehicle record form
    private void btnVehicleRecords_Click(object sender, EventArgs e)
    {
        VehicleForm vehicleForm = new VehicleForm();
        vehicleForm.ShowDialog();
    }

    // Button click - open Toll Pass management form (second entity)
    private void btnManageTollPass_Click(object sender, EventArgs e)
    {
        TollPassForm tollPassForm = new TollPassForm();
        tollPassForm.ShowDialog();
    }

    // Button click - open report form (vehicle count + total toll)
    private void btnReport_Click(object sender, EventArgs e)
    {
        ReportForm reportForm = new ReportForm();
        reportForm.ShowDialog();
    }

    private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.Exit();
    }
}
