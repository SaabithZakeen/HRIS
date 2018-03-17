using HRIS.Data.Models;
using System;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRIS.Models
{
    public class DependantsViewModel
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