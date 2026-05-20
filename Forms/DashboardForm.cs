namespace HighwayManagementSystem;

// Dashboard - main menu with navigation buttons
public partial class DashboardForm : Form
{
    public DashboardForm()
    {
        InitializeComponent();
        // Create SQLite database and tables on first load
        DatabaseHelper.CreateDatabase(); //  automatically create kre ga database ko or tables ko
    }

    // Button click - open Highway / Vehicle record form
    private void btnVehicleRecords_Click(object sender, EventArgs e)
    {
        VehicleForm vehicleForm = new VehicleForm(); // new object bna, new vehicleform bna
        vehicleForm.ShowDialog(); // only use vehicleform, cannot use previous form
    }

    // Button click - open Toll Pass management form (second entity)
    private void btnManageTollPass_Click(object sender, EventArgs e)
    {
        TollPassForm tollPassForm = new TollPassForm(); //new object bna, new tollpassform bna
        tollPassForm.ShowDialog();
    }

    // Button click - open report form (vehicle count + total toll)
    private void btnReport_Click(object sender, EventArgs e)
    {
        ReportForm reportForm = new ReportForm(); //new object bna, new reportform bna
        reportForm.ShowDialog();
    }

    private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e) 
    {
        Application.Exit(); // exsit whole application
    }
}
