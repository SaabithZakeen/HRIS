using HRIS.Areas.Admin.Models;
using HRIS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {

        private HrisContext db = new HrisContext();
        
        // GET: Admin/Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmployeeAttendance()
        {
            var attendanceList = db.EmployeeAttendance.ToList();
            var vmList = new List<AttendanceViewModel>();
            foreach (var item in attendanceList)
            {
                var attendanceVm = new AttendanceViewModel();

                attendanceVm.AttendanceId = item.EmployeeId;
                attendanceVm.EmployeeName = db.Employee.Where(emp => emp.Id == item.EmployeeId).FirstOrDefault().EmployeeNameWithInitials;

                vmList.Add(attendanceVm);
            }
            return View(vmList);
        }

        public ActionResult EmployeeApprovedLeaves()
        {
            var approvedLeaves = db.EmployeeLeaveManagement.Where(lv => lv.IsApproved == 1).ToList();
            var leaveManageList = new List<EmployeeLeaveManagementViewModel>();
            foreach (var item in approvedLeaves)
            {
                var leaveManage = new EmployeeLeaveManagementViewModel();
                leaveManage.Id = item.Id;
                leaveManage.LeaveTypeName = item.LeaveTypeName;
                leaveManage.EmployeeName = db.Employee.Find(item.EmployeeId).EmployeeFirstName;
                leaveManageList.Add(leaveManage);
            }
            return View(leaveManageList);
        }

        public ActionResult EmployeePendingLeaves()
        {
            var approvedLeaves = db.EmployeeLeaveManagement.Where(lv => lv.IsApproved == 0).ToList();
            var leaveManageList = new List<EmployeeLeaveManagementViewModel>();
            foreach (var item in approvedLeaves)
            {
                var leaveManage = new EmployeeLeaveManagementViewModel();
                leaveManage.Id = item.Id;
                leaveManage.LeaveTypeName = item.LeaveTypeName;
                leaveManage.EmployeeName = db.Employee.Find(item.EmployeeId).EmployeeFirstName;
                leaveManageList.Add(leaveManage);
            }
            return View(leaveManageList);
        }

        public ActionResult EmployeeRejectedLeaves()
        {
            var approvedLeaves = db.EmployeeLeaveManagement.Where(lv => lv.IsApproved == 2).ToList();
            var leaveManageList = new List<EmployeeLeaveManagementViewModel>();
            foreach (var item in approvedLeaves)
            {
                var leaveManage = new EmployeeLeaveManagementViewModel();
                leaveManage.Id = item.Id;
                leaveManage.LeaveTypeName = item.LeaveTypeName;
                leaveManage.EmployeeName = db.Employee.Find(item.EmployeeId).EmployeeFirstName;
                leaveManageList.Add(leaveManage);
            }
            return View(leaveManageList);
        }
    }
}