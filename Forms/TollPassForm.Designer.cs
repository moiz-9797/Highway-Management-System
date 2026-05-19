namespace HighwayManagementSystem;

partial class TollPassForm
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
        lblPassType = new Label();
        lblDateInfo = new Label();
        txtVehicleNumber = new TextBox();
        cmbPassType = new ComboBox();
        btnAdd = new Button();
        btnUpdate = new Button();
        btnDelete = new Button();
        btnClear = new Button();
        dgvPasses = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvPasses).BeginInit();
        SuspendLayout();

        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTitle.Location = new Point(20, 15);
        lblTitle.Text = "Toll Pass Management";

        lblVehicleNumber.AutoSize = true;
        lblVehicleNumber.Location = new Point(20, 55);
        lblVehicleNumber.Text = "Vehicle Number:";

        lblPassType.AutoSize = true;
        lblPassType.Location = new Point(20, 90);
        lblPassType.Text = "Pass Type:";

        lblDateInfo.AutoSize = true;
        lblDateInfo.Location = new Point(20, 125);
        lblDateInfo.Text = "Expiry date is generated automatically when you click Add (based on pass type).";

        txtVehicleNumber.Location = new Point(130, 52);
        txtVehicleNumber.Size = new Size(200, 23);

        cmbPassType.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbPassType.Location = new Point(130, 87);
        cmbPassType.Size = new Size(200, 23);
        cmbPassType.Items.AddRange(new object[] { "Normal", "Monthly Pass", "VIP Pass", "Emergency Pass" });
        cmbPassType.SelectedIndex = 0;

        btnAdd.Location = new Point(360, 50);
        btnAdd.Size = new Size(90, 30);
        btnAdd.Text = "Add";
        btnAdd.Click += btnAdd_Click;

        btnUpdate.Location = new Point(460, 50);
        btnUpdate.Size = new Size(90, 30);
        btnUpdate.Text = "Update";
        btnUpdate.Click += btnUpdate_Click;

        btnDelete.Location = new Point(560, 50);
        btnDelete.Size = new Size(90, 30);
        btnDelete.Text = "Delete";
        btnDelete.Click += btnDelete_Click;

        btnClear.Location = new Point(660, 50);
        btnClear.Size = new Size(90, 30);
        btnClear.Text = "Clear";
        btnClear.Click += btnClear_Click;

        dgvPasses.AllowUserToAddRows = false;
        dgvPasses.AllowUserToDeleteRows = false;
        dgvPasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPasses.Location = new Point(20, 160);
        dgvPasses.ReadOnly = true;
        dgvPasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPasses.Size = new Size(730, 330);
        dgvPasses.CellClick += dgvPasses_CellClick;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(770, 510);
        Controls.Add(dgvPasses);
        Controls.Add(btnClear);
        Controls.Add(btnDelete);
        Controls.Add(btnUpdate);
        Controls.Add(btnAdd);
        Controls.Add(cmbPassType);
        Controls.Add(txtVehicleNumber);
        Controls.Add(lblDateInfo);
        Controls.Add(lblPassType);
        Controls.Add(lblVehicleNumber);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "TollPassForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Manage Toll Pass";
        ((System.ComponentModel.ISupportInitialize)dgvPasses).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Label lblVehicleNumber;
    private Label lblPassType;
    private Label lblDateInfo;
    private TextBox txtVehicleNumber;
    private ComboBox cmbPassType;
    private Button btnAdd;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnClear;
    private DataGridView dgvPasses;
}
