using HRIS.Data.Models;
using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRIS.Areas.Admin.Models
{
    public class LeaveTypeViewModel
    {
        [Key]
        public int LeaveId { get; set; }

        public int EmployeeId { get; set; }

        public string LeaveType { get; set; }

        public int LeaveDays { get; set; }

        public bool Status { get; set; }
    }
}
