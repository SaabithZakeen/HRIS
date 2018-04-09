using HRIS.Data.Models;
using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRIS.Areas.Admin.Models
{
    public class EmployeeLeaveManagementViewModel
    {
        [Key]
        public int Id { get; set; }

        public string LeaveTypeName { get; set; }

        public string EmployeeName { get; set; }

        public int SupervisorId { get; set; }

        public string SupervisorName { get; set; }

        public int EmployeeId { get; set; }

        public int LeaveTypeId { get; set; }

        public int IsApproved { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Status { get; set; }

        public string IsApprovedStatus { get; set; }
    }
}