using HRIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS.Areas.Admin.Models
{
    public class LeaveEntitlementViewModel
    {
        public int LeaveId { get; set; }

        public int EmployeeId { get; set; }

        public int LeavesAvailable { get; set; }

        public bool Status { get; set; }
    }
}