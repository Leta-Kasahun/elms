using System;

namespace ELMS.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public string Gender { get; set; } = "Male";
        public bool IsActive { get; set; } = true;

        public string FullName => string.IsNullOrWhiteSpace(MiddleName)
            ? $"{FirstName} {LastName}"
            : $"{FirstName} {MiddleName} {LastName}";

        public int CompletedYearsOfService
        {
            get
            {
                var today = DateTime.Today;
                int years = today.Year - HireDate.Year;
                if (HireDate.Date > today.AddYears(-years)) years--;
                return Math.Max(0, years);
            }
        }

        public int MonthsOfService
        {
            get
            {
                var today = DateTime.Today;
                int months = (today.Year - HireDate.Year) * 12 + today.Month - HireDate.Month;
                if (today.Day < HireDate.Day) months--;
                return Math.Max(0, months);
            }
        }
    }
}
