using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Models
{
    public class WorkExperience
    {
        [Key]
        public int WorkExperienceId { get; set; }

        public string CompanyName { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime ConfirmedDate { get; set; }

        public string Department { get; set; }

        public string DesignationWhenLeaving { get; set; }

        public string ReasonForLeaving { get; set; }

        public string Achievements { get; set; }

        public string Accountabilities { get; set; }

        public int PeriodServed { get; set; }

        public bool Status { get; set; }
    }
}
