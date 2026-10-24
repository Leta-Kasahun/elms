using System;

namespace ELMS.Models
{
    public class LeaveEntitlement
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public int FiscalYear { get; set; }
        public int BaseDays { get; set; }
        public int CarriedOverDays { get; set; }
        public int TenureBonusDays { get; set; }
        public int TotalAllocatedDays => BaseDays + CarriedOverDays + TenureBonusDays;
        public int UsedDays { get; set; }
        public int BalanceDays => TotalAllocatedDays - UsedDays;

        public double UtilizationRate => TotalAllocatedDays > 0
            ? Math.Round(((double)UsedDays / TotalAllocatedDays) * 100, 1)
            : 0;
    }
}
