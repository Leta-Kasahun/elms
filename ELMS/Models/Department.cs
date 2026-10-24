namespace ELMS.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int? DepartmentHeadEmployeeId { get; set; }
        public string? DepartmentHeadName { get; set; }
        public int ActiveStaffCount { get; set; }
    }
}
