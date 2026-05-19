namespace HighwayManagementSystem;

partial class DashboardForm
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
        btnVehicleRecords = new Button();
        btnManageTollPass = new Button();
        btnReport = new Button();
        SuspendLayout();

        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.Location = new Point(60, 25);
        lblTitle.Text = "Highway Management";

        btnVehicleRecords.Location = new Point(70, 75);
        btnVehicleRecords.Size = new Size(260, 40);
        btnVehicleRecords.Text = "Vehicle Record Management";
        btnVehicleRecords.Click += btnVehicleRecords_Click;

        btnManageTollPass.Location = new Point(70, 130);
        btnManageTollPass.Size = new Size(260, 40);
        btnManageTollPass.Text = "Manage Toll Pass";
        btnManageTollPass.Click += btnManageTollPass_Click;

        btnReport.Location = new Point(70, 185);
        btnReport.Size = new Size(260, 40);
        btnReport.Text = "View Report";
        btnReport.Click += btnReport_Click;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(400, 260);
        Controls.Add(btnReport);
        Controls.Add(btnManageTollPass);
        Controls.Add(btnVehicleRecords);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "DashboardForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Dashboard";
        FormClosed += DashboardForm_FormClosed;
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Button btnVehicleRecords;
    private Button btnManageTollPass;
    private Button btnReport;
}
