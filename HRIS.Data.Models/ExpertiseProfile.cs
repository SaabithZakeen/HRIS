using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Models
{
    public class ExpertiseProfile
    {
        [Key]
        public int ExpertiseId { get; set; }

        public string ExpertiseArea { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

    }
}
