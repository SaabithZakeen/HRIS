using HRIS.Data.Models;
using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRIS.Areas.Admin.Models
{
    public class DependantsViewModel
    {
        [Key]
        public int DependantId { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string Nic { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public int Telephone { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

    }
}