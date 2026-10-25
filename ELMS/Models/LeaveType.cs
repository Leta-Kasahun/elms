namespace ELMS.Models
{
    public class LeaveType
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int EntitlementDays { get; set; }
        public int MinimumServiceMonths { get; set; }
        public bool RequiresClearance { get; set; }
        public bool RequiresCertificate { get; set; }
        public bool IsCarryForwardAllowed { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsPaid { get; set; } = true;
        public bool IsTenureBonusEligible { get; set; } = true;
        public int MinimumNoticeDays { get; set; } = 3;
        public int MaxConsecutiveDays { get; set; } = 30;
        public string CreatedAt { get; set; } = "2026-01-10";
    }
}
