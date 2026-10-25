using System.Collections.Generic;

namespace ELMS.Models
{
    public class ApprovalWorkflowDefinition
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RequestType { get; set; } = "Leave Request";
        public string Description { get; set; } = string.Empty;
        public bool IsSequential { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public string CreatedAt { get; set; } = "2026-01-12";
        public List<ApprovalStepDefinition> Steps { get; set; } = new List<ApprovalStepDefinition>();
    }

    public class ApprovalStepDefinition
    {
        public int StepOrder { get; set; }
        public string StepName { get; set; } = string.Empty;
        public string ApproverType { get; set; } = "ROLE";
        public SystemRole ApproverRole { get; set; }
        public bool IsMandatory { get; set; } = true;
        public bool IsActive { get; set; } = true;
    }
}
