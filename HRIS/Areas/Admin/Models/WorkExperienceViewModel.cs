using HRIS.Data.Models;
using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HRIS.Areas.Admin.Models
{
    public class WorkExperienceViewModel
    {
        [Key]
        public int WorkExperienceId { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public DateTime ToDate { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public DateTime ConfirmedDate { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string Department { get; set; }

        public string DesignationWhenLeaving { get; set; }

        public string ReasonForLeaving { get; set; }

        public string Achievements { get; set; }

        public string Accountabilities { get; set; }

        public int PeriodServed { get; set; }

        public bool Status { get; set; }
    }
}
