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
    }
}