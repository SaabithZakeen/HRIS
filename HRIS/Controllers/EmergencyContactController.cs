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
    public class EmergencyContactController : Controller
    {
        private HrisContext db = new HrisContext();
        // GET: EmergencyContact
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

        [HttpGet]
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
        public ActionResult Edit(EmergencyContactViewModel emergencycontactVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmergencyContact emergencycontact = db.EmergencyContact.Where(con => con.EmergencyContactId == emergencycontactVm.EmergencyContactId).FirstOrDefault();
                    emergencycontact.FullName = emergencycontactVm.FullName;
                    emergencycontact.Relationship = emergencycontactVm.Relationship;
                    emergencycontact.Nic = emergencycontactVm.Nic;
                    emergencycontact.Address = emergencycontactVm.Address;
                    emergencycontact.Mobile = emergencycontactVm.Mobile;
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