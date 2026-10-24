using System;
using System.Collections.Generic;
using System.Linq;
using ELMS.Models;

namespace ELMS.Services
{
    public class EmployeeService
    {
        public static EmployeeService Instance { get; } = new EmployeeService();

        public (bool Success, string Message) ResetPassword(int userId, string newPassword)
        {
            var user = DataStore.Instance.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return (false, "User account not found.");

            user.PasswordHash = newPassword;
            DataStore.Instance.NotifyChanged();
            return (true, $"Password for user '{user.Username}' reset successfully.");
        }

        public (bool Success, string Message) UpdateUserRoles(int userId, List<SystemRole> roles)
        {
            var user = DataStore.Instance.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return (false, "User account not found.");

            user.Roles = roles;
            DataStore.Instance.NotifyChanged();
            return (true, $"Roles updated for user '{user.Username}'.");
        }

        public (bool Success, string Message) ToggleEmployeeStatus(int employeeId)
        {
            var emp = DataStore.Instance.Employees.FirstOrDefault(e => e.Id == employeeId);
            if (emp == null) return (false, "Employee not found.");

            emp.IsActive = !emp.IsActive;
            var user = DataStore.Instance.Users.FirstOrDefault(u => u.EmployeeId == employeeId);
            if (user != null) user.IsActive = emp.IsActive;

            DataStore.Instance.NotifyChanged();
            return (true, $"Employee '{emp.FullName}' is now {(emp.IsActive ? "ACTIVE" : "INACTIVE")}.");
        }

        public (bool Success, string Message) DeleteEmployee(int employeeId)
        {
            var emp = DataStore.Instance.Employees.FirstOrDefault(e => e.Id == employeeId);
            if (emp == null) return (false, "Employee not found.");

            if (AuthService.Instance.CurrentUser?.EmployeeId == employeeId)
            {
                return (false, "You cannot delete your own active administrator account.");
            }

            DataStore.Instance.Employees.Remove(emp);
            var user = DataStore.Instance.Users.FirstOrDefault(u => u.EmployeeId == employeeId);
            if (user != null) DataStore.Instance.Users.Remove(user);

            DataStore.Instance.Entitlements.RemoveAll(le => le.EmployeeId == employeeId);
            DataStore.Instance.LeaveRequests.RemoveAll(lr => lr.EmployeeId == employeeId);

            DataStore.Instance.NotifyChanged();
            return (true, $"Employee '{emp.FullName}' ({emp.EmployeeCode}) was permanently deleted.");
        }
    }
}