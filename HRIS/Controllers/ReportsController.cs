using HRIS.Areas.Admin.Models;
using HRIS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS.Controllers
{
    public class ReportsController : Controller
    {
        private HrisContext db = new HrisContext();

        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LeaveResults()
        {
            var employeeleavemanagement = db.EmployeeLeaveManagement.Where(m => m.Status == true && m.EmployeeId == MvcApplication.CurruntEmployeeId).ToList();

            var employeeleavemanagementList = new List<EmployeeLeaveManagementViewModel>();
            foreach (var item in employeeleavemanagement)
            {
                var supervisorId = db.SupervisorSubordinateMap.Where(emp => emp.SubordinateId == MvcApplication.CurruntEmployeeId).FirstOrDefault().SupervisorId;
                var SuperVisorName = db.Employee.Where(emp => emp.IsSupervisor == true && emp.Id == supervisorId).FirstOrDefault().EmployeeNameWithInitials;
                var employeeleavemanagementVm = new EmployeeLeaveManagementViewModel();
                employeeleavemanagementVm.Id = item.Id;
                employeeleavemanagementVm.SupervisorId = item.SupervisorId;
                employeeleavemanagementVm.SupervisorName = SuperVisorName;
                employeeleavemanagementVm.EmployeeId = item.EmployeeId;
                employeeleavemanagementVm.LeaveTypeId = item.LeaveType;
                employeeleavemanagementVm.LeaveTypeName = db.LeaveType.Where(lv => lv.LeaveId == item.LeaveType).FirstOrDefault().LeaveTypeName;
                employeeleavemanagementVm.IsApproved = item.IsApproved;
                employeeleavemanagementVm.StartDate = item.StartDate;
                employeeleavemanagementVm.EndDate = item.EndDate;
                employeeleavemanagementVm.Status = item.Status;
                var approved = String.Empty;
                if (item.IsApproved == 0)
                    approved = "Pending";

                if (item.IsApproved == 1)
                    approved = "Approved";

                if (item.IsApproved == 2)
                    approved = "Cancelled";

                employeeleavemanagementVm.IsApprovedStatus = approved;

                employeeleavemanagementList.Add(employeeleavemanagementVm);
            }

            return View(employeeleavemanagementList);
        }

        public ActionResult SubordinateLeaveResults()
        {
            var employeeleavemanagement = db.EmployeeLeaveManagement.Where(m => m.Status == true && m.SupervisorId == MvcApplication.CurruntEmployeeId).ToList();

            var employeeleavemanagementList = new List<EmployeeLeaveManagementViewModel>();
            foreach (var item in employeeleavemanagement)
            {
                var supervisorId = db.SupervisorSubordinateMap.Where(emp => emp.SubordinateId == MvcApplication.CurruntEmployeeId).FirstOrDefault().SupervisorId;
                var SuperVisorName = db.Employee.Where(emp => emp.IsSupervisor == true && emp.Id == supervisorId).FirstOrDefault().EmployeeNameWithInitials;
                var employeeleavemanagementVm = new EmployeeLeaveManagementViewModel();
                employeeleavemanagementVm.Id = item.Id;
                employeeleavemanagementVm.SupervisorId = item.SupervisorId;
                employeeleavemanagementVm.SupervisorName = SuperVisorName;
                employeeleavemanagementVm.EmployeeId = item.EmployeeId;
                employeeleavemanagementVm.LeaveTypeId = item.LeaveType;
                employeeleavemanagementVm.LeaveTypeName = db.LeaveType.Where(lv => lv.LeaveId == item.LeaveType).FirstOrDefault().LeaveTypeName;
                employeeleavemanagementVm.IsApproved = item.IsApproved;
                employeeleavemanagementVm.StartDate = item.StartDate;
                employeeleavemanagementVm.EndDate = item.EndDate;
                employeeleavemanagementVm.Status = item.Status;
                var approved = String.Empty;
                if (item.IsApproved == 0)
                    approved = "Pending";

                if (item.IsApproved == 1)
                    approved = "Approved";

                if (item.IsApproved == 2)
                    approved = "Cancelled";

                employeeleavemanagementVm.IsApprovedStatus = approved;

                employeeleavemanagementList.Add(employeeleavemanagementVm);
            }

            return View(employeeleavemanagementList);
        }
    }
}