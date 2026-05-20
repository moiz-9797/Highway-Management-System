using Microsoft.Data.Sqlite;
using System.Data;

namespace HighwayManagementSystem;

// Highway / Vehicle record form - CRUD, Search, auto pass detection, auto date
public partial class VehicleForm : Form
{
    private int selectedId = 0; // selected row ka id store krta hai, usay autofill krta hai upar textbox may

    
    private string detectedPassType = "No Pass"; // Pass type found from TollPass table (auto detected) 

    public VehicleForm()
    {
        InitializeComponent();
        LoadRecords(); // fetch records from databse and show in data gridview
    }

    // Load all records into DataGridView using SELECT query
    private void LoadRecords()
    {
        using SqliteConnection conn = DatabaseHelper.GetConnection(); // establish connection between sqlite database and data grid view

        string sql = @"SELECT Id, VehicleNumber, DriverName, VehicleType, TollAmount, EntryDate, PassType
                       FROM HighwayRecords";
        using SqliteCommand cmd = new SqliteCommand(sql, conn);
        using SqliteDataReader reader = cmd.ExecuteReader();

        DataTable table = new DataTable();
        table.Load(reader);
        dgvRecords.DataSource = table;

        if (dgvRecords.Columns.Count > 0)
            dgvRecords.Columns["Id"].Visible = false;
    }

    // Check vehicle pass from database when vehicle number is entered
    private void CheckVehiclePass()
    {
        string vehicleNumber = txtVehicleNumber.Text.Trim();

        if (vehicleNumber == "")
        {
            detectedPassType = "No Pass";
            lblDetectedPass.Text = "Detected Pass: No Pass (Full Toll)";
            ApplyDiscount();
            return;
        }

        using SqliteConnection conn = DatabaseHelper.GetConnection();

        string sql = "SELECT PassType FROM TollPass WHERE VehicleNumber = @vnum LIMIT 1";
        using SqliteCommand cmd = new SqliteCommand(sql, conn);
        cmd.Parameters.AddWithValue("@vnum", vehicleNumber);
        object? result = cmd.ExecuteScalar();

        if (result == null)
        {
            detectedPassType = "No Pass";
            lblDetectedPass.Text = "Detected Pass: No Pass (Full Toll)";
        }
        else
        {
            detectedPassType = result.ToString() ?? "No Pass";
            lblDetectedPass.Text = "Detected Pass: " + detectedPassType;
        }

        ApplyDiscount();
    }

    // Apply discount based on auto-detected pass type (simple if-else logic)
    private void ApplyDiscount()
    {
        if (!double.TryParse(txtTollAmount.Text.Trim(), out double tollAmount))
        {
            lblFinalToll.Text = "Final Toll: 0";
            return;
        }

        string passType = detectedPassType;

        if (passType == "Monthly Pass")
        {
            // Apply discount for monthly pass (50% off)
            tollAmount = tollAmount / 2;
        }
        else if (passType == "VIP Pass")
        {
            // Apply VIP discount
            tollAmount = 0;
        }
        else if (passType == "Emergency Pass")
        {
            tollAmount = 0;
        }
        // No pass found or Normal = full toll (no change)

        lblFinalToll.Text = "Final Toll: " + tollAmount;
    }

    // Get final toll amount after discount (used when saving to database)
    private double GetFinalTollAmount()
    {
        double tollAmount = double.Parse(txtTollAmount.Text.Trim());
        string passType = detectedPassType;

        if (passType == "Monthly Pass")
        {
            tollAmount = tollAmount / 2;
        }
        else if (passType == "VIP Pass")
        {
            tollAmount = 0;
        }
        else if (passType == "Emergency Pass")
        {
            tollAmount = 0;
        }

        return tollAmount;
    }

    private bool ValidateFields()
    {
        if (txtVehicleNumber.Text.Trim() == "" ||
            txtDriverName.Text.Trim() == "" ||
            txtVehicleType.Text.Trim() == "" ||
            txtTollAmount.Text.Trim() == "")
        {
            MessageBox.Show("Please fill all fields!", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (!double.TryParse(txtTollAmount.Text.Trim(), out _))
        {
            MessageBox.Show("Toll Amount must be a number!", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    private void ClearFields()
    {
        selectedId = 0;
        txtVehicleNumber.Clear();
        txtDriverName.Clear();
        txtVehicleType.Clear();
        txtTollAmount.Clear();
        txtSearch.Clear();
        detectedPassType = "No Pass";
        lblDetectedPass.Text = "Detected Pass: No Pass (Full Toll)";
        lblFinalToll.Text = "Final Toll: 0";
    }

    // Button click - INSERT new record
    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (!ValidateFields()) return;

        CheckVehiclePass();

        // Save current date automatically
        string entryDate = DateTime.Now.ToString("yyyy-MM-dd");

        using SqliteConnection conn = DatabaseHelper.GetConnection();

        string sql = @"INSERT INTO HighwayRecords (VehicleNumber, DriverName, VehicleType, TollAmount, EntryDate, PassType)
                       VALUES (@vnum, @dname, @vtype, @toll, @edate, @ptype)";
        using SqliteCommand cmd = new SqliteCommand(sql, conn);
        cmd.Parameters.AddWithValue("@vnum", txtVehicleNumber.Text.Trim());
        cmd.Parameters.AddWithValue("@dname", txtDriverName.Text.Trim());
        cmd.Parameters.AddWithValue("@vtype", txtVehicleType.Text.Trim());
        cmd.Parameters.AddWithValue("@toll", GetFinalTollAmount());
        cmd.Parameters.AddWithValue("@edate", entryDate);
        cmd.Parameters.AddWithValue("@ptype", detectedPassType);
        cmd.ExecuteNonQuery();

        MessageBox.Show("Record added successfully!", "Success",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        ClearFields();
        LoadRecords();
    }

    // Button click - UPDATE selected record
    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (selectedId == 0)
        {
            MessageBox.Show("Select a record from the table first!", "Update",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateFields()) return;

        CheckVehiclePass();

        using SqliteConnection conn = DatabaseHelper.GetConnection();

        string sql = @"UPDATE HighwayRecords SET VehicleNumber=@vnum, DriverName=@dname,
                       VehicleType=@vtype, TollAmount=@toll, PassType=@ptype WHERE Id=@id";
        using SqliteCommand cmd = new SqliteCommand(sql, conn);
        cmd.Parameters.AddWithValue("@vnum", txtVehicleNumber.Text.Trim());
        cmd.Parameters.AddWithValue("@dname", txtDriverName.Text.Trim());
        cmd.Parameters.AddWithValue("@vtype", txtVehicleType.Text.Trim());
        cmd.Parameters.AddWithValue("@toll", GetFinalTollAmount());
        cmd.Parameters.AddWithValue("@ptype", detectedPassType);
        cmd.Parameters.AddWithValue("@id", selectedId);
        cmd.ExecuteNonQuery();

        MessageBox.Show("Record updated successfully!", "Success",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        ClearFields();
        LoadRecords();
    }

    // Button click - DELETE selected record
    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (selectedId == 0)
        {
            MessageBox.Show("Select a record from the table first!", "Delete",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult result = MessageBox.Show("Are you sure you want to delete this record?",
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            using SqliteConnection conn = DatabaseHelper.GetConnection();

            string sql = "DELETE FROM HighwayRecords WHERE Id=@id";
            using SqliteCommand cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", selectedId);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Record deleted successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadRecords();
        }
    }

    // Button click - SEARCH records
    private void btnSearch_Click(object sender, EventArgs e)
    {
        string searchText = txtSearch.Text.Trim();
        if (searchText == "")
        {
            LoadRecords();
            return;
        }

        using SqliteConnection conn = DatabaseHelper.GetConnection();

        string sql = @"SELECT Id, VehicleNumber, DriverName, VehicleType, TollAmount, EntryDate, PassType
                       FROM HighwayRecords
                       WHERE VehicleNumber LIKE @s OR DriverName LIKE @s OR VehicleType LIKE @s";
        using SqliteCommand cmd = new SqliteCommand(sql, conn);
        cmd.Parameters.AddWithValue("@s", "%" + searchText + "%");
        using SqliteDataReader reader = cmd.ExecuteReader();

        DataTable table = new DataTable();
        table.Load(reader);
        dgvRecords.DataSource = table;

        if (dgvRecords.Columns.Count > 0)
            dgvRecords.Columns["Id"].Visible = false;
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        ClearFields();
        LoadRecords();
    }

    // When vehicle number changes, auto-detect pass from TollPass table
    private void txtVehicleNumber_TextChanged(object sender, EventArgs e)
    {
        CheckVehiclePass();
    }

    private void txtTollAmount_TextChanged(object sender, EventArgs e)
    {
        ApplyDiscount();
    }

    // Row click - load selected record into text boxes
    private void dgvRecords_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dgvRecords.Rows[e.RowIndex];
            selectedId = Convert.ToInt32(row.Cells["Id"].Value);
            txtVehicleNumber.Text = row.Cells["VehicleNumber"].Value?.ToString();
            txtDriverName.Text = row.Cells["DriverName"].Value?.ToString();
            txtVehicleType.Text = row.Cells["VehicleType"].Value?.ToString();
            txtTollAmount.Text = row.Cells["TollAmount"].Value?.ToString();

            detectedPassType = row.Cells["PassType"].Value?.ToString() ?? "No Pass";
            lblDetectedPass.Text = "Detected Pass: " + detectedPassType;
            ApplyDiscount();
        }
    }
}
