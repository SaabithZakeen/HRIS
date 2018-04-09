using HRIS.Data.Models;
using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRIS.Areas.Admin.Models
{
    public class BankDetailsViewModel
    {
        [Key]
        public int BankId { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string BranchName { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public int AccountNo { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string NameGivenToBank { get; set; }

        public int Salary { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

    }
}