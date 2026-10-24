using System;
using System.Linq;
using ELMS.Models;

namespace ELMS.Services
{
    public class AuthService
    {
        public static AuthService Instance { get; } = new AuthService();

        public UserSession? CurrentSession { get; private set; }
        public User? CurrentUser => CurrentSession?.User;
        public Employee? CurrentEmployee => CurrentSession?.Employee;

        public AuthenticationResult Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return new AuthenticationResult { Success = false, Message = "Username and password are required." };
            }

            var user = DataStore.Instance.Users.FirstOrDefault(u =>
                u.Username.Equals(username.Trim(), StringComparison.OrdinalIgnoreCase));

            if (user == null || user.PasswordHash != password)
            {
                return new AuthenticationResult { Success = false, Message = "Invalid username or password." };
            }

            if (!user.IsActive)
            {
                return new AuthenticationResult { Success = false, Message = "User account has been deactivated." };
            }

            Employee? employee = null;
            if (user.EmployeeId.HasValue)
            {
                employee = DataStore.Instance.Employees.FirstOrDefault(e => e.Id == user.EmployeeId.Value);
            }

            CurrentSession = new UserSession
            {
                User = user,
                Employee = employee,
                LoggedInAt = DateTime.Now
            };

            return new AuthenticationResult
            {
                Success = true,
                Message = $"Welcome back, {employee?.FullName ?? user.Username}!",
                Session = CurrentSession
            };
        }

        public bool HasRole(SystemRole role)
        {
            if (CurrentSession == null) return false;
            return CurrentSession.HasRole(role);
        }

        public bool HasAnyRole(params SystemRole[] roles)
        {
            if (CurrentSession == null) return false;
            return roles.Any(r => CurrentSession.HasRole(r));
        }

        public void SignOut()
        {
            CurrentSession = null;
        }
    }
}
