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
    public class DependantsController : Controller
    {
        private HrisContext db = new HrisContext();
        // GET: Admin/Dependants
        public ActionResult Index()
        {
            var dependants = db.Dependants.Where(m => m.Status == true).ToList();

            var dependantsList = new List<DependantsViewModel>();
            foreach (var item in dependants)
            {
                var dependantsVm = new DependantsViewModel();
                dependantsVm.DependantId = item.DependantId;
                dependantsVm.FullName = item.FullName;
                dependantsVm.DOB = item.DOB;
                dependantsVm.Nic = item.Nic;
                dependantsVm.Nationality = item.Nationality;
                dependantsVm.Address = item.Address;
                dependantsVm.Gender = item.Gender;
                dependantsVm.Telephone = item.Telephone;
                dependantsVm.Description = item.Description;
                dependantsVm.Status = item.Status;

                dependantsList.Add(dependantsVm);
            }

            return View(dependantsList);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(DependantsViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Dependants dependants = db.Dependants.Where(dep => dep.DependantId == vm.DependantId).FirstOrDefault();
                    dependants.FullName = vm.FullName;
                    dependants.DOB = vm.DOB;
                    dependants.Nic = vm.Nic;
                    dependants.Nationality = vm.Nationality;
                    dependants.Address = vm.Address;
                    dependants.Gender = vm.Gender;
                    dependants.Telephone = vm.Telephone;
                    dependants.Description = vm.Description;
                    dependants.Status = vm.Status;


                    TryUpdateModel(dependants, new string[] { "DependantId, FullName, DOB, Nic, Nationality, Address, Gender, Telephone, Description, Status" }); /*column name*/
                    db.Dependants.Add(dependants);
                    db.Entry(dependants).State = System.Data.Entity.EntityState.Added;
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
            var dependants = db.Dependants.Where(dep => dep.DependantId == DependantId).FirstOrDefault();
            var dependantsVm = new DependantsViewModel();
            dependantsVm.DependantId = dependants.DependantId;
            dependantsVm.FullName = dependants.FullName;
            dependantsVm.DOB = dependants.DOB;
            dependantsVm.Nic = dependants.Nic;
            dependantsVm.Nationality = dependants.Nationality;
            dependantsVm.Address = dependants.Address;
            dependantsVm.Gender = dependants.Gender;
            dependantsVm.Telephone = dependants.Telephone;
            dependantsVm.Description = dependants.Description;
            dependantsVm.Status = dependants.Status;


            return View(dependantsVm);
        }

        [HttpPost]
        public ActionResult Edit(DependantsViewModel dependantsVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dependants = new Dependants();
                    dependants.DependantId = dependantsVm.DependantId;
                    dependants.FullName = dependantsVm.FullName;
                    dependants.DOB = dependantsVm.DOB;
                    dependants.Nic = dependantsVm.Nic;
                    dependants.Nationality = dependantsVm.Nationality;
                    dependants.Address = dependantsVm.Address;
                    dependants.Gender = dependantsVm.Gender;
                    dependants.Telephone = dependantsVm.Telephone;
                    dependants.Description = dependantsVm.Description;
                    dependants.Status = true;

                    TryUpdateModel(dependants, "DependantId, FullName, DOB, Nic, Nationality, Address, Gender, Telephone, Description, Status");
                    db.Dependants.Add(dependants);
                    db.Entry(dependants).State = System.Data.Entity.EntityState.Added;
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


        public int DependantId { get; set; }
    }
}