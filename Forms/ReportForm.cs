using Microsoft.Data.Sqlite;

namespace HighwayManagementSystem;

// Report form - shows total vehicles and total toll collected (final amounts after discount)
public partial class ReportForm : Form
{
    public ReportForm()
    {
        InitializeComponent();
        LoadReport();
    }

    // Load report data from database when form opens
    private void LoadReport()
    {
        using SqliteConnection conn = DatabaseHelper.GetConnection();

        // SQL query - count total vehicles
        string countSql = "SELECT COUNT(*) FROM HighwayRecords";
        using SqliteCommand countCmd = new SqliteCommand(countSql, conn);
        int totalVehicles = Convert.ToInt32(countCmd.ExecuteScalar());

        // Calculate total toll amount (final saved toll after discount)
        string sumSql = "SELECT IFNULL(SUM(TollAmount), 0) FROM HighwayRecords";
        using SqliteCommand sumCmd = new SqliteCommand(sumSql, conn);
        double totalToll = Convert.ToDouble(sumCmd.ExecuteScalar());

        lblTotalVehicles.Text = "Total Vehicles: " + totalVehicles;
        lblTotalToll.Text = "Total Toll Collected: " + totalToll;
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        LoadReport();
    }
}
