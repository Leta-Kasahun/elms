using System;
using System.Collections.Generic;

namespace ELMS.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public string RequestNumber { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DurationDays => Math.Max(1, (EndDate.Date - StartDate.Date).Days + 1);
        public RequestStatus Status { get; set; } = RequestStatus.DRAFT;
        public string Reason { get; set; } = string.Empty;
        public bool RequiresClearance { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? SubmittedAt { get; set; }

        public List<WorkflowApprovalStep> ApprovalSteps { get; set; } = new List<WorkflowApprovalStep>();
        public List<ClearanceItem> ClearanceChecklist { get; set; } = new List<ClearanceItem>();
    }
}
