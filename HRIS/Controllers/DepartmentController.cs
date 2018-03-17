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
    public class DepartmentController : Controller
    {
        private HrisContext db = new HrisContext();
        // GET: Department
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