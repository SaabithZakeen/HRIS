using HRIS.Data.Models;
using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRIS.Areas.Admin.Models
{
    public class EmergencyContactViewModel
    {
        [Key]
        public int EmergencyContactId { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string Relationship { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string Nic { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public int Mobile { get; set; }

        public bool Status { get; set; }
    }
}