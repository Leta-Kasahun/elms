using System;
using System.Collections.Generic;

namespace ELMS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int? EmployeeId { get; set; }
        public List<SystemRole> Roles { get; set; } = new List<SystemRole>();
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class UserSession
    {
        public string SessionId { get; set; } = Guid.NewGuid().ToString();
        public User User { get; set; } = null!;
        public Employee? Employee { get; set; }
        public DateTime LoggedInAt { get; set; } = DateTime.Now;
        public bool IsAuthenticated => User != null && User.IsActive;

        public bool HasRole(SystemRole role)
        {
            if (User == null) return false;
            return User.Roles.Contains(role) || User.Roles.Contains(SystemRole.Admin);
        }
    }

    public class AuthenticationResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public UserSession? Session { get; set; }
    }
}
