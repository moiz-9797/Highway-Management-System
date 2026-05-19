namespace HighwayManagementSystem;

// Simple model class for Toll Pass entity (second entity in the project)
public class TollPass
{
    public int Id { get; set; }
    public string VehicleNumber { get; set; } = "";
    public string PassType { get; set; } = "";
    public string ExpiryDate { get; set; } = "";
}
