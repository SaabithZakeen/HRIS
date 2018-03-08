using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Models
{
    public class EmergencyContact
    {
        [Key]
        public int EmergencyContactId { get; set; }

        public string FullName { get; set; }

        public string Relationship { get; set; }

        public string Nic { get; set; }

        public string Address { get; set; }

        public int Mobile { get; set; }

        public bool Status { get; set; }
    }
}

