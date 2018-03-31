using HRIS.Areas.Admin.Models;
using HRIS.DAL;
using HRIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS.Areas.Admin.Controllers
{
    public class AttendanceController : Controller
    {
        private HrisContext db = new HrisContext();
        // GET: Admin/Attendance
        public ActionResult Index()
        {
            var attendance = db.EmployeeAttendance.ToList();

            var attendanceList = new List<AttendanceViewModel>();
            foreach (var item in attendance)
            {
                var attendanceVm = new AttendanceViewModel();
                attendanceVm.AttendanceId = 0;
                attendanceVm.EmployeeId = item.EmployeeId;
                attendanceVm.Date = item.Date;
                attendanceVm.InTime = item.InTime;
                attendanceVm.OutTime = item.OutTime;
                attendanceVm.LateIn = item.LateIn;
                attendanceVm.LateOut = item.LateOut;
                attendanceVm.EarlyIn = item.EarlyIn;
                attendanceVm.EarlyOut = item.EarlyOut;
                
                attendanceList.Add(attendanceVm);
            }

            return View(attendanceList);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AttendanceViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var attendance = new EmployeeAttendance();
                    attendance.EmployeeId = 0; 
                    attendance.EmployeeId = vm.EmployeeId;
                    attendance.Date = vm.Date;
                    attendance.InTime = vm.InTime;
                    attendance.OutTime = vm.OutTime;
                    attendance.LateIn = vm.LateIn;
                    attendance.LateOut = vm.LateOut;
                    attendance.EarlyIn = vm.EarlyIn;
                    attendance.EarlyOut = vm.EarlyOut;

                    TryUpdateModel(attendance, new string[] { "AttendanceId, EmployeeId, Date, InTime, OutTime, LateIn, LateOut, EarlyIn, EarlyOut, Status" }); /*column name*/
                    db.EmployeeAttendance.Add(attendance);
                    db.Entry(attendance).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult Edit(int id)
        {
            var attendance = db.EmployeeAttendance.Where(att => att.EmployeeId == 0).FirstOrDefault();
            var attendanceVm = new AttendanceViewModel();
            attendanceVm.AttendanceId = attendance.EmployeeId;
            attendanceVm.EmployeeId = attendance.EmployeeId;
            attendanceVm.Date = attendance.Date;
            attendanceVm.InTime = attendance.InTime;
            attendanceVm.OutTime = attendance.OutTime;
            attendanceVm.LateIn = attendance.LateIn;
            attendanceVm.LateOut = attendance.LateOut;
            attendanceVm.EarlyIn = attendance.EarlyIn;
            attendanceVm.EarlyOut = attendance.EarlyOut;


            return View(attendanceVm);
        }

        [HttpPost]
        public ActionResult Edit(AttendanceViewModel attendanceVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var attendance = new EmployeeAttendance();
                    attendance.EmployeeId = attendanceVm.AttendanceId;
                    attendance.EmployeeId = attendanceVm.EmployeeId;
                    attendance.Date = attendanceVm.Date;
                    attendance.InTime = attendanceVm.InTime;
                    attendance.OutTime = attendanceVm.OutTime;
                    attendance.LateIn = attendanceVm.LateIn;
                    attendance.LateOut = attendanceVm.LateOut;
                    attendance.EarlyIn = attendanceVm.EarlyIn;
                    attendance.EarlyOut = attendanceVm.EarlyOut;

                    TryUpdateModel(attendance, "AttendanceId, EmployeeId, Date, InTime, OutTime, LateIn, LateOut, EarlyIn, EarlyOut, Status");
                    db.EmployeeAttendance.Add(attendance);
                    db.Entry(attendance).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult Edit()
        {
            return View();
        }

        public int AttendanceId { get; set; }
    }
}