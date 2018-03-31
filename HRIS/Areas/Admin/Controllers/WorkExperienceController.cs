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
    public class WorkExperienceController : Controller
    {
        private HrisContext db = new HrisContext();
        // GET: Admin/WorkExperience
        public ActionResult Index()
        {
            var workexperience = db.WorkExperience.Where(m => m.Status == true).ToList();

            var workexperienceList = new List<WorkExperienceViewModel>();
            foreach (var item in workexperience)
            {
                var workexperienceVm = new WorkExperienceViewModel();
                workexperienceVm.WorkExperienceId = item.WorkExperienceId;
                workexperienceVm.CompanyName = item.CompanyName;
                workexperienceVm.FromDate = item.FromDate;
                workexperienceVm.ToDate = item.ToDate;
                workexperienceVm.ConfirmedDate = item.ConfirmedDate;
                workexperienceVm.Department = item.Department;
                workexperienceVm.DesignationWhenLeaving = item.DesignationWhenLeaving;
                workexperienceVm.ReasonForLeaving = item.ReasonForLeaving;
                workexperienceVm.Achievements = item.Achievements;
                workexperienceVm.Accountabilities = item.Accountabilities;
                workexperienceVm.PeriodServed = item.PeriodServed;
                workexperienceVm.Status = item.Status;


                workexperienceList.Add(workexperienceVm);
            }

            return View(workexperienceList);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(WorkExperienceViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    WorkExperience workexperience = db.WorkExperience.Where(exp => exp.WorkExperienceId == vm.WorkExperienceId).FirstOrDefault();
                    workexperience.CompanyName = vm.CompanyName;
                    workexperience.FromDate = vm.FromDate;
                    workexperience.ToDate = vm.ToDate;
                    workexperience.ConfirmedDate = vm.ConfirmedDate;
                    workexperience.Department = vm.Department;
                    workexperience.DesignationWhenLeaving = vm.DesignationWhenLeaving;
                    workexperience.ReasonForLeaving = vm.ReasonForLeaving;
                    workexperience.Achievements = vm.Achievements;
                    workexperience.Accountabilities = vm.Accountabilities;
                    workexperience.PeriodServed = vm.PeriodServed;
                    workexperience.Status = vm.Status;


                    TryUpdateModel(workexperience, new string[] { "WorkExperienceId, CompanyName, FromDate, ToDate,ConfirmedDate, Department, DesignationWhenLeaving, ReasonForLeaving, Achievements, Accountabilities, PeriodServed, Status" }); /*column name*/
                    db.WorkExperience.Add(workexperience);
                    db.Entry(workexperience).State = System.Data.Entity.EntityState.Added;
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
            var workexperience = db.WorkExperience.Where(exp => exp.WorkExperienceId == WorkExperienceId).FirstOrDefault();
            var workexperienceVm = new WorkExperienceViewModel();
            workexperienceVm.WorkExperienceId = workexperience.WorkExperienceId;
            workexperienceVm.CompanyName = workexperience.CompanyName;
            workexperienceVm.FromDate = workexperience.FromDate;
            workexperienceVm.ToDate = workexperience.ToDate;
            workexperienceVm.ConfirmedDate = workexperience.ConfirmedDate;
            workexperienceVm.Department = workexperience.Department;
            workexperienceVm.DesignationWhenLeaving = workexperience.DesignationWhenLeaving;
            workexperienceVm.ReasonForLeaving = workexperience.ReasonForLeaving;
            workexperienceVm.Achievements = workexperience.Achievements;
            workexperienceVm.Accountabilities = workexperience.Accountabilities;
            workexperienceVm.PeriodServed = workexperience.PeriodServed;
            workexperienceVm.Status = workexperience.Status;

            return View(workexperienceVm);
        }

        [HttpPost]
        public ActionResult Edit(WorkExperienceViewModel workexperienceVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var workexperience = new WorkExperience();
                    workexperience.WorkExperienceId = workexperienceVm.WorkExperienceId;
                    workexperience.CompanyName = workexperienceVm.CompanyName;
                    workexperience.FromDate = workexperienceVm.FromDate;
                    workexperience.ToDate = workexperienceVm.ToDate;
                    workexperience.ConfirmedDate = workexperienceVm.ConfirmedDate;
                    workexperience.Department = workexperienceVm.Department;
                    workexperience.DesignationWhenLeaving = workexperienceVm.DesignationWhenLeaving;
                    workexperience.ReasonForLeaving = workexperienceVm.ReasonForLeaving;
                    workexperience.Achievements = workexperienceVm.Achievements;
                    workexperience.Accountabilities = workexperienceVm.Accountabilities;
                    workexperience.PeriodServed = workexperienceVm.PeriodServed;
                    workexperience.Status = true;

                    TryUpdateModel(workexperience, "WorkExperienceId, CompanyName, FromDate, ToDate,ConfirmedDate, Department, DesignationWhenLeaving, ReasonForLeaving, Achievements, Accountabilities, PeriodServed, Status");
                    db.WorkExperience.Add(workexperience);
                    db.Entry(workexperience).State = System.Data.Entity.EntityState.Added;
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


        public int WorkExperienceId { get; set; }
    }
}