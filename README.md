# Highway Management System

A desktop application for managing highway toll operations: vehicle records, toll passes, and revenue reports. Built with **C#** and **Windows Forms** on **.NET 8**, using **SQLite** for local data storage.

## Features

- **Secure login** — role-based access via admin credentials
- **Vehicle records** — register vehicles with driver details, type, toll amount, and pass type
- **Toll pass management** — create and manage passes with expiry dates
- **Reports** — view vehicle count and total toll collection
- **SQLite database** — auto-created on first run; no manual DB setup required

## Tech Stack

| Layer        | Technology              |
| ------------ | ----------------------- |
| Language     | C#                      |
| UI           | Windows Forms (.NET 8)  |
| Database     | SQLite (`Microsoft.Data.Sqlite`) |
| Platform     | Windows                 |

## Prerequisites

- [**.NET 8 SDK**](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Windows** (WinForms target)
- [Git](https://git-scm.com/) (optional, for cloning)

## Getting Started

### Clone the repository

```bash
git clone https://github.com/moiz-9797/Highway-Management-System.git
cd Highway-Management-System
```

### Build and run

```bash
dotnet restore
dotnet build
dotnet run
```

Or open `HighwayManagementSystem.csproj` in Visual Studio and press **F5**.

### Default login

| Field    | Value          |
| -------- | -------------- |
| Username | `HighwayAdmin` |
| Password | `Highway123`   |

> For production use, replace hard-coded credentials with a proper authentication mechanism.

## Project Structure

```
HighwayManagementSystem/
├── Database/          # SQLite helper and schema setup
├── Forms/             # WinForms UI (Login, Dashboard, Vehicle, Toll Pass, Report)
├── Modules/           # Data models (HighwayRecord, TollPass)
├── Program.cs         # Application entry point
└── HighwayManagementSystem.csproj
```

The SQLite database file (`highway.db`) is created at runtime under the application `Database/` folder and is excluded from version control.

## Author

**Moiz** — [@moiz-9797](https://github.com/moiz-9797)

## License

This project is licensed under the [MIT License](LICENSE).
