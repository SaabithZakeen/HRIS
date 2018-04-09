using HRIS.Data.Models;
using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRIS.Areas.Admin.Models
{
    public class QualificationViewModel
    {
        [Key]
        public int QualificationId { get; set; }
        
        public string QualificationType { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string Qualification { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string Institute { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string QualificationYear { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string Description { get; set; }

        public int EmployeeId { get; set; }

        public bool Status { get; set; }
    }
}
