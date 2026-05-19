namespace HighwayManagementSystem;

partial class ReportForm
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
        lblTotalVehicles = new Label();
        lblTotalToll = new Label();
        lblNote = new Label();
        btnRefresh = new Button();
        btnClose = new Button();
        SuspendLayout();

        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.Location = new Point(40, 25);
        lblTitle.Text = "Highway Report";

        lblTotalVehicles.AutoSize = true;
        lblTotalVehicles.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTotalVehicles.Location = new Point(40, 80);
        lblTotalVehicles.Text = "Total Vehicles: 0";

        lblTotalToll.AutoSize = true;
        lblTotalToll.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTotalToll.Location = new Point(40, 120);
        lblTotalToll.Text = "Total Toll Collected: 0";

        lblNote.AutoSize = true;
        lblNote.Location = new Point(40, 165);
        lblNote.MaximumSize = new Size(380, 0);
        lblNote.Text = "Toll total uses final saved amounts after pass discount (Monthly 50%, VIP/Emergency = 0).";

        btnRefresh.Location = new Point(80, 210);
        btnRefresh.Size = new Size(100, 35);
        btnRefresh.Text = "Refresh";
        btnRefresh.Click += btnRefresh_Click;

        btnClose.Location = new Point(220, 210);
        btnClose.Size = new Size(100, 35);
        btnClose.Text = "Close";
        btnClose.Click += btnClose_Click;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(420, 270);
        Controls.Add(btnClose);
        Controls.Add(btnRefresh);
        Controls.Add(lblNote);
        Controls.Add(lblTotalToll);
        Controls.Add(lblTotalVehicles);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "ReportForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Report";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle;
    private Label lblTotalVehicles;
    private Label lblTotalToll;
    private Label lblNote;
    private Button btnRefresh;
    private Button btnClose;
}
