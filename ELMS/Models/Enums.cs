namespace ELMS.Models
{
    public enum RequestStatus
    {
        DRAFT,
        SUBMITTED,
        UNDER_REVIEW,
        CLEARANCE_IN_PROGRESS,
        APPROVED,
        REJECTED,
        CANCELLED,
        CLOSED
    }

    public enum SystemRole
    {
        Admin,
        HR_Manager,
        Department_Head,
        Clearance_Officer,
        Employee
    }

    public enum StepStatus
    {
        PENDING,
        APPROVED,
        REJECTED,
        SKIPPED
    }

    public enum ClearanceStatus
    {
        PENDING,
        CLEARED,
        WAIVED
    }
}
