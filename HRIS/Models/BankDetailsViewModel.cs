using HRIS.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS.Models
{
    public class BankDetailsViewModel
    {
        [Key]
        public int BankId { get; set; }

        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }

        [Display(Name = "Account No")]
        public int AccountNo { get; set; }

        [Display(Name = "Name Given To Bank")]
        public string NameGivenToBank { get; set; }

        [Display(Name = "Salary")]
        public int Salary { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

    }
}