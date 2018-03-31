using HRIS.DAL;
using HRIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Web.Security;
using HRIS.Data.Models;

namespace HRIS.Controllers
{
    public class EmployeeLeaveManagementController : Controller
    {
        private HrisContext db = new HrisContext();

        public string SuperVisorName { get; set; }

        // GET: EmployeeLeaveManagement
        public ActionResult Index()
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
                if(item.IsApproved == 0) 
                    approved = "Pending" ;

                if (item.IsApproved == 1)
                    approved = "Approved";

                if (item.IsApproved == 2)
                    approved = "Cancelled";

                employeeleavemanagementVm.IsApprovedStatus = approved;

                employeeleavemanagementList.Add(employeeleavemanagementVm);
            }

            return View(employeeleavemanagementList);
        }

        public ActionResult Add()
        {
            ViewBag.LeaveTypes = new SelectList(from leaveType in db.LeaveType.ToList().Where(c => c.Status == true) select leaveType, "LeaveId", "LeaveTypeName", 0);
            var employeeleavemanagement = new EmployeeLeaveManagementViewModel();

            var supervisorId = db.SupervisorSubordinateMap.Where(emp => emp.SubordinateId == MvcApplication.CurruntEmployeeId).FirstOrDefault().SupervisorId;
            var SuperVisorName = db.Employee.Where(emp => emp.IsSupervisor == true && emp.Id == supervisorId).FirstOrDefault().EmployeeNameWithInitials;
            employeeleavemanagement.SupervisorName = SuperVisorName;
            employeeleavemanagement.StartDate = DateTime.Now;
            employeeleavemanagement.EndDate = DateTime.Now;
            employeeleavemanagement.SupervisorId = supervisorId;

            return View(employeeleavemanagement);
        }

        [HttpPost]
        public ActionResult Add(EmployeeLeaveManagementViewModel employeeleavemanagementVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeLeaveManagement employeeleavemanagement = db.EmployeeLeaveManagement.Where(elm => elm.Id == employeeleavemanagementVm.Id).FirstOrDefault();
                    employeeleavemanagement.SupervisorId = employeeleavemanagementVm.SupervisorId;
                    employeeleavemanagement.EmployeeId = MvcApplication.CurruntEmployeeId;
                    employeeleavemanagement.LeaveType = employeeleavemanagementVm.LeaveType.LeaveId;
                    employeeleavemanagement.IsApproved = 0;
                    employeeleavemanagement.StartDate = employeeleavemanagementVm.StartDate;
                    employeeleavemanagement.EndDate = employeeleavemanagementVm.EndDate;
                    employeeleavemanagement.Status = true;

                    TryUpdateModel(employeeleavemanagement, "Id, SupervisorId, EmployeeId, LeaveType, IsApproved, StartDate, EndDate, Status");
                    db.EmployeeLeaveManagement.Add(employeeleavemanagement);
                    db.Entry(employeeleavemanagement).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult SupervisorIndex()
        {
            var employeeleavemanagement = db.EmployeeLeaveManagement.Where(m => m.Status == true && m.SupervisorId == MvcApplication.CurruntEmployeeId && m.IsApproved == 0).ToList();

            var employeeleavemanagementList = new List<EmployeeLeaveManagementViewModel>();
            foreach (var item in employeeleavemanagement)
            {
                var supervisorId = db.SupervisorSubordinateMap.Where(emp => emp.SupervisorId == MvcApplication.CurruntEmployeeId).FirstOrDefault().SupervisorId;
                var SuperVisorName = db.Employee.Where(emp => emp.IsSupervisor == true && emp.Id == supervisorId).FirstOrDefault().EmployeeNameWithInitials;
                var employeeleavemanagementVm = new EmployeeLeaveManagementViewModel();
                employeeleavemanagementVm.Id = item.Id;
                employeeleavemanagementVm.SupervisorId = item.SupervisorId;
                employeeleavemanagementVm.SupervisorName = SuperVisorName;
                employeeleavemanagementVm.EmployeeId = item.EmployeeId;
                employeeleavemanagementVm.EmployeeName = db.Employee.Where(emp => emp.Id == supervisorId).FirstOrDefault().EmployeeNameWithInitials;
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

        [HttpGet]
        public ActionResult SupervisorEdit(int id)
        {
            var employeeleavemanagement = db.EmployeeLeaveManagement.Where(m =>m.Id == id).FirstOrDefault();

            var supervisorId = db.SupervisorSubordinateMap.Where(emp => emp.SupervisorId == MvcApplication.CurruntEmployeeId).FirstOrDefault().SupervisorId;
            var SuperVisorName = db.Employee.Where(emp => emp.IsSupervisor == true && emp.Id == supervisorId).FirstOrDefault().EmployeeNameWithInitials;
            var employeeleavemanagementVm = new EmployeeLeaveManagementViewModel();
            employeeleavemanagementVm.Id = employeeleavemanagement.Id;
            employeeleavemanagementVm.SupervisorId = employeeleavemanagement.SupervisorId;
            employeeleavemanagementVm.SupervisorName = SuperVisorName;
            employeeleavemanagementVm.EmployeeId = employeeleavemanagement.EmployeeId;
            employeeleavemanagementVm.EmployeeName = db.Employee.Where(emp => emp.Id == supervisorId).FirstOrDefault().EmployeeNameWithInitials;
            employeeleavemanagementVm.LeaveTypeId = employeeleavemanagement.LeaveType;
            employeeleavemanagementVm.LeaveTypeName = db.LeaveType.Where(lv => lv.LeaveId == employeeleavemanagement.LeaveType).FirstOrDefault().LeaveTypeName;
            employeeleavemanagementVm.IsApproved = employeeleavemanagement.IsApproved;
            employeeleavemanagementVm.StartDate = employeeleavemanagement.StartDate;
            employeeleavemanagementVm.EndDate = employeeleavemanagement.EndDate;
            employeeleavemanagementVm.Status = false;
            var approved = String.Empty;
            if (employeeleavemanagement.IsApproved == 0)
                approved = "Pending";

            if (employeeleavemanagement.IsApproved == 1)
                approved = "Approved";

            if (employeeleavemanagement.IsApproved == 2)
                approved = "Cancelled";

            employeeleavemanagementVm.IsApprovedStatus = approved;

            return View(employeeleavemanagementVm);
        }

        [HttpPost]
        public ActionResult SupervisorEdit(EmployeeLeaveManagementViewModel vm)
        {
            var employeeleavemanagement = db.EmployeeLeaveManagement.Where(m => m.Id == vm.Id).FirstOrDefault();


            if (employeeleavemanagement.Status)
                employeeleavemanagement.IsApproved = 1;
            else
                employeeleavemanagement.IsApproved = 2;

            TryUpdateModel(employeeleavemanagement, "IsApproved");
            db.EmployeeLeaveManagement.Add(employeeleavemanagement);
            db.Entry(employeeleavemanagement).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("SupervisorIndex");
        }
    }
}