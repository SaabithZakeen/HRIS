using HRIS.Data.Models;
using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRIS.Areas.Admin.Models
{
    public class ExpertiseProfileViewModel
    {
        [Key]
        public int ExpertiseId { get; set; }

        public string ExpertiseArea { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }
    }
}