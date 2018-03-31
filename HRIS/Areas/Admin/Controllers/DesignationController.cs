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
    public class DesignationController : Controller
    {
        private HrisContext db = new HrisContext();
        
        // GET: Admin/Designation
        public ActionResult Index()
        {
            var designations = db.Designations.ToList();
            var designationList = new List<DesignationViewModel>();
            foreach (var item in designations)
            {
                var designationVm = new DesignationViewModel();
                designationVm.DesignationId = item.Id;
                designationVm.DesignationName = item.Designation;

                designationList.Add(designationVm);
            }
            return View(designationList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var designationVm = new DesignationViewModel();
            return View(designationVm);
        }

        [HttpPost]
        public ActionResult Add(DesignationViewModel designationVm)
        {

            if (ModelState.IsValid)
            {
                Designations designation = db.Designations.Where(des => des.DesignationName == designationVm.DesignationName).FirstOrDefault();
                designation.Status = true;

                TryUpdateModel(designation, new string[] { "Designation" }); /*column name*/
                db.Designations.Add(designation);
                db.Entry(designation).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var designation = db.Designations.Where(des => des.Id == id).FirstOrDefault();
            var designationVm = new DesignationViewModel();

            designationVm.DesignationName = designation.Designation;
            designation.Id = designation.Id;
            return View(designation);
        }
    }
}