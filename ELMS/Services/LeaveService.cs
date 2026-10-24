using System;
using System.Collections.Generic;
using System.Linq;
using ELMS.Models;

namespace ELMS.Services
{
    public class LeaveService
    {
        public static LeaveService Instance { get; } = new LeaveService();

        public LeaveEntitlement? GetEntitlement(int empId, int leaveTypeId, int year)
        {
            return DataStore.Instance.Entitlements.FirstOrDefault(e =>
                e.EmployeeId == empId && e.LeaveTypeId == leaveTypeId && e.FiscalYear == year);
        }

        public (bool Success, string Message, LeaveRequest? Request) CreateDraftRequest(
            int employeeId, int leaveTypeId, DateTime startDate, DateTime endDate, string reason)
        {
            if (endDate.Date < startDate.Date)
            {
                return (false, "End date cannot precede start date.", null);
            }

            var emp = DataStore.Instance.Employees.FirstOrDefault(e => e.Id == employeeId);
            if (emp == null || !emp.IsActive)
            {
                return (false, "Invalid or inactive employee selected.", null);
            }

            var lt = DataStore.Instance.LeaveTypes.FirstOrDefault(l => l.Id == leaveTypeId);
            if (lt == null || !lt.IsActive)
            {
                return (false, "Invalid or inactive leave type selected.", null);
            }

            int reqId = DataStore.Instance.GenerateRequestId();
            string reqNumber = $"LR-{DateTime.Now.Year}-{reqId:D3}";

            var req = new LeaveRequest
            {
                Id = reqId,
                RequestNumber = reqNumber,
                EmployeeId = employeeId,
                LeaveTypeId = leaveTypeId,
                StartDate = startDate.Date,
                EndDate = endDate.Date,
                Reason = reason.Trim(),
                Status = RequestStatus.DRAFT,
                RequiresClearance = lt.RequiresClearance || (endDate.Date - startDate.Date).Days + 1 >= 30,
                CreatedAt = DateTime.Now
            };

            DataStore.Instance.LeaveRequests.Add(req);
            DataStore.Instance.NotifyChanged();
            return (true, $"Draft request {reqNumber} saved successfully.", req);
        }

        public (bool Success, string Message) SubmitLeaveRequest(int requestId)
        {
            var req = DataStore.Instance.LeaveRequests.FirstOrDefault(r => r.Id == requestId);
            if (req == null) return (false, "Request not found.");

            if (req.Status != RequestStatus.DRAFT)
            {
                return (false, $"Request cannot be submitted because it is in state '{req.Status}'.");
            }

            var emp = DataStore.Instance.Employees.FirstOrDefault(e => e.Id == req.EmployeeId);
            var lt = DataStore.Instance.LeaveTypes.FirstOrDefault(l => l.Id == req.LeaveTypeId);
            if (emp == null || lt == null) return (false, "Invalid employee or leave type reference.");

            if (lt.MinimumServiceMonths > 0 && emp.MonthsOfService < lt.MinimumServiceMonths)
            {
                return (false, $"Service Tenure Requirement Not Met: Employee has {emp.MonthsOfService} months of service, but {lt.Name} requires at least {lt.MinimumServiceMonths} months.");
            }

            var ent = GetEntitlement(req.EmployeeId, req.LeaveTypeId, req.StartDate.Year);
            if (ent == null)
            {
                ent = new LeaveEntitlement
                {
                    Id = DataStore.Instance.Entitlements.Count + 1,
                    EmployeeId = req.EmployeeId,
                    LeaveTypeId = req.LeaveTypeId,
                    FiscalYear = req.StartDate.Year,
                    BaseDays = lt.EntitlementDays,
                    CarriedOverDays = 0,
                    TenureBonusDays = lt.Code == "ANNUAL" ? emp.CompletedYearsOfService : 0,
                    UsedDays = 0
                };
                DataStore.Instance.Entitlements.Add(ent);
            }

            if (req.DurationDays > ent.BalanceDays)
            {
                return (false, $"Insufficient Leave Balance: Requested {req.DurationDays} days, but available balance is only {ent.BalanceDays} days.");
            }

            req.ApprovalSteps.Clear();
            req.ApprovalSteps.Add(new WorkflowApprovalStep
            {
                Id = 1,
                LeaveRequestId = req.Id,
                StepOrder = 1,
                StepName = "Department Head Review",
                RequiredRole = SystemRole.Department_Head,
                Status = StepStatus.PENDING
            });
            req.ApprovalSteps.Add(new WorkflowApprovalStep
            {
                Id = 2,
                LeaveRequestId = req.Id,
                StepOrder = 2,
                StepName = "HR Director Authorization",
                RequiredRole = SystemRole.HR_Manager,
                Status = StepStatus.PENDING
            });

            if (req.RequiresClearance)
            {
                req.ClearanceChecklist.Clear();
                req.ClearanceChecklist.Add(new ClearanceItem
                {
                    Id = 1,
                    LeaveRequestId = req.Id,
                    ItemName = "Library & Academic Resources Handover",
                    DepartmentOrUnit = "University Library",
                    Status = ClearanceStatus.PENDING
                });
                req.ClearanceChecklist.Add(new ClearanceItem
                {
                    Id = 2,
                    LeaveRequestId = req.Id,
                    ItemName = "Department Hardware & Project Handover",
                    DepartmentOrUnit = emp.DepartmentName,
                    Status = ClearanceStatus.PENDING
                });
            }

            req.Status = RequestStatus.SUBMITTED;
            req.SubmittedAt = DateTime.Now;
            DataStore.Instance.NotifyChanged();
            return (true, $"Request {req.RequestNumber} submitted for sequential approval.");
        }

        public (bool Success, string Message) ProcessApprovalStep(int requestId, int stepId, bool approve, string comments)
        {
            var req = DataStore.Instance.LeaveRequests.FirstOrDefault(r => r.Id == requestId);
            if (req == null) return (false, "Request not found.");

            var step = req.ApprovalSteps.FirstOrDefault(s => s.Id == stepId);
            if (step == null) return (false, "Workflow step not found.");

            var previousSteps = req.ApprovalSteps.Where(s => s.StepOrder < step.StepOrder).ToList();
            if (previousSteps.Any(s => s.Status != StepStatus.APPROVED))
            {
                return (false, "Sequential Workflow Violation: Previous approval step must be approved first.");
            }

            if (!AuthService.Instance.HasRole(step.RequiredRole) && !AuthService.Instance.HasRole(SystemRole.Admin))
            {
                return (false, $"Authorization Denied: Your assigned roles do not include {step.RequiredRole}.");
            }

            step.Status = approve ? StepStatus.APPROVED : StepStatus.REJECTED;
            step.ApproverUserId = AuthService.Instance.CurrentUser?.Id;
            step.ApproverName = AuthService.Instance.CurrentEmployee?.FullName ?? AuthService.Instance.CurrentUser?.Username ?? "System";
            step.Comments = comments;
            step.ActionDate = DateTime.Now;

            if (!approve)
            {
                req.Status = RequestStatus.REJECTED;
            }
            else
            {
                bool allStepsApproved = req.ApprovalSteps.All(s => s.Status == StepStatus.APPROVED);
                if (allStepsApproved)
                {
                    if (req.RequiresClearance && req.ClearanceChecklist.Any(c => c.Status != ClearanceStatus.CLEARED))
                    {
                        req.Status = RequestStatus.CLEARANCE_IN_PROGRESS;
                    }
                    else
                    {
                        req.Status = RequestStatus.APPROVED;
                        DeductLeaveBalance(req);
                    }
                }
                else
                {
                    req.Status = RequestStatus.UNDER_REVIEW;
                }
            }

            DataStore.Instance.NotifyChanged();
            return (true, approve ? "Step approved successfully." : "Request rejected.");
        }

        public (bool Success, string Message) ClearChecklistItem(int requestId, int itemId)
        {
            var req = DataStore.Instance.LeaveRequests.FirstOrDefault(r => r.Id == requestId);
            if (req == null) return (false, "Request not found.");

            var item = req.ClearanceChecklist.FirstOrDefault(i => i.Id == itemId);
            if (item == null) return (false, "Clearance item not found.");

            item.Status = ClearanceStatus.CLEARED;
            item.ClearedDate = DateTime.Now;
            item.ClearedByName = AuthService.Instance.CurrentEmployee?.FullName ?? AuthService.Instance.CurrentUser?.Username ?? "Clearance Officer";

            if (req.ClearanceChecklist.All(c => c.Status == ClearanceStatus.CLEARED))
            {
                req.Status = RequestStatus.APPROVED;
                DeductLeaveBalance(req);
            }

            DataStore.Instance.NotifyChanged();
            return (true, $"'{item.ItemName}' marked as CLEARED.");
        }

        public (bool Success, string Message) CancelLeaveRequest(int requestId)
        {
            var req = DataStore.Instance.LeaveRequests.FirstOrDefault(r => r.Id == requestId);
            if (req == null) return (false, "Request not found.");

            if (req.Status == RequestStatus.APPROVED)
            {
                return (false, "Approved requests cannot be cancelled directly.");
            }

            req.Status = RequestStatus.CANCELLED;
            DataStore.Instance.NotifyChanged();
            return (true, "Request cancelled successfully.");
        }

        public void DeleteDraftRequest(int requestId)
        {
            var req = DataStore.Instance.LeaveRequests.FirstOrDefault(r => r.Id == requestId && r.Status == RequestStatus.DRAFT);
            if (req != null)
            {
                DataStore.Instance.LeaveRequests.Remove(req);
                DataStore.Instance.NotifyChanged();
            }
        }

        private void DeductLeaveBalance(LeaveRequest req)
        {
            var ent = GetEntitlement(req.EmployeeId, req.LeaveTypeId, req.StartDate.Year);
            if (ent != null)
            {
                ent.UsedDays += req.DurationDays;
            }
        }
    }
}
