using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS.Areas.Admin.Models
{
    public class DesignationViewModel
    {
        public int DesignationId { get; set; }

        public string DesignationName { get; set; }
    }
}