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
    public class ExpertiseProfileController : Controller
    {
        private HrisContext db = new HrisContext();
        // GET: ExpertiseProfile
        public ActionResult Index()
        {
            var expertiseprofile = db.ExpertiseProfile.Where(m => m.Status == true).ToList();

            var expertiseprofileList = new List<ExpertiseProfileViewModel>();
            foreach (var item in expertiseprofile)
            {
                var expertiseprofileVm = new ExpertiseProfileViewModel();
                expertiseprofileVm.ExpertiseId = item.ExpertiseId;
                expertiseprofileVm.ExpertiseArea = item.ExpertiseArea;
                expertiseprofileVm.Description = item.Description;
                expertiseprofileVm.Status = item.Status;

                expertiseprofileList.Add(expertiseprofileVm);
            }

            return View(expertiseprofileList);
        }

        public ActionResult Edit(int id)
        {
            var expertiseprofile = db.ExpertiseProfile.Where(pro => pro.ExpertiseId == ExpertiseId).FirstOrDefault();
            var expertiseprofileVm = new ExpertiseProfileViewModel();
            expertiseprofileVm.ExpertiseId = expertiseprofile.ExpertiseId;
            expertiseprofileVm.ExpertiseArea = expertiseprofile.ExpertiseArea;
            expertiseprofileVm.Description = expertiseprofile.Description;
            expertiseprofileVm.Status = expertiseprofile.Status;

            return View(expertiseprofileVm);
        }

        [HttpPost]
        public ActionResult Edit(ExpertiseProfileViewModel expertiseprofileVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var expertiseprofile = new ExpertiseProfile();
                    expertiseprofile.ExpertiseId = expertiseprofileVm.ExpertiseId;
                    expertiseprofile.ExpertiseArea = expertiseprofileVm.ExpertiseArea;
                    expertiseprofile.Description = expertiseprofileVm.Description;
                    expertiseprofile.Status = true;

                    TryUpdateModel(expertiseprofile, "ExpertiseId, ExpertiseArea, Description, Status");
                    db.ExpertiseProfile.Add(expertiseprofile);
                    db.Entry(expertiseprofile).State = System.Data.Entity.EntityState.Added;
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

        public int ExpertiseId { get; set; }
    }
}