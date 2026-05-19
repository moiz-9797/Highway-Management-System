using Microsoft.Data.Sqlite;
using System.Data;

namespace HighwayManagementSystem;

// Toll Pass form - CRUD for second entity (expiry date generated automatically)
public partial class TollPassForm : Form
{
    private int selectedId = 0;

    public TollPassForm()
    {
        InitializeComponent();
        LoadPasses();
    }

    // SELECT - load all toll passes into DataGridView
    private void LoadPasses()
    {
        using SqliteConnection conn = DatabaseHelper.GetConnection();

        string sql = "SELECT Id, VehicleNumber, PassType, ExpiryDate FROM TollPass";
        using SqliteCommand cmd = new SqliteCommand(sql, conn);
        using SqliteDataReader reader = cmd.ExecuteReader();

        DataTable table = new DataTable();
        table.Load(reader);
        dgvPasses.DataSource = table;

        if (dgvPasses.Columns.Count > 0)
            dgvPasses.Columns["Id"].Visible = false;
    }

    // Generate expiry date for monthly pass and other pass types (future date only)
    private string GetExpiryDate(string passType)
    {
        DateTime today = DateTime.Now;

        if (passType == "Monthly Pass")
        {
            // Monthly pass expires after 30 days
            return today.AddDays(30).ToString("yyyy-MM-dd");
        }
        else if (passType == "VIP Pass")
        {
            // VIP pass expires after 1 year
            return today.AddYears(1).ToString("yyyy-MM-dd");
        }
        else if (passType == "Emergency Pass")
        {
            // Emergency pass expires after 7 days
            return today.AddDays(7).ToString("yyyy-MM-dd");
        }
        else
        {
            // Normal pass - no expiry needed
            return "No Expiry";
        }
    }

    private bool ValidateFields()
    {
        if (txtVehicleNumber.Text.Trim() == "" || cmbPassType.Text.Trim() == "")
        {
            MessageBox.Show("Please fill all fields!", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    private void ClearFields()
    {
        selectedId = 0;
        txtVehicleNumber.Clear();
        cmbPassType.SelectedIndex = 0;
    }

    // Button click - INSERT new toll pass
    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (!ValidateFields()) return;

        string passType = cmbPassType.Text.Trim();

        // Generate expiry date automatically based on pass type
        string expiryDate = GetExpiryDate(passType);

        using SqliteConnection conn = DatabaseHelper.GetConnection();

        string sql = @"INSERT INTO TollPass (VehicleNumber, PassType, ExpiryDate)
                       VALUES (@vnum, @ptype, @exp)";
        using SqliteCommand cmd = new SqliteCommand(sql, conn);
        cmd.Parameters.AddWithValue("@vnum", txtVehicleNumber.Text.Trim());
        cmd.Parameters.AddWithValue("@ptype", passType);
        cmd.Parameters.AddWithValue("@exp", expiryDate);
        cmd.ExecuteNonQuery();

        MessageBox.Show("Toll pass added successfully!\nExpiry Date: " + expiryDate, "Success",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        ClearFields();
        LoadPasses();
    }

    // Button click - UPDATE selected toll pass
    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (selectedId == 0)
        {
            MessageBox.Show("Select a record from the table first!", "Update",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateFields()) return;

        string passType = cmbPassType.Text.Trim();

        // Generate new expiry date when pass type is updated
        string expiryDate = GetExpiryDate(passType);

        using SqliteConnection conn = DatabaseHelper.GetConnection();

        string sql = @"UPDATE TollPass SET VehicleNumber=@vnum, PassType=@ptype, ExpiryDate=@exp WHERE Id=@id";
        using SqliteCommand cmd = new SqliteCommand(sql, conn);
        cmd.Parameters.AddWithValue("@vnum", txtVehicleNumber.Text.Trim());
        cmd.Parameters.AddWithValue("@ptype", passType);
        cmd.Parameters.AddWithValue("@exp", expiryDate);
        cmd.Parameters.AddWithValue("@id", selectedId);
        cmd.ExecuteNonQuery();

        MessageBox.Show("Toll pass updated successfully!", "Success",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        ClearFields();
        LoadPasses();
    }

    // Button click - DELETE selected toll pass
    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (selectedId == 0)
        {
            MessageBox.Show("Select a record from the table first!", "Delete",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult result = MessageBox.Show("Are you sure you want to delete this toll pass?",
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            using SqliteConnection conn = DatabaseHelper.GetConnection();

            string sql = "DELETE FROM TollPass WHERE Id=@id";
            using SqliteCommand cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", selectedId);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Toll pass deleted successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadPasses();
        }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        ClearFields();
        LoadPasses();
    }

    // Row click - load data into input fields
    private void dgvPasses_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dgvPasses.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["Id"].Value);
            txtVehicleNumber.Text = row.Cells["VehicleNumber"].Value?.ToString();

            string passType = row.Cells["PassType"].Value?.ToString() ?? "Normal";
            int index = cmbPassType.Items.IndexOf(passType);
            cmbPassType.SelectedIndex = index >= 0 ? index : 0;
        }
    }
}
