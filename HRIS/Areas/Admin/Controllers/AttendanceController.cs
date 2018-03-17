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
            var attendance = db.Attendance.Where(m => m.Status == true).ToList();

            var attendanceList = new List<AttendanceViewModel>();
            foreach (var item in attendance)
            {
                var attendanceVm = new AttendanceViewModel();
                attendanceVm.AttendanceId = item.AttendanceId;
                attendanceVm.EmployeeId = item.EmployeeId;
                attendanceVm.Date = item.Date;
                attendanceVm.InTime = item.InTime;
                attendanceVm.OutTime = item.OutTime;
                attendanceVm.LateIn = item.LateIn;
                attendanceVm.LateOut = item.LateOut;
                attendanceVm.EarlyIn = item.EarlyIn;
                attendanceVm.EarlyOut = item.EarlyOut;
                attendanceVm.Status = item.Status;

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
                    var attendance = new Attendance();
                    attendance.AttendanceId = vm.AttendanceId; 
                    attendance.EmployeeId = vm.EmployeeId;
                    attendance.Date = vm.Date;
                    attendance.InTime = vm.InTime;
                    attendance.OutTime = vm.OutTime;
                    attendance.LateIn = vm.LateIn;
                    attendance.LateOut = vm.LateOut;
                    attendance.EarlyIn = vm.EarlyIn;
                    attendance.EarlyOut = vm.EarlyOut;
                    attendance.Status = vm.Status;

                    TryUpdateModel(attendance, new string[] { "AttendanceId, EmployeeId, Date, InTime, OutTime, LateIn, LateOut, EarlyIn, EarlyOut, Status" }); /*column name*/
                    db.Attendance.Add(attendance);
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
            var attendance = db.Attendance.Where(att => att.AttendanceId == AttendanceId).FirstOrDefault();
            var attendanceVm = new AttendanceViewModel();
            attendanceVm.AttendanceId = attendance.AttendanceId;
            attendanceVm.EmployeeId = attendance.EmployeeId;
            attendanceVm.Date = attendance.Date;
            attendanceVm.InTime = attendance.InTime;
            attendanceVm.OutTime = attendance.OutTime;
            attendanceVm.LateIn = attendance.LateIn;
            attendanceVm.LateOut = attendance.LateOut;
            attendanceVm.EarlyIn = attendance.EarlyIn;
            attendanceVm.EarlyOut = attendance.EarlyOut;
            attendanceVm.Status = attendance.Status;


            return View(attendanceVm);
        }

        [HttpPost]
        public ActionResult Edit(AttendanceViewModel attendanceVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var attendance = new Attendance();
                    attendance.AttendanceId = attendanceVm.AttendanceId;
                    attendance.EmployeeId = attendanceVm.EmployeeId;
                    attendance.Date = attendanceVm.Date;
                    attendance.InTime = attendanceVm.InTime;
                    attendance.OutTime = attendanceVm.OutTime;
                    attendance.LateIn = attendanceVm.LateIn;
                    attendance.LateOut = attendanceVm.LateOut;
                    attendance.EarlyIn = attendanceVm.EarlyIn;
                    attendance.EarlyOut = attendanceVm.EarlyOut;
                    attendance.Status = true;

                    TryUpdateModel(attendance, "AttendanceId, EmployeeId, Date, InTime, OutTime, LateIn, LateOut, EarlyIn, EarlyOut, Status");
                    db.Attendance.Add(attendance);
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