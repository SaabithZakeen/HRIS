using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string Date { get; set; }

        public string InTime { get; set; }

        public string OutTime { get; set; }

        public string LateIn { get; set; }

        public string LateOut { get; set; }

        public string EarlyIn { get; set; }

        public string EarlyOut { get; set; }

        public bool Status { get; set; }
    
    }
}
