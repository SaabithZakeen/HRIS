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

        public string Qualification { get; set; }

        public string Institute { get; set; }

        public DateTime QualificationYear { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }
    }
}
