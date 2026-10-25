using System;
using System.Collections.Generic;
using System.Linq;
using ELMS.Models;

namespace ELMS.Services
{
    public class DataStore
    {
        public static DataStore Instance { get; } = new DataStore();
        public event EventHandler? DataChanged;

        public List<Department> Departments { get; } = new List<Department>();
        public List<Employee> Employees { get; } = new List<Employee>();
        public List<User> Users { get; } = new List<User>();
        public List<LeaveType> LeaveTypes { get; } = new List<LeaveType>();
        public List<LeaveEntitlement> Entitlements { get; } = new List<LeaveEntitlement>();
        public List<LeaveRequest> LeaveRequests { get; } = new List<LeaveRequest>();
        public List<Role> Roles { get; } = new List<Role>();
        public List<ClearancePolicy> ClearancePolicies { get; } = new List<ClearancePolicy>();
        public List<ApprovalWorkflowDefinition> ApprovalWorkflows { get; } = new List<ApprovalWorkflowDefinition>();

        private int _nextRequestId = 200;

        public DataStore()
        {
            SeedData();
        }

        public void NotifyChanged()
        {
            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        public int GenerateRequestId() => ++_nextRequestId;

        private void SeedData()
        {
            // -------------------------------------------------------------
            // 1. DEPARTMENTS (5 Operational Units)
            // -------------------------------------------------------------
            var dHR = new Department { Id = 1, Code = "HR", Name = "Human Resources", ActiveStaffCount = 4 };
            var dEng = new Department { Id = 2, Code = "ENG", Name = "Engineering", ActiveStaffCount = 7 };
            var dFin = new Department { Id = 3, Code = "FIN", Name = "Finance & Accounting", ActiveStaffCount = 4 };
            var dOps = new Department { Id = 4, Code = "OPS", Name = "Operations & Logistics", ActiveStaffCount = 3 };
            var dLeg = new Department { Id = 5, Code = "LEG", Name = "Legal & Compliance", ActiveStaffCount = 2 };
            Departments.AddRange(new[] { dHR, dEng, dFin, dOps, dLeg });

            // -------------------------------------------------------------
            // 2. 20 EMPLOYEES (Diverse Tenures, Titles, and Roles)
            // -------------------------------------------------------------
            // 1. Arthur Pendelton (Admin with all permissions)
            var emp1 = new Employee { Id = 1, EmployeeCode = "EMP-001", FirstName = "Arthur", LastName = "Pendelton", Email = "arthur.pendelton@elms.corp", DepartmentId = 1, DepartmentName = "Human Resources", JobTitle = "HR Director", HireDate = new DateTime(2018, 3, 15), IsActive = true };
            // 2. Marcus Vance (Approver: Department Head of Engineering)
            var emp2 = new Employee { Id = 2, EmployeeCode = "EMP-002", FirstName = "Marcus", LastName = "Vance", Email = "marcus.vance@elms.corp", DepartmentId = 2, DepartmentName = "Engineering", JobTitle = "Director of Engineering", HireDate = new DateTime(2019, 7, 1), IsActive = true };
            // 3. Grace Hopper (Senior Engineer)
            var emp3 = new Employee { Id = 3, EmployeeCode = "EMP-003", FirstName = "Grace",
                    Gender = "Female", LastName = "Hopper", Email = "grace.hopper@elms.corp", DepartmentId = 2, DepartmentName = "Engineering", JobTitle = "Senior Software Engineer", HireDate = new DateTime(2021, 2, 10), IsActive = true };
            // 4. David Miller (Clearance Officer)
            var emp4 = new Employee { Id = 4, EmployeeCode = "EMP-004", FirstName = "David", LastName = "Miller", Email = "david.miller@elms.corp", DepartmentId = 1, DepartmentName = "Human Resources", JobTitle = "Compliance & Clearance Officer", HireDate = new DateTime(2020, 11, 20), IsActive = true };
            // 5. Sophia Chen (Engineering)
            var emp5 = new Employee { Id = 5, EmployeeCode = "EMP-005", FirstName = "Sophia",
                    Gender = "Female", LastName = "Chen", Email = "sophia.chen@elms.corp", DepartmentId = 2, DepartmentName = "Engineering", JobTitle = "Principal Cloud Architect", HireDate = new DateTime(2020, 4, 12), IsActive = true };
            // 6. Elena Rostova (Approver: Department Head of Finance)
            var emp6 = new Employee { Id = 6, EmployeeCode = "EMP-006", FirstName = "Elena",
                    Gender = "Female", LastName = "Rostova", Email = "elena.rostova@elms.corp", DepartmentId = 3, DepartmentName = "Finance & Accounting", JobTitle = "Chief Financial Officer", HireDate = new DateTime(2017, 9, 1), IsActive = true };
            // 7. Liam O'Connor (Finance)
            var emp7 = new Employee { Id = 7, EmployeeCode = "EMP-007", FirstName = "Liam", LastName = "O'Connor", Email = "liam.oconnor@elms.corp", DepartmentId = 3, DepartmentName = "Finance & Accounting", JobTitle = "Senior Payroll Specialist", HireDate = new DateTime(2022, 1, 15), IsActive = true };
            // 8. Amara Okafor (HR Manager)
            var emp8 = new Employee { Id = 8, EmployeeCode = "EMP-008", FirstName = "Amara",
                    Gender = "Female", LastName = "Okafor", Email = "amara.okafor@elms.corp", DepartmentId = 1, DepartmentName = "Human Resources", JobTitle = "Talent Acquisition Manager", HireDate = new DateTime(2021, 8, 1), IsActive = true };
            // 9. Lucas Silva (Engineering)
            var emp9 = new Employee { Id = 9, EmployeeCode = "EMP-009", FirstName = "Lucas", LastName = "Silva", Email = "lucas.silva@elms.corp", DepartmentId = 2, DepartmentName = "Engineering", JobTitle = "DevOps Infrastructure Lead", HireDate = new DateTime(2022, 6, 10), IsActive = true };
            // 10. Tariq Al-Mansoor (Approver: Department Head of Operations)
            var emp10 = new Employee { Id = 10, EmployeeCode = "EMP-010", FirstName = "Tariq", LastName = "Al-Mansoor", Email = "tariq.almansoor@elms.corp", DepartmentId = 4, DepartmentName = "Operations & Logistics", JobTitle = "Operations Director", HireDate = new DateTime(2019, 1, 20), IsActive = true };
            // 11. Chloe Bennett (Operations)
            var emp11 = new Employee { Id = 11, EmployeeCode = "EMP-011", FirstName = "Chloe",
                    Gender = "Female", LastName = "Bennett", Email = "chloe.bennett@elms.corp", DepartmentId = 4, DepartmentName = "Operations & Logistics", JobTitle = "Logistics Coordinator", HireDate = new DateTime(2023, 3, 1), IsActive = true };
            // 12. Ethan Wright (Engineering)
            var emp12 = new Employee { Id = 12, EmployeeCode = "EMP-012", FirstName = "Ethan", LastName = "Wright", Email = "ethan.wright@elms.corp", DepartmentId = 2, DepartmentName = "Engineering", JobTitle = "Full Stack Engineer", HireDate = new DateTime(2023, 9, 15), IsActive = true };
            // 13. Priya Sharma (Finance)
            var emp13 = new Employee { Id = 13, EmployeeCode = "EMP-013", FirstName = "Priya",
                    Gender = "Female", LastName = "Sharma", Email = "priya.sharma@elms.corp", DepartmentId = 3, DepartmentName = "Finance & Accounting", JobTitle = "Financial Analyst", HireDate = new DateTime(2022, 11, 5), IsActive = true };
            // 14. Noah Takahashi (Engineering)
            var emp14 = new Employee { Id = 14, EmployeeCode = "EMP-014", FirstName = "Noah", LastName = "Takahashi", Email = "noah.takahashi@elms.corp", DepartmentId = 2, DepartmentName = "Engineering", JobTitle = "Database Administrator", HireDate = new DateTime(2021, 5, 20), IsActive = true };
            // 15. Sarah Jenkins (Approver: Department Head of Legal)
            var emp15 = new Employee { Id = 15, EmployeeCode = "EMP-015", FirstName = "Sarah",
                    Gender = "Female", LastName = "Jenkins", Email = "sarah.jenkins@elms.corp", DepartmentId = 5, DepartmentName = "Legal & Compliance", JobTitle = "Chief Legal Counsel", HireDate = new DateTime(2018, 10, 10), IsActive = true };
            // 16. Daniel Kim (Legal)
            var emp16 = new Employee { Id = 16, EmployeeCode = "EMP-016", FirstName = "Daniel", LastName = "Kim", Email = "daniel.kim@elms.corp", DepartmentId = 5, DepartmentName = "Legal & Compliance", JobTitle = "Regulatory Compliance Specialist", HireDate = new DateTime(2022, 4, 18), IsActive = true };
            // 17. Isabella Rossi (Operations)
            var emp17 = new Employee { Id = 17, EmployeeCode = "EMP-017", FirstName = "Isabella",
                    Gender = "Female", LastName = "Rossi", Email = "isabella.rossi@elms.corp", DepartmentId = 4, DepartmentName = "Operations & Logistics", JobTitle = "Supply Chain Specialist", HireDate = new DateTime(2023, 1, 10), IsActive = true };
            // 18. Rachel Adams (Clearance Officer)
            var emp18 = new Employee { Id = 18, EmployeeCode = "EMP-018", FirstName = "Rachel",
                    Gender = "Female", LastName = "Adams", Email = "rachel.adams@elms.corp", DepartmentId = 1, DepartmentName = "Human Resources", JobTitle = "Asset & Library Clearance Officer", HireDate = new DateTime(2020, 8, 15), IsActive = true };
            // 19. Benjamin Foster (Engineering)
            var emp19 = new Employee { Id = 19, EmployeeCode = "EMP-019", FirstName = "Benjamin", LastName = "Foster", Email = "benjamin.foster@elms.corp", DepartmentId = 2, DepartmentName = "Engineering", JobTitle = "QA Automation Engineer", HireDate = new DateTime(2024, 2, 1), IsActive = true };
            // 20. Maya Lin (Finance)
            var emp20 = new Employee { Id = 20, EmployeeCode = "EMP-020", FirstName = "Maya",
                    Gender = "Female", LastName = "Lin", Email = "maya.lin@elms.corp", DepartmentId = 3, DepartmentName = "Finance & Accounting", JobTitle = "Accounts Payable Specialist", HireDate = new DateTime(2024, 6, 15), IsActive = true };

            Employees.AddRange(new[]
            {
                emp1, emp2, emp3, emp4, emp5, emp6, emp7, emp8, emp9, emp10,
                emp11, emp12, emp13, emp14, emp15, emp16, emp17, emp18, emp19, emp20
            });

            // Set Department Heads
            dHR.DepartmentHeadEmployeeId = emp1.Id;
            dHR.DepartmentHeadName = emp1.FullName;

            dEng.DepartmentHeadEmployeeId = emp2.Id;
            dEng.DepartmentHeadName = emp2.FullName;

            dFin.DepartmentHeadEmployeeId = emp6.Id;
            dFin.DepartmentHeadName = emp6.FullName;

            dOps.DepartmentHeadEmployeeId = emp10.Id;
            dOps.DepartmentHeadName = emp10.FullName;

            dLeg.DepartmentHeadEmployeeId = emp15.Id;
            dLeg.DepartmentHeadName = emp15.FullName;

            // -------------------------------------------------------------
            // 3. USER ACCOUNTS & SYSTEM ROLES
            // -------------------------------------------------------------
            // Admin (has all permissions: Admin + HR_Manager)
            Users.Add(new User
            {
                Id = 1,
                Username = "admin",
                PasswordHash = "admin123",
                EmployeeId = emp1.Id,
                Roles = new List<SystemRole> { SystemRole.Admin, SystemRole.HR_Manager }
            });

            // Department Heads (Approvers)
            Users.Add(new User
            {
                Id = 2,
                Username = "marcus",
                PasswordHash = "pass123",
                EmployeeId = emp2.Id,
                Roles = new List<SystemRole> { SystemRole.Department_Head }
            });
            Users.Add(new User
            {
                Id = 3,
                Username = "elena",
                PasswordHash = "pass123",
                EmployeeId = emp6.Id,
                Roles = new List<SystemRole> { SystemRole.Department_Head }
            });
            Users.Add(new User
            {
                Id = 4,
                Username = "tariq",
                PasswordHash = "pass123",
                EmployeeId = emp10.Id,
                Roles = new List<SystemRole> { SystemRole.Department_Head }
            });
            Users.Add(new User
            {
                Id = 5,
                Username = "sarah",
                PasswordHash = "pass123",
                EmployeeId = emp15.Id,
                Roles = new List<SystemRole> { SystemRole.Department_Head }
            });

            // Clearance Officers
            Users.Add(new User
            {
                Id = 6,
                Username = "david",
                PasswordHash = "pass123",
                EmployeeId = emp4.Id,
                Roles = new List<SystemRole> { SystemRole.Clearance_Officer }
            });
            Users.Add(new User
            {
                Id = 7,
                Username = "rachel",
                PasswordHash = "pass123",
                EmployeeId = emp18.Id,
                Roles = new List<SystemRole> { SystemRole.Clearance_Officer }
            });

            // Standard Employees
            Users.Add(new User
            {
                Id = 8,
                Username = "grace",
                PasswordHash = "pass123",
                EmployeeId = emp3.Id,
                Roles = new List<SystemRole> { SystemRole.Employee }
            });
            Users.Add(new User
            {
                Id = 9,
                Username = "sophia",
                PasswordHash = "pass123",
                EmployeeId = emp5.Id,
                Roles = new List<SystemRole> { SystemRole.Employee }
            });
            Users.Add(new User
            {
                Id = 10,
                Username = "amara",
                PasswordHash = "pass123",
                EmployeeId = emp8.Id,
                Roles = new List<SystemRole> { SystemRole.HR_Manager }
            });

            // Create users for remaining employees
            int uId = 11;
            foreach (var emp in Employees)
            {
                if (!Users.Any(u => u.EmployeeId == emp.Id))
                {
                    Users.Add(new User
                    {
                        Id = uId++,
                        Username = emp.FirstName.ToLowerInvariant(),
                        PasswordHash = "pass123",
                        EmployeeId = emp.Id,
                        Roles = new List<SystemRole> { SystemRole.Employee }
                    });
                }
            }

            // -------------------------------------------------------------
            // 4. LEAVE TYPES & POLICIES
            // -------------------------------------------------------------
            var ltAnnual = new LeaveType { Id = 1, Code = "ANNUAL", Name = "Annual Vacation Leave", EntitlementDays = 21, MinimumServiceMonths = 6, RequiresClearance = false, RequiresCertificate = false, IsCarryForwardAllowed = true };
            var ltSick = new LeaveType { Id = 2, Code = "SICK", Name = "Medical / Sick Leave", EntitlementDays = 14, MinimumServiceMonths = 0, RequiresClearance = false, RequiresCertificate = true, IsCarryForwardAllowed = false };
            var ltStudy = new LeaveType { Id = 3, Code = "STUDY", Name = "Study & Sabbatical Leave", EntitlementDays = 45, MinimumServiceMonths = 24, RequiresClearance = true, RequiresCertificate = true, IsCarryForwardAllowed = false };
            var ltMaternity = new LeaveType { Id = 4, Code = "MATERNITY", Name = "Maternity / Parental Leave", EntitlementDays = 90, MinimumServiceMonths = 12, RequiresClearance = true, RequiresCertificate = true, IsCarryForwardAllowed = false };
            LeaveTypes.AddRange(new[] { ltAnnual, ltSick, ltStudy, ltMaternity });

            // -------------------------------------------------------------
            // 5. ENTITLEMENTS (Populated for All 20 Employees)
            // -------------------------------------------------------------
            int currentYear = DateTime.Now.Year;
            int entId = 1;
            foreach (var emp in Employees)
            {
                // Annual Leave with tenure bonus (+1 day per year of service)
                Entitlements.Add(new LeaveEntitlement
                {
                    Id = entId++,
                    EmployeeId = emp.Id,
                    LeaveTypeId = ltAnnual.Id,
                    FiscalYear = currentYear,
                    BaseDays = 21,
                    CarriedOverDays = emp.CompletedYearsOfService > 2 ? 3 : 0,
                    TenureBonusDays = emp.CompletedYearsOfService,
                    UsedDays = emp.Id == 3 ? 3 : (emp.Id % 4) * 2
                });

                // Sick Leave
                Entitlements.Add(new LeaveEntitlement
                {
                    Id = entId++,
                    EmployeeId = emp.Id,
                    LeaveTypeId = ltSick.Id,
                    FiscalYear = currentYear,
                    BaseDays = 14,
                    CarriedOverDays = 0,
                    TenureBonusDays = 0,
                    UsedDays = emp.Id % 3
                });

                // Study Leave
                Entitlements.Add(new LeaveEntitlement
                {
                    Id = entId++,
                    EmployeeId = emp.Id,
                    LeaveTypeId = ltStudy.Id,
                    FiscalYear = currentYear,
                    BaseDays = 45,
                    CarriedOverDays = 0,
                    TenureBonusDays = 0,
                    UsedDays = 0
                });
            }

            // -------------------------------------------------------------
            // 6. INITIAL SAMPLE LEAVE REQUESTS
            // -------------------------------------------------------------
            var r1 = new LeaveRequest
            {
                Id = 1,
                RequestNumber = "LR-2026-001",
                EmployeeId = emp3.Id,
                LeaveTypeId = ltAnnual.Id,
                StartDate = DateTime.Today.AddDays(10),
                EndDate = DateTime.Today.AddDays(14),
                Status = RequestStatus.SUBMITTED,
                Reason = "Family vacation and annual personal leave",
                RequiresClearance = false,
                CreatedAt = DateTime.Now.AddDays(-2),
                SubmittedAt = DateTime.Now.AddDays(-2)
            };
            r1.ApprovalSteps.Add(new WorkflowApprovalStep { Id = 1, LeaveRequestId = 1, StepOrder = 1, StepName = "Department Head Review", RequiredRole = SystemRole.Department_Head, Status = StepStatus.PENDING });
            r1.ApprovalSteps.Add(new WorkflowApprovalStep { Id = 2, LeaveRequestId = 1, StepOrder = 2, StepName = "HR Director Authorization", RequiredRole = SystemRole.HR_Manager, Status = StepStatus.PENDING });

            var r2 = new LeaveRequest
            {
                Id = 2,
                RequestNumber = "LR-2026-002",
                EmployeeId = emp3.Id,
                LeaveTypeId = ltStudy.Id,
                StartDate = DateTime.Today.AddDays(25),
                EndDate = DateTime.Today.AddDays(70),
                Status = RequestStatus.CLEARANCE_IN_PROGRESS,
                Reason = "Master of Science in Software Engineering semester coursework",
                RequiresClearance = true,
                CreatedAt = DateTime.Now.AddDays(-10),
                SubmittedAt = DateTime.Now.AddDays(-9)
            };
            r2.ApprovalSteps.Add(new WorkflowApprovalStep { Id = 3, LeaveRequestId = 2, StepOrder = 1, StepName = "Department Head Review", RequiredRole = SystemRole.Department_Head, Status = StepStatus.APPROVED, ApproverName = "Grace Hopper", ActionDate = DateTime.Now.AddDays(-7), Comments = "Approved for academic study semester." });
            r2.ApprovalSteps.Add(new WorkflowApprovalStep { Id = 4, LeaveRequestId = 2, StepOrder = 2, StepName = "HR Director Authorization", RequiredRole = SystemRole.HR_Manager, Status = StepStatus.APPROVED, ApproverName = "Jane Smith", ActionDate = DateTime.Now.AddDays(-5), Comments = "Authorized. Sabbatical clearance required before final release." });
            r2.ClearanceChecklist.Add(new ClearanceItem { Id = 1, LeaveRequestId = 2, ItemName = "Library & Academic Resources Handover", DepartmentOrUnit = "University Library", Status = ClearanceStatus.CLEARED, ClearedByName = "Rachel Adams", ClearedDate = DateTime.Now.AddDays(-2) });
            r2.ClearanceChecklist.Add(new ClearanceItem { Id = 2, LeaveRequestId = 2, ItemName = "Department Hardware & Project Handover", DepartmentOrUnit = "Engineering", Status = ClearanceStatus.PENDING });
            r2.ClearanceChecklist.Add(new ClearanceItem { Id = 3, LeaveRequestId = 2, ItemName = "Finance & Sabbatical Grant Clearance", DepartmentOrUnit = "Finance", Status = ClearanceStatus.PENDING });

            var r3 = new LeaveRequest
            {
                Id = 3,
                RequestNumber = "LR-2026-003",
                EmployeeId = emp5.Id,
                LeaveTypeId = ltStudy.Id,
                StartDate = DateTime.Today.AddDays(30),
                EndDate = DateTime.Today.AddDays(90),
                Status = RequestStatus.CLEARANCE_IN_PROGRESS,
                Reason = "Doctoral research sabbatical and conference presentation",
                RequiresClearance = true,
                CreatedAt = DateTime.Now.AddDays(-8),
                SubmittedAt = DateTime.Now.AddDays(-7)
            };
            r3.ApprovalSteps.Add(new WorkflowApprovalStep { Id = 5, LeaveRequestId = 3, StepOrder = 1, StepName = "Department Head Review", RequiredRole = SystemRole.Department_Head, Status = StepStatus.APPROVED, ApproverName = "Grace Hopper", ActionDate = DateTime.Now.AddDays(-6), Comments = "Approved by department." });
            r3.ApprovalSteps.Add(new WorkflowApprovalStep { Id = 6, LeaveRequestId = 3, StepOrder = 2, StepName = "HR Director Authorization", RequiredRole = SystemRole.HR_Manager, Status = StepStatus.APPROVED, ApproverName = "Jane Smith", ActionDate = DateTime.Now.AddDays(-4), Comments = "Authorized for clearance processing." });
            r3.ClearanceChecklist.Add(new ClearanceItem { Id = 4, LeaveRequestId = 3, ItemName = "Library & Academic Resources Handover", DepartmentOrUnit = "University Library", Status = ClearanceStatus.PENDING });
            r3.ClearanceChecklist.Add(new ClearanceItem { Id = 5, LeaveRequestId = 3, ItemName = "Department Hardware & Lab Access Handover", DepartmentOrUnit = "Engineering", Status = ClearanceStatus.PENDING });

            var r4 = new LeaveRequest
            {
                Id = 4,
                RequestNumber = "LR-2026-004",
                EmployeeId = emp4.Id,
                LeaveTypeId = ltStudy.Id,
                StartDate = DateTime.Today.AddDays(-15),
                EndDate = DateTime.Today.AddDays(15),
                Status = RequestStatus.APPROVED,
                Reason = "Professional executive certification program",
                RequiresClearance = true,
                CreatedAt = DateTime.Now.AddDays(-30),
                SubmittedAt = DateTime.Now.AddDays(-28)
            };
            r4.ApprovalSteps.Add(new WorkflowApprovalStep { Id = 7, LeaveRequestId = 4, StepOrder = 1, StepName = "Department Head Review", RequiredRole = SystemRole.Department_Head, Status = StepStatus.APPROVED, ApproverName = "Jane Smith", ActionDate = DateTime.Now.AddDays(-25), Comments = "Approved." });
            r4.ApprovalSteps.Add(new WorkflowApprovalStep { Id = 8, LeaveRequestId = 4, StepOrder = 2, StepName = "HR Director Authorization", RequiredRole = SystemRole.HR_Manager, Status = StepStatus.APPROVED, ApproverName = "Jane Smith", ActionDate = DateTime.Now.AddDays(-22), Comments = "Approved." });
            r4.ClearanceChecklist.Add(new ClearanceItem { Id = 6, LeaveRequestId = 4, ItemName = "Library & Academic Resources Handover", DepartmentOrUnit = "University Library", Status = ClearanceStatus.CLEARED, ClearedByName = "Rachel Adams", ClearedDate = DateTime.Now.AddDays(-20) });
            r4.ClearanceChecklist.Add(new ClearanceItem { Id = 7, LeaveRequestId = 4, ItemName = "HR Compliance & Documentation Clearance", DepartmentOrUnit = "Human Resources", Status = ClearanceStatus.CLEARED, ClearedByName = "David Miller", ClearedDate = DateTime.Now.AddDays(-18) });

            LeaveRequests.AddRange(new[] { r1, r2, r3, r4 });

            // -------------------------------------------------------------
            // 7. CLEARANCE POLICIES CONFIGURATION
            // -------------------------------------------------------------
            ClearancePolicies.Add(new ClearancePolicy
            {
                Id = 1,
                Code = "CLR-STD-01",
                Name = "Study & Sabbatical Leave Clearance Policy",
                RequestType = "Study & Sabbatical Leave",
                Description = "Academic and long-term research sabbatical asset, library, and project handover clearance policy.",
                IsSequential = true,
                GenerateClearanceLetter = true,
                IsActive = true,
                RequiredUnits = new List<string> { "University Library", "Department Hardware & Lab Access", "Finance Office", "HR Compliance" }
            });

            ClearancePolicies.Add(new ClearancePolicy
            {
                Id = 2,
                Code = "CLR-TERM-01",
                Name = "Employee Exit & Termination Clearance Policy",
                RequestType = "Employment Termination",
                Description = "Formal multi-unit separation and asset recovery protocol for exiting personnel.",
                IsSequential = false,
                GenerateClearanceLetter = true,
                IsActive = true,
                RequiredUnits = new List<string> { "IT Asset Return", "Security Access Card", "Finance & Settlement", "Department Head Sign-off" }
            });

            ClearancePolicies.Add(new ClearancePolicy
            {
                Id = 3,
                Code = "CLR-TRANS-01",
                Name = "Inter-Department Transfer Handover Policy",
                RequestType = "Inter-Department Transfer",
                Description = "Departmental handover protocol for employee relocation and position reassignments.",
                IsSequential = true,
                GenerateClearanceLetter = false,
                IsActive = true,
                RequiredUnits = new List<string> { "Current Department Project Handover", "New Department Equipment Issuance" }
            });

            // -------------------------------------------------------------
            // 8. APPROVAL WORKFLOWS CONFIGURATION
            // -------------------------------------------------------------
            var wf1 = new ApprovalWorkflowDefinition
            {
                Id = 1,
                Name = "Standard Leave Request Sequential Approval",
                RequestType = "Annual / Medical Leave",
                Description = "Standard two-step sequential approval chain for day-to-day employee leave requests.",
                IsSequential = true,
                IsActive = true
            };
            wf1.Steps.Add(new ApprovalStepDefinition { StepOrder = 1, StepName = "Department Head Review", ApproverRole = SystemRole.Department_Head, IsMandatory = true });
            wf1.Steps.Add(new ApprovalStepDefinition { StepOrder = 2, StepName = "HR Director Authorization", ApproverRole = SystemRole.HR_Manager, IsMandatory = true });

            var wf2 = new ApprovalWorkflowDefinition
            {
                Id = 2,
                Name = "Academic Sabbatical & Extended Study Workflow",
                RequestType = "Study & Sabbatical Leave",
                Description = "Comprehensive three-step review including departmental, HR, and unit clearance officer validation.",
                IsSequential = true,
                IsActive = true
            };
            wf2.Steps.Add(new ApprovalStepDefinition { StepOrder = 1, StepName = "Department Head Review", ApproverRole = SystemRole.Department_Head, IsMandatory = true });
            wf2.Steps.Add(new ApprovalStepDefinition { StepOrder = 2, StepName = "HR Director Authorization", ApproverRole = SystemRole.HR_Manager, IsMandatory = true });
            wf2.Steps.Add(new ApprovalStepDefinition { StepOrder = 3, StepName = "Clearance Officer Verification", ApproverRole = SystemRole.Clearance_Officer, IsMandatory = true });

            var wf3 = new ApprovalWorkflowDefinition
            {
                Id = 3,
                Name = "Executive & Fast-Track Leave Authorization",
                RequestType = "Executive Leave",
                Description = "Single-step expedited authorization workflow for senior executive personnel.",
                IsSequential = false,
                IsActive = true
            };
            wf3.Steps.Add(new ApprovalStepDefinition { StepOrder = 1, StepName = "HR Executive Sign-off", ApproverRole = SystemRole.HR_Manager, IsMandatory = true });

            ApprovalWorkflows.AddRange(new[] { wf1, wf2, wf3 });
            Roles.AddRange(new[]
            {
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    RoleKey = "ROLE_ADMIN",
                    Description = "Full enterprise administrative governance, role assignment, and workflow configuration",
                    IsSystemRole = true,
                    IsActive = true,
                    UserCount = 1,
                    Permissions = new List<string> { "all:manage", "users:read", "users:write", "roles:manage", "leaves:approve", "clearance:manage" }
                },
                new Role
                {
                    Id = 2,
                    Name = "HR Manager",
                    RoleKey = "ROLE_HR_MANAGER",
                    Description = "Manages personnel records, quota entitlements, and final step approval authorizations",
                    IsSystemRole = true,
                    IsActive = true,
                    UserCount = 2,
                    Permissions = new List<string> { "employees:manage", "quotas:manage", "leaves:approve", "reports:export" }
                },
                new Role
                {
                    Id = 3,
                    Name = "Department Head",
                    RoleKey = "ROLE_DEPT_HEAD",
                    Description = "Reviews and signs off step 1 leave applications for assigned department team members",
                    IsSystemRole = true,
                    IsActive = true,
                    UserCount = 5,
                    Permissions = new List<string> { "department:read", "leaves:step1_approve", "leaves:step1_reject" }
                },
                new Role
                {
                    Id = 4,
                    Name = "Clearance Officer",
                    RoleKey = "ROLE_CLEARANCE",
                    Description = "Validates unit handovers, property clearance checklists, and sabbatical certifications",
                    IsSystemRole = true,
                    IsActive = true,
                    UserCount = 2,
                    Permissions = new List<string> { "clearance:read", "clearance:verify", "clearance:signoff" }
                },
                new Role
                {
                    Id = 5,
                    Name = "Employee",
                    RoleKey = "ROLE_EMPLOYEE",
                    Description = "Standard staff self-service portal access for personal requests, quota tracking, and history",
                    IsSystemRole = true,
                    IsActive = true,
                    UserCount = 20,
                    Permissions = new List<string> { "self:profile", "leaves:apply", "leaves:cancel_draft", "quotas:view" }
                }
            });
        }
    }
}
