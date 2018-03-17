using HRIS.Data.Models;
using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRIS.Areas.Admin.Models
{
    public class AttendanceViewModel
    {
        [Key]
        public int AttendanceId { get; set; }

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
