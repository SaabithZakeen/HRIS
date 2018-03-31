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
    public class EmergencyContactController : Controller
    {
        private HrisContext db = new HrisContext();
        // GET: Admin/EmergencyContact
        public ActionResult Index()
        {
            var emergencycontact = db.EmergencyContact.Where(m => m.Status == true).ToList();

            var emergencycontactList = new List<EmergencyContactViewModel>();
            foreach (var item in emergencycontact)
            {
                var emergencycontactVm = new EmergencyContactViewModel();
                emergencycontactVm.EmergencyContactId = item.EmergencyContactId;
                emergencycontactVm.FullName = item.FullName;
                emergencycontactVm.Relationship = item.Relationship;
                emergencycontactVm.Nic = item.Nic;
                emergencycontactVm.Address = item.Address;
                emergencycontactVm.Mobile = item.Mobile;
                emergencycontactVm.Status = item.Status;

                emergencycontactList.Add(emergencycontactVm);
            }

            return View(emergencycontactList);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(EmergencyContactViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmergencyContact emergencycontact = db.EmergencyContact.Where(con => con.EmergencyContactId == vm.EmergencyContactId).FirstOrDefault();
                    emergencycontact.FullName = vm.FullName;
                    emergencycontact.Relationship = vm.Relationship;
                    emergencycontact.Nic = vm.Nic;
                    emergencycontact.Address = vm.Address;
                    emergencycontact.Mobile = vm.Mobile;
                    emergencycontact.Status = vm.Status;


                    TryUpdateModel(emergencycontact, new string[] { "EmergencyContactId, FullName, Relationship, Nic, Address, Mobile, Status" }); /*column name*/
                    db.EmergencyContact.Add(emergencycontact);
                    db.Entry(emergencycontact).State = System.Data.Entity.EntityState.Added;
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
            var emergencycontact = db.EmergencyContact.Where(con => con.EmergencyContactId == EmergencyContactId).FirstOrDefault();
            var emergencycontactVm = new EmergencyContactViewModel();
            emergencycontactVm.EmergencyContactId = emergencycontact.EmergencyContactId;
            emergencycontactVm.FullName = emergencycontact.FullName;
            emergencycontactVm.Relationship = emergencycontact.Relationship;
            emergencycontactVm.Nic = emergencycontact.Nic;
            emergencycontactVm.Address = emergencycontact.Address;
            emergencycontactVm.Mobile = emergencycontact.Mobile;
            emergencycontactVm.Status = emergencycontact.Status;


            return View(emergencycontactVm);
        }

        [HttpPost]
        public ActionResult Edit(EmergencyContactViewModel qualificationVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emergencycontact = new EmergencyContact();
                    emergencycontact.EmergencyContactId = qualificationVm.EmergencyContactId;
                    emergencycontact.FullName = qualificationVm.FullName;
                    emergencycontact.Relationship = qualificationVm.Relationship;
                    emergencycontact.Nic = qualificationVm.Nic;
                    emergencycontact.Address = qualificationVm.Address;
                    emergencycontact.Mobile = qualificationVm.Mobile;
                    emergencycontact.Status = true;

                    TryUpdateModel(emergencycontact, "EmergencyContactId, FullName, Relationship, Nic, Address, Mobile, Status");
                    db.EmergencyContact.Add(emergencycontact);
                    db.Entry(emergencycontact).State = System.Data.Entity.EntityState.Added;
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

        public int EmergencyContactId { get; set; }
    }
}