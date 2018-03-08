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

        public string BankName { get; set; }

        public string BranchName { get; set; }

        public int AccountNo { get; set; }

        public string NameGivenToBank { get; set; }

        public int Salary { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

    }
}