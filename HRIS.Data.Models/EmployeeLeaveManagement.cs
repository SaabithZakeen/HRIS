using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Models
{
    public class EmployeeLeaveManagement
    {
        public int Id { get; set; }

        public int SupervisorId { get; set; }

        public int EmployeeId { get; set; }

        public int LeaveType { get; set; }

        public int IsApproved { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Status { get; set; }

        public string LeaveTypeName { get; set; }
    }
}
