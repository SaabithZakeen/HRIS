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
    public class LeaveTypeController : Controller
    {
        private HrisContext db = new HrisContext();
        // GET: Admin/LeaveType
        public ActionResult Index()
        {
            var leavetype = db.LeaveType.Where(m => m.Status == true).ToList();

            var leavetypeList = new List<LeaveTypeViewModel>();
            foreach (var item in leavetype)
            {
                var leavetypeVm = new LeaveTypeViewModel();
                leavetypeVm.LeaveId = item.LeaveId;
                leavetypeVm.LeaveType = item.LeaveTypeName;
                leavetypeVm.LeaveDays = item.LeaveDays;
                leavetypeVm.Status = item.Status;

                leavetypeList.Add(leavetypeVm);
            }

            return View(leavetypeList);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(LeaveTypeViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LeaveType leavetype = db.LeaveType.Where(lea => lea.LeaveId == vm.LeaveId).FirstOrDefault();
                    leavetype.LeaveTypeName = vm.LeaveType;
                    leavetype.LeaveDays = vm.LeaveDays;
                    leavetype.Status = vm.Status;


                    TryUpdateModel(leavetype, new string[] { "LeaveId, EmployeeId, LeaveType, LeaveDays, Status" }); /*column name*/
                    db.LeaveType.Add(leavetype);
                    db.Entry(leavetype).State = System.Data.Entity.EntityState.Added;
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
            var leavetype = db.LeaveType.Where(con => con.LeaveId == LeaveId).FirstOrDefault();
            var leavetypeVm = new LeaveTypeViewModel();
            leavetypeVm.LeaveId = leavetypeVm.LeaveId;
            leavetypeVm.EmployeeId = leavetypeVm.EmployeeId;
            leavetypeVm.LeaveType = leavetypeVm.LeaveType;
            leavetypeVm.LeaveDays = leavetypeVm.LeaveDays;
            leavetypeVm.Status = leavetypeVm.Status;


            return View(leavetypeVm);
        }

        [HttpPost]
        public ActionResult Edit(LeaveTypeViewModel leavetypeVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var leavetype = new LeaveType();
                    leavetype.LeaveId = leavetypeVm.LeaveId;
                    leavetype.LeaveTypeName = leavetypeVm.LeaveType;
                    leavetype.LeaveDays = leavetypeVm.LeaveDays;
                    leavetype.Status = true;

                    TryUpdateModel(leavetype, "LeaveId, EmployeeId, LeaveType, LeaveDays, Status");
                    db.LeaveType.Add(leavetype);
                    db.Entry(leavetype).State = System.Data.Entity.EntityState.Added;
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

        public int LeaveId { get; set; }
    }
}