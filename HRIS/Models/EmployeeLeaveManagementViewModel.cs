using HRIS.Data.Models;
using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRIS.Models
{
    public class EmployeeLeaveManagementViewModel
    {
        public int Id { get; set; }

        public int SupervisorId { get; set; }

        public string SupervisorName { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public int LeaveTypeId { get; set; }

        public string LeaveTypeName { get; set; }

        public int IsApproved { get; set; }

        public string IsApprovedStatus { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Status { get; set; }

        public LeaveType LeaveType { get; set; } 
    }
}