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
    public class LeaveEntitlementController : Controller
    {
        private HrisContext db = new HrisContext();

        // GET: Admin/LeaveEntitlement
        public ActionResult Index()
        {
            var leaveentitlement = db.EmployeeLeaveEntitlement.Where(emp => emp.Status == true).ToList();
            

            var leaveentitlementVmList = new List<LeaveEntitlementViewModel>();
            foreach (var item in leaveentitlement)
            {
                var leaveentitlementVm = new LeaveEntitlementViewModel();
                leaveentitlementVm.LeaveId  = item.LeaveId ;
                leaveentitlementVm.EmployeeId = item.EmployeeId;
                leaveentitlementVm.LeavesAvailable  = item.LeavesAvailable ;
                leaveentitlementVm.Status = item.Status;

                leaveentitlementVmList.Add(leaveentitlementVm);
            }

            return View(leaveentitlementVmList);
        }
        [HttpGet]
		public ActionResult Add()
		{
			ViewBag.LeaveEntitlementList = new SelectList(from leaveentitlement in db.EmployeeLeaveManagement.ToList().Where(c => c.Status == true) select leaveentitlement, "LeaveId", "EmployeeId", 0);
			return View();
		}

		[HttpPost]
		public ActionResult Add(LeaveEntitlementViewModel leaveentitlementVm)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var leaveentitlement = new EmployeeLeaveEntitlement();
                    leaveentitlement.LeaveId=leaveentitlementVm.LeaveId;
                    leaveentitlement.EmployeeId = leaveentitlementVm.EmployeeId;
                    leaveentitlement.LeavesAvailable=leaveentitlementVm.LeavesAvailable;
                    leaveentitlement.Status = true;
                    
                    TryUpdateModel(leaveentitlement, "LeaveId,EmployeeId,LeavesAvailable, Status");
                    db.EmployeeLeaveEntitlement.Add(leaveentitlement);
                    db.Entry(leaveentitlement).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
		public ActionResult Edit(int LeaveId)
		{
            ViewBag.LeaveEntitlementList = new SelectList(from leaveentitlement in db.EmployeeLeaveEntitlement.ToList().Where(c => c.Status == true) select leaveentitlement, "LeaveId", "EmployeeId", 0);

            var leaveentitlements = db.EmployeeLeaveEntitlement.Where(lea => lea.Status == true && lea.LeaveId == LeaveId).FirstOrDefault();
			
			var leaveentitlementVm = new LeaveEntitlementViewModel();
            leaveentitlementVm.LeaveId = LeaveId;
            leaveentitlementVm.EmployeeId  = leaveentitlements.EmployeeId;
            leaveentitlementVm.LeavesAvailable = leaveentitlements.LeavesAvailable;
            leaveentitlementVm.Status  = leaveentitlements.Status ;
            
            return View(leaveentitlementVm);
        }

        [HttpPost]
		public ActionResult Edit(LeaveEntitlementViewModel leaveEntitlements)
		{
			try
			{
				if (ModelState.IsValid)
				{
                    var leaveentitlement = new EmployeeLeaveEntitlement();
                    leaveentitlement.LeaveId = leaveEntitlements.LeaveId;
                    leaveentitlement.EmployeeId = leaveEntitlements.EmployeeId;
                    leaveentitlement.LeavesAvailable = leaveEntitlements.LeavesAvailable;
                    leaveentitlement.Status = true;
                    
                    TryUpdateModel(leaveentitlement, "LeaveId,EmployeeId,LeavesAvailable, Status");
                    db.EmployeeLeaveEntitlement.Add(leaveentitlement);
                    db.Entry(leaveentitlement).State = System.Data.Entity.EntityState.Added;
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

    }
}
