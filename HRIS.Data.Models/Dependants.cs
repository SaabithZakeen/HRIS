using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Models
{
    public class Dependants
    {
        [Key]
        public int DependantId { get; set; }

        public string FullName { get; set; }

        public DateTime DOB { get; set; }

        public string Nic { get; set; }

        public string Nationality { get; set; }
        
        public string Address { get; set; }
        
        public string Gender { get; set; }

        public int Telephone { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

    }
}
