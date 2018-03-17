using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS.Models
{
    public class DepartmentViewModel
    {
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public bool Status { get; set; }

        public string User { get; set; }
    }
}