using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Data.Models
{
    public class BankDetails
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
