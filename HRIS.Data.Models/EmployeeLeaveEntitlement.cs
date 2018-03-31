using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Models
{
    public class EmployeeLeaveEntitlement
    {
        [Key]
        public int Id { get; set; }

        public int LeaveId { get; set; }

        public int EmployeeId { get; set; }

        public int LeavesAvailable { get; set; }

        public bool Status { get; set; }
    }
}