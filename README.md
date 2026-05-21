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

- [**.NET 8 SDK**](https://dotnet.microsoft.com/download/dotnet/8.0) (for building from source)
- **Windows 10 or Windows 11** (64-bit recommended)
- [Git](https://git-scm.com/) (optional, for cloning)

## Getting Started

### Clone the repository

```bash
git clone https://github.com/moiz-9797/Highway-Management-System.git
cd Highway-Management-System
```

### Open in Visual Studio

1. Open **`Highway Management System.sln`** from the solution root folder (parent of `HighwayManagementSystem`).
2. Set **HighwayManagementSystem** as the startup project.
3. Press **F5** to build and run.

### Build and run from command line

```bash
cd HighwayManagementSystem
dotnet restore
dotnet build
dotnet run
```

### Default login

| Field    | Value          |
| -------- | -------------- |
| Username | `moiz9797`     |
| Password | `1122334455`   |

> For production use, replace hard-coded credentials with a proper authentication mechanism.

## Project Structure

```
Highway Management sytem Final/
├── Highway Management System.sln    # Open this in Visual Studio
└── HighwayManagementSystem/
    ├── Database/                  # SQLite helper; highway.db created at runtime
    ├── Forms/                     # WinForms UI (Login, Dashboard, Vehicle, Toll Pass, Report)
    ├── Modules/                   # Data models (HighwayRecord, TollPass)
    ├── Program.cs                 # Application entry point
    └── HighwayManagementSystem.csproj
```

The SQLite database file (`highway.db`) is created automatically on first run inside the `Database` folder next to the executable. It is excluded from version control.

---

## Deployment Guide (Run on Another Device)

Use this section when you want to install and run the app on a **different Windows PC** (office PC, client machine, laptop, etc.).

### What you need on the target device

| Requirement | Details |
| ----------- | ------- |
| Operating system | **Windows 10 or 11** (this app does not run on macOS or Linux) |
| .NET runtime | Required only if you use **framework-dependent** publish (see Option B below). Install [.NET 8 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/8.0) (Windows x64). |
| Disk space | About 50–150 MB depending on publish type |
| Admin rights | Not required to run; admin may be needed only to install .NET runtime |

No database server, IIS, or internet connection is required after the app is copied. The app works fully offline.

---

### Option A — Recommended: Self-contained publish (no .NET install on other PC)

The target PC does **not** need .NET installed. You copy one folder and run the `.exe`.

#### Step 1: Publish on your development PC

Open PowerShell or Command Prompt in the `HighwayManagementSystem` folder and run:

```bash
cd HighwayManagementSystem
dotnet publish -c Release -r win-x64 --self-contained true -o ./publish
```

This creates a **`publish`** folder with `HighwayManagementSystem.exe` and all required DLLs.

#### Step 2: Copy to the other device

Copy the entire **`publish`** folder to the other PC using:

- USB drive  
- OneDrive / Google Drive / network share  
- Email (zip the folder first if needed)

Example target location on the other PC:

`C:\HighwayManagementSystem\`

#### Step 3: Run on the other device

1. Open the copied folder.
2. Double-click **`HighwayManagementSystem.exe`**.
3. If Windows SmartScreen appears, click **More info** → **Run anyway** (only if you trust the source).
4. Log in with the default credentials (see [Default login](#default-login)).

On first run, the app creates `Database\highway.db` automatically in the same folder as the `.exe`.

#### Step 4 (optional): Desktop shortcut

- Right-click `HighwayManagementSystem.exe` → **Send to** → **Desktop (create shortcut)**.

---

### Option B: Framework-dependent publish (smaller folder, .NET required on other PC)

Use this if the other PC already has **.NET 8 Desktop Runtime** installed, or you can install it once.

#### Step 1: Publish on your development PC

```bash
cd HighwayManagementSystem
dotnet publish -c Release -r win-x64 --self-contained false -o ./publish
```

The `publish` folder will be smaller but will not include the .NET runtime.

#### Step 2: Install .NET 8 on the other device (one time)

Download and install **.NET Desktop Runtime 8.0 (x64)** from:

https://dotnet.microsoft.com/download/dotnet/8.0

Choose **Desktop Runtime** → **Windows** → **x64**.

#### Step 3: Copy and run

Same as Option A: copy the `publish` folder to the other PC and run `HighwayManagementSystem.exe`.

---

### Option C: Run from source on another device (for developers)

Use this only if the other PC has **Visual Studio** or **.NET 8 SDK** installed.

1. Copy the full project folder (or clone from Git).
2. Open **`Highway Management System.sln`** in Visual Studio.
3. Press **F5**, or run:

   ```bash
   cd HighwayManagementSystem
   dotnet restore
   dotnet run
   ```

---

### Moving existing data to another device

If you already have records on one PC and want the **same data** on another:

1. On the **old PC**, close the application completely.
2. Copy the file:

   `Database\highway.db`

   from the folder where `HighwayManagementSystem.exe` is located (e.g. `bin\Debug\net8.0-windows\` when developing, or your `publish` folder when deployed).
3. On the **new PC**, paste `highway.db` into the `Database` folder next to the new `.exe` (create the `Database` folder if it does not exist).
4. Start the application on the new PC.

> Always close the app before copying `highway.db` to avoid file corruption.

---

### Deployment checklist

| Step | Action |
| ---- | ------ |
| 1 | Publish with `dotnet publish` (Option A or B) |
| 2 | Copy the full `publish` folder to the target PC |
| 3 | Install .NET 8 Desktop Runtime (Option B only) |
| 4 | Run `HighwayManagementSystem.exe` |
| 5 | Confirm login works (`moiz9797` / `1122334455`) |
| 6 | Optionally copy `Database\highway.db` to transfer old data |

---

### Troubleshooting on another device

| Problem | Solution |
| ------- | -------- |
| App does not start; mentions .NET | Install [.NET 8 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/8.0) or republish with **Option A** (`--self-contained true`). |
| Windows blocked the app | Click **More info** → **Run anyway**, or unblock: right-click `.exe` → **Properties** → check **Unblock** → **OK**. |
| Database empty on new PC | Normal on first run. Copy `highway.db` from the old PC if you need existing data (see above). |
| Antivirus quarantines files | Add the `publish` folder to antivirus exclusions, or publish again and copy a fresh folder. |
| Wrong architecture (32-bit PC) | This project targets **win-x64**. For 32-bit Windows, publish with `-r win-x86` instead. |

---

## Author

**Moiz** — [@moiz-9797](https://github.com/moiz-9797)

## License

This project is licensed under the [MIT License](LICENSE).
