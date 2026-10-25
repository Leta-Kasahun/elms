using System.Collections.Generic;

namespace ELMS.Models
{
    public class ClearancePolicy
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string RequestType { get; set; } = "Study & Sabbatical Leave";
        public string Description { get; set; } = string.Empty;
        public bool IsSequential { get; set; } = true;
        public bool GenerateClearanceLetter { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public string CreatedAt { get; set; } = "2026-01-15";
        public List<string> RequiredUnits { get; set; } = new List<string>();
        public List<ClearancePolicyStep> Steps { get; set; } = new List<ClearancePolicyStep>();
    }

    public class ClearancePolicyStep
    {
        public int StepOrder { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string ApproverType { get; set; } = "DEPARTMENT_HEAD";
        public string ApproverName { get; set; } = string.Empty;
        public bool IsRequired { get; set; } = true;
    }
}
