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
    public class DesignationController : Controller
    {
        private HrisContext db = new HrisContext();
        // GET: Designation
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