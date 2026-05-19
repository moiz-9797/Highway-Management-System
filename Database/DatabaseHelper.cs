using Microsoft.Data.Sqlite;

namespace HighwayManagementSystem;

// Simple SQLite helper - creates database file and tables automatically
public static class DatabaseHelper
{
    // Database file is stored inside the Database folder
    private static string dbFolder = Path.Combine(Application.StartupPath, "Database");
    private static string dbFile = Path.Combine(dbFolder, "highway.db");

    // Connection string used to open SQLite connection
    private static string connectionString = "Data Source=" + dbFile;

    // Create database file and both tables if they do not exist
    public static void CreateDatabase()
    {
        if (!Directory.Exists(dbFolder))
            Directory.CreateDirectory(dbFolder);

        // Open database connection
        using SqliteConnection conn = new SqliteConnection(connectionString);
        conn.Open();

        // SQL query to create HighwayRecords table (first entity)
        string sqlHighway = @"CREATE TABLE IF NOT EXISTS HighwayRecords (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            VehicleNumber TEXT NOT NULL,
            DriverName TEXT NOT NULL,
            VehicleType TEXT NOT NULL,
            TollAmount REAL NOT NULL,
            EntryDate TEXT NOT NULL,
            PassType TEXT NOT NULL
        )";

        using (SqliteCommand cmd = new SqliteCommand(sqlHighway, conn))
        {
            cmd.ExecuteNonQuery();
        }

        // Add PassType column if database was created before this column existed
        try
        {
            string alterSql = "ALTER TABLE HighwayRecords ADD COLUMN PassType TEXT NOT NULL DEFAULT 'No Pass'";
            using SqliteCommand cmd = new SqliteCommand(alterSql, conn);
            cmd.ExecuteNonQuery();
        }
        catch
        {
            // Column already exists - no action needed
        }

        // SQL query to create TollPass table (second entity)
        string sqlTollPass = @"CREATE TABLE IF NOT EXISTS TollPass (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            VehicleNumber TEXT NOT NULL,
            PassType TEXT NOT NULL,
            ExpiryDate TEXT NOT NULL
        )";

        using (SqliteCommand cmd = new SqliteCommand(sqlTollPass, conn))
        {
            cmd.ExecuteNonQuery();
        }
    }

    // Returns an open SQLite connection for CRUD operations
    public static SqliteConnection GetConnection()
    {
        if (!Directory.Exists(dbFolder))
            Directory.CreateDirectory(dbFolder);

        SqliteConnection conn = new SqliteConnection(connectionString);
        conn.Open();
        return conn;
    }
}
