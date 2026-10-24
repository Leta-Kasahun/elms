using System;
using System.Collections.Generic;

namespace ELMS.Models
{
    public class PermissionDefinition
    {
        public string Key { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Module { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public static class PermissionCatalog
    {
        public static readonly List<PermissionDefinition> All = new List<PermissionDefinition>
        {
            new PermissionDefinition
            {
                Key = "all:manage",
                Name = "Full System Administration",
                Module = "Administration",
                Description = "Complete operational governance over all system configuration and workflows"
            },
            new PermissionDefinition
            {
                Key = "roles:manage",
                Name = "Role and Permission Management",
                Module = "Administration",
                Description = "Create, configure, assign, and delete custom user roles and permissions"
            },
            new PermissionDefinition
            {
                Key = "users:read",
                Name = "View User Directory",
                Module = "Administration",
                Description = "Browse user accounts, authentication profiles, and assigned security roles"
            },
            new PermissionDefinition
            {
                Key = "users:write",
                Name = "Manage User Accounts",
                Module = "Administration",
                Description = "Reset user passwords, toggle account status, and assign roles"
            },
            new PermissionDefinition
            {
                Key = "employees:manage",
                Name = "Manage Personnel Profiles",
                Module = "Employee Directory",
                Description = "Maintain employee records, job positions, and service tenure calculations"
            },
            new PermissionDefinition
            {
                Key = "department:read",
                Name = "View Organizational Units",
                Module = "Employee Directory",
                Description = "Access department staffing rosters, headcount stats, and organizational structure"
            },
            new PermissionDefinition
            {
                Key = "leaves:apply",
                Name = "Submit Leave Applications",
                Module = "Leave Management",
                Description = "Submit personal leave requests and initiate draft sabbatical applications"
            },
            new PermissionDefinition
            {
                Key = "leaves:step1_approve",
                Name = "Step 1 Department Endorsement",
                Module = "Leave Management",
                Description = "Authorize initial department-level recommendation for assigned team members"
            },
            new PermissionDefinition
            {
                Key = "leaves:step1_reject",
                Name = "Step 1 Department Rejection",
                Module = "Leave Management",
                Description = "Reject initial stage leave requests with reviewer remarks"
            },
            new PermissionDefinition
            {
                Key = "leaves:approve",
                Name = "Final HR Directorate Approval",
                Module = "Leave Management",
                Description = "Execute final stage approvals and trigger automatic quota ledger deduction"
            },
            new PermissionDefinition
            {
                Key = "leaves:cancel_draft",
                Name = "Cancel Own Requests",
                Module = "Leave Management",
                Description = "Withdraw personal pending or drafted leave applications before approval"
            },
            new PermissionDefinition
            {
                Key = "clearance:manage",
                Name = "Clearance Unit Oversight",
                Module = "Clearance and Quotas",
                Description = "Oversee and audit departmental handover checklists for sabbatical leaves"
            },
            new PermissionDefinition
            {
                Key = "clearance:verify",
                Name = "Department Checklist Verification",
                Module = "Clearance and Quotas",
                Description = "Inspect and certify individual department equipment and property handovers"
            },
            new PermissionDefinition
            {
                Key = "quotas:manage",
                Name = "Manage Leave Quotas",
                Module = "Clearance and Quotas",
                Description = "Allocate base days, carryover days, and tenure bonus calculations"
            },
            new PermissionDefinition
            {
                Key = "quotas:view",
                Name = "View Leave Ledgers",
                Module = "Clearance and Quotas",
                Description = "Inspect real-time quota balances, usage history, and utilization rates"
            },
            new PermissionDefinition
            {
                Key = "reports:export",
                Name = "Export Audit Reports",
                Module = "Clearance and Quotas",
                Description = "Export CSV audit trails, entitlement ledgers, and transaction records"
            },
            new PermissionDefinition
            {
                Key = "self:profile",
                Name = "Employee Self-Service",
                Module = "Self Service",
                Description = "Access personal employment history, leave balances, and profile details"
            }
        };
    }

    public class Role
    {
        public int Id { get; set; }
        public string RoleKey { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsSystemRole { get; set; }
        public bool IsActive { get; set; } = true;
        public int UserCount { get; set; }
        public int PermissionCount => Permissions.Count;
        public List<string> Permissions { get; set; } = new List<string>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}