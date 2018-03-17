using HRIS.Data.Models;
using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRIS.Models
{
    public class EmergencyContactViewModel
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