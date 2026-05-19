namespace HighwayManagementSystem;

partial class VehicleForm
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
        lblVehicleNumber = new Label();
        lblDriverName = new Label();
        lblVehicleType = new Label();
        lblTollAmount = new Label();
        lblDetectedPass = new Label();
        lblFinalToll = new Label();
        lblSearch = new Label();
        txtVehicleNumber = new TextBox();
        txtDriverName = new TextBox();
        txtVehicleType = new TextBox();
        txtTollAmount = new TextBox();
        txtSearch = new TextBox();
        btnAdd = new Button();
        btnUpdate = new Button();
        btnDelete = new Button();
        btnSearch = new Button();
        btnClear = new Button();
        dgvRecords = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvRecords).BeginInit();
        SuspendLayout();

        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTitle.Location = new Point(20, 15);
        lblTitle.Text = "Vehicle Record Management";

        lblVehicleNumber.AutoSize = true;
        lblVehicleNumber.Location = new Point(20, 55);
        lblVehicleNumber.Text = "Vehicle Number:";

        lblDriverName.AutoSize = true;
        lblDriverName.Location = new Point(20, 90);
        lblDriverName.Text = "Driver Name:";

        lblVehicleType.AutoSize = true;
        lblVehicleType.Location = new Point(20, 125);
        lblVehicleType.Text = "Vehicle Type:";

        lblTollAmount.AutoSize = true;
        lblTollAmount.Location = new Point(20, 160);
        lblTollAmount.Text = "Toll Amount:";

        lblDetectedPass.AutoSize = true;
        lblDetectedPass.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblDetectedPass.Location = new Point(20, 195);
        lblDetectedPass.Text = "Detected Pass: No Pass (Full Toll)";

        lblFinalToll.AutoSize = true;
        lblFinalToll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblFinalToll.Location = new Point(20, 225);
        lblFinalToll.Text = "Final Toll: 0";

        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(20, 260);
        lblSearch.Text = "Search:";

        txtVehicleNumber.Location = new Point(130, 52);
        txtVehicleNumber.Size = new Size(180, 23);
        txtVehicleNumber.TextChanged += txtVehicleNumber_TextChanged;

        txtDriverName.Location = new Point(130, 87);
        txtDriverName.Size = new Size(180, 23);

        txtVehicleType.Location = new Point(130, 122);
        txtVehicleType.Size = new Size(180, 23);

        txtTollAmount.Location = new Point(130, 157);
        txtTollAmount.Size = new Size(180, 23);
        txtTollAmount.TextChanged += txtTollAmount_TextChanged;

        txtSearch.Location = new Point(130, 257);
        txtSearch.Size = new Size(180, 23);

        btnAdd.Location = new Point(340, 50);
        btnAdd.Size = new Size(90, 30);
        btnAdd.Text = "Add";
        btnAdd.Click += btnAdd_Click;

        btnUpdate.Location = new Point(440, 50);
        btnUpdate.Size = new Size(90, 30);
        btnUpdate.Text = "Update";
        btnUpdate.Click += btnUpdate_Click;

        btnDelete.Location = new Point(540, 50);
        btnDelete.Size = new Size(90, 30);
        btnDelete.Text = "Delete";
        btnDelete.Click += btnDelete_Click;

        btnSearch.Location = new Point(340, 90);
        btnSearch.Size = new Size(90, 30);
        btnSearch.Text = "Search";
        btnSearch.Click += btnSearch_Click;

        btnClear.Location = new Point(440, 90);
        btnClear.Size = new Size(90, 30);
        btnClear.Text = "Clear";
        btnClear.Click += btnClear_Click;

        dgvRecords.AllowUserToAddRows = false;
        dgvRecords.AllowUserToDeleteRows = false;
        dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvRecords.Location = new Point(20, 300);
        dgvRecords.ReadOnly = true;
        dgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvRecords.Size = new Size(760, 270);
        dgvRecords.CellClick += dgvRecords_CellClick;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 590);
        Controls.Add(dgvRecords);
        Controls.Add(btnClear);
        Controls.Add(btnSearch);
        Controls.Add(btnDelete);
        Controls.Add(btnUpdate);
        Controls.Add(btnAdd);
        Controls.Add(txtSearch);
        Controls.Add(lblFinalToll);
        Controls.Add(lblDetectedPass);
        Controls.Add(txtTollAmount);
        Controls.Add(txtVehicleType);
        Controls.Add(txtDriverName);
        Controls.Add(txtVehicleNumber);
        Controls.Add(lblSearch);
        Controls.Add(lblTollAmount);
        Controls.Add(lblVehicleType);
        Controls.Add(lblDriverName);
        Controls.Add(lblVehicleNumber);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "VehicleForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Vehicle Records";
        ((System.ComponentModel.ISupportInitialize)dgvRecords).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Label lblVehicleNumber;
    private Label lblDriverName;
    private Label lblVehicleType;
    private Label lblTollAmount;
    private Label lblDetectedPass;
    private Label lblFinalToll;
    private Label lblSearch;
    private TextBox txtVehicleNumber;
    private TextBox txtDriverName;
    private TextBox txtVehicleType;
    private TextBox txtTollAmount;
    private TextBox txtSearch;
    private Button btnAdd;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnSearch;
    private Button btnClear;
    private DataGridView dgvRecords;
}
