# Employee Leave Management System (ELMS)

A modern, full-featured enterprise desktop application built with **.NET 10** and **Windows Forms**, designed to streamline employee leave applications, multi-tier approval workflows, compliance clearances, quota entitlement tracking, and workforce analytics.

---

## 🚀 Key Features

- **Role-Based Access Control (RBAC)**: Fine-grained permissions and workflows tailored for Administrators, HR Managers, Department Heads, Clearance Officers, and Standard Employees.
- **Leave Request Lifecycle**:
  - Multi-tier approval workflows (Department Head Review & HR Authorization).
  - Clearance workflow for asset and compliance checks prior to long-term leaves.
  - Lifecycle tracking across `DRAFT`, `SUBMITTED`, `UNDER_REVIEW`, `CLEARANCE_IN_PROGRESS`, `APPROVED`, `REJECTED`, and `CANCELLED`.
- **Interactive Visualizations & Analytics**:
  - Custom GDI+ rendered Leave Status breakdown pie chart with interactive hover tooltips and dynamic slice highlighting.
  - Workforce demographic segment meters (Gender diversity, Employment status, and On-Duty availability).
  - Summary KPI cards with real-time metrics.
- **Quota Entitlement & Tenure Bonuses**:
  - Automatic base quota allocation by leave type.
  - Seniority-based tenure bonus computation (+1 day per completed year of service).
  - Carryover balance tracking and utilization rate calculations.
- **Enterprise UI & Tables**:
  - Modern slate-accented visual theme.
  - Generous column layouts with horizontal scrolling and user-resizable columns.
  - Built-in search, status filtering, and department filtering.
  - One-click CSV export utility for reporting and audits.

---

## 🛠️ Technology Stack

- **Framework**: .NET 10 (`net10.0-windows`)
- **UI Platform**: Windows Forms (WinForms) with custom GDI+ graphics rendering
- **Language**: C# 13 (Nullable reference types enabled)
- **Architecture**: Clean layered architecture (Forms, Services, Models, Common)
- **Data Persistence**: In-memory singleton `DataStore` pre-seeded with departments, staff, policies, and workflows

---

## 🏁 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) installed on Windows.

### Running the Application

From the root directory:

```powershell
dotnet run --project ELMS
```

Or navigate to the project directory:

```powershell
cd ELMS
dotnet run
```

### Running the Pre-compiled Binary

```powershell
.\ELMS\bin\Debug\net10.0-windows\ELMS.exe
```

---

## 🔐 Seeded Accounts & Default Credentials

The system comes pre-seeded with test accounts representing every role:

| Role | Username | Password | Access & Responsibilities |
| :--- | :--- | :--- | :--- |
| **System Administrator & HR Director** | `admin` | `admin123` | Full enterprise control, quota generation, user & role management, and final approval step |
| **Department Head (Engineering)** | `marcus` | `pass123` | Approves Engineering department leave requests |
| **Department Head (Finance)** | `elena` | `pass123` | Approves Finance & Accounting leave requests |
| **Department Head (Operations)** | `tariq` | `pass123` | Approves Operations & Logistics leave requests |
| **Department Head (Legal)** | `sarah` | `pass123` | Approves Legal & Compliance leave requests |
| **Clearance Officer** | `david` | `pass123` | Reviews and signs off on asset/equipment handovers |
| **Clearance Officer** | `rachel` | `pass123` | Compliance and library clearance sign-offs |
| **Standard Employee** | `grace` | `pass123` | Submits leave requests, checks personal quota ledger |
| **Standard Employee** | `sophia` | `pass123` | Submits leave requests, checks personal quota ledger |

---

## 📁 Project Structure

```
elms/
├── ELMS/
│   ├── Common/              # Theme definitions, CSV export utilities
│   │   ├── CsvExporter.cs
│   │   └── ElmsTheme.cs
│   ├── Forms/               # Windows Forms UI views and dialogs
│   │   ├── AssignUserRolesDialog.cs
│   │   ├── ChangePasswordDialog.cs
│   │   ├── DepartmentDialog.cs
│   │   ├── EmployeeCreateDialog.cs
│   │   ├── EmployeeDialog.cs
│   │   ├── LeaveRequestDialog.cs
│   │   ├── LeaveTypeDialog.cs
│   │   ├── LoginForm.cs
│   │   ├── MainForm.cs      # Core dashboard, grids, and chart rendering
│   │   ├── ManageRolePermissionsDialog.cs
│   │   ├── RoleDialog.cs
│   │   └── StatusTrackingDialog.cs
│   ├── Models/              # Domain models and enums
│   │   ├── Department.cs
│   │   ├── Employee.cs
│   │   ├── Enums.cs
│   │   ├── LeaveEntitlement.cs
│   │   ├── LeaveRequest.cs
│   │   ├── LeaveType.cs
│   │   ├── Role.cs
│   │   └── User.cs
│   ├── Services/            # Business logic and in-memory datastore
│   │   ├── AuthService.cs
│   │   ├── DataStore.cs     # Seeded departments, employees, entitlements
│   │   ├── EmployeeService.cs
│   │   └── LeaveService.cs  # Validation, clearance, and approval workflow
│   ├── ELMS.csproj          # .NET 10 project definition
│   └── Program.cs           # Application entrypoint
├── ELMS.slnx                # Solution file
└── README.md
```

---

## 📄 License

This project is licensed for internal enterprise management and demonstration purposes.