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
    public class QualificationController : Controller
    {
        private HrisContext db = new HrisContext();
        // GET: Admin/Qualification
        public ActionResult Index()
        {
            var qualification = db.Qualification.Where(m => m.Status == true).ToList();

            var qualificationList = new List<QualificationViewModel>();
            foreach (var item in qualification)
            {
                var qualificationVm = new QualificationViewModel();
                qualificationVm.QualificationId = item.QualificationId;
                qualificationVm.QualificationType = item.QualificationType;
                qualificationVm.Qualification = item.QualificationName;
                qualificationVm.Institute = item.Institute;
                qualificationVm.QualificationYear = item.QualificationYear;
                qualificationVm.Description = item.Description;
                qualificationVm.Status = item.Status;

                qualificationList.Add(qualificationVm);
            }

            return View(qualificationList);
        }

        public ActionResult Add()
        {
            ViewBag.Employees = new SelectList(from employee in db.Employee.ToList().Where(c => c.Status == true) select employee, "Id", "EmployeeNameWithInitial", 0);
			
            return View();
        }

        [HttpPost]
        public ActionResult Add(QualificationViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var qualification = new Qualification();
                    qualification.QualificationId = vm.QualificationId;
                    qualification.QualificationType = vm.QualificationType;
                    qualification.QualificationName = vm.Qualification;
                    qualification.Institute = vm.Institute;
                    qualification.QualificationYear = vm.QualificationYear;
                    qualification.Description = vm.Description;
                    qualification.Status = vm.Status;
                    qualification.EmployeeId = vm.EmployeeId;

                    TryUpdateModel(qualification, new string[] { "QualificationId, QualificationType, Qualification, Institute, QualificationYear, Description, Status" }); /*column name*/
                    db.Qualification.Add(qualification);
                    db.Entry(qualification).State = System.Data.Entity.EntityState.Added;
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
            var qualification = db.Qualification.Where(qual => qual.QualificationId == QualificationId).FirstOrDefault();
            var qualificationVm = new QualificationViewModel();
            qualificationVm.QualificationId = qualification.QualificationId;
            qualificationVm.QualificationType = qualification.QualificationType;
            qualificationVm.Qualification = qualification.QualificationName;
            qualificationVm.Institute = qualification.Institute;
            qualificationVm.QualificationYear = qualification.QualificationYear;
            qualificationVm.Description = qualification.Description;
            qualificationVm.Status = qualification.Status;


            return View(qualificationVm);
        }

        [HttpPost]
        public ActionResult Edit(QualificationViewModel qualificationVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var qualification = new Qualification();
                    qualification.QualificationId = qualificationVm.QualificationId;
                    qualification.QualificationType = qualificationVm.QualificationType;
                    qualification.QualificationName = qualificationVm.Qualification;
                    qualification.Institute = qualificationVm.Institute;
                    qualification.QualificationYear = qualificationVm.QualificationYear;
                    qualification.Description = qualificationVm.Description;
                    qualification.Status = true;

                    TryUpdateModel(qualification, "QualificationId, QualificationType, Qualification, Institute,QualificationYear, Description, Status");
                    db.Qualification.Add(qualification);
                    db.Entry(qualification).State = System.Data.Entity.EntityState.Added;
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

        public int QualificationId { get; set; }
    }
}