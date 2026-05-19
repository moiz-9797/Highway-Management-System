namespace HighwayManagementSystem;

// Simple model class for Highway / Vehicle records (used for learning OOP in viva)
public class HighwayRecord
{
    public int Id { get; set; }
    public string VehicleNumber { get; set; } = "";
    public string DriverName { get; set; } = "";
    public string VehicleType { get; set; } = "";
    public double TollAmount { get; set; }
    public string EntryDate { get; set; } = "";
    public string PassType { get; set; } = "";
}
