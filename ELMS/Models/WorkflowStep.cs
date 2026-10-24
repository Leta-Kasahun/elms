using System;

namespace ELMS.Models
{
    public class WorkflowApprovalStep
    {
        public int Id { get; set; }
        public int LeaveRequestId { get; set; }
        public int StepOrder { get; set; }
        public string StepName { get; set; } = string.Empty;
        public SystemRole RequiredRole { get; set; }
        public int? ApproverUserId { get; set; }
        public string? ApproverName { get; set; }
        public StepStatus Status { get; set; } = StepStatus.PENDING;
        public string? Comments { get; set; }
        public DateTime? ActionDate { get; set; }
    }

    public class ClearanceItem
    {
        public int Id { get; set; }
        public int LeaveRequestId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string DepartmentOrUnit { get; set; } = string.Empty;
        public ClearanceStatus Status { get; set; } = ClearanceStatus.PENDING;
        public int? ClearedByUserId { get; set; }
        public string? ClearedByName { get; set; }
        public DateTime? ClearedDate { get; set; }
    }
}
