using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Models
{
    public class Qualification
    {
        [Key]
        public int QualificationId { get; set; }

        public string QualificationType { get; set; }

        public string QualificationName { get; set; }

        public string Institute { get; set; }

        public string QualificationYear { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }
    }
}
