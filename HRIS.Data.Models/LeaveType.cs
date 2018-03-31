using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Models
{
    public class LeaveType
    {
        [Key]
        public int LeaveId { get; set; }

        public string LeaveTypeName { get; set; }

        public int LeaveDays { get; set; }       

        public bool Status { get; set; }
    }
}
