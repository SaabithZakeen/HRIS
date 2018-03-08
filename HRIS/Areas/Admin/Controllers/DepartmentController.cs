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
    public class DepartmentController : Controller
    {
        private HrisContext db = new HrisContext();
        // GET: Admin/Department
        public ActionResult Index()
        {
            var departments = db.Departments.Where(m => m.Status == true).ToList();

            var departmentsList = new List<DepartmentViewModel>();
            foreach (var item in departments)
            {
                var departmentVm = new DepartmentViewModel();
                departmentVm.DepartmentId = item.Id;
                departmentVm.DepartmentName = item.DepartmentName;

                departmentsList.Add(departmentVm);
            }

            return View(departmentsList);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(DepartmentViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var department = new Departments();
                department.DepartmentName = vm.DepartmentName;
                department.Status = vm.Status;
                department.User = vm.User;

                TryUpdateModel(department, new string[] { "DepartmentName, Status, User" }); /*column name*/
                db.Departments.Add(department);
                db.Entry(department).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var department = db.Departments.Where(dep => dep.Id == id).FirstOrDefault();
            var departmentVm = new DepartmentViewModel();

            departmentVm.DepartmentName = department.DepartmentName;
            department.Id = department.Id;
            return View(department);
        }


    }
}