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
    public class BankDetailsController : Controller
    {
        private HrisContext db = new HrisContext();
        // GET: BankDetails
        public ActionResult Index()
        {
            var bankdetails = db.BankDetails.Where(m => m.Status == true).ToList();

            var bankdetailsList = new List<BankDetailsViewModel>();
            foreach (var item in bankdetails)
            {
                var bankdetailsVm = new BankDetailsViewModel();
                bankdetailsVm.BankId = item.BankId;
                bankdetailsVm.BankName = item.BankName;
                bankdetailsVm.BranchName = item.BranchName;
                bankdetailsVm.AccountNo = item.AccountNo;
                bankdetailsVm.NameGivenToBank = item.NameGivenToBank;
                bankdetailsVm.Salary = item.Salary;
                bankdetailsVm.Description = item.Description;
                bankdetailsVm.Status = item.Status;

                bankdetailsList.Add(bankdetailsVm);
            }

            return View(bankdetailsList);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bankdetails = db.BankDetails.Where(ban => ban.BankId == BankId).FirstOrDefault();
            var bankdetailsVm = new BankDetailsViewModel();
            bankdetailsVm.BankId = bankdetails.BankId;
            bankdetailsVm.BankName = bankdetails.BankName;
            bankdetailsVm.BranchName = bankdetails.BranchName;
            bankdetailsVm.AccountNo = bankdetails.AccountNo;
            bankdetailsVm.NameGivenToBank = bankdetails.NameGivenToBank;
            bankdetailsVm.Salary = bankdetails.Salary;
            bankdetailsVm.Description = bankdetails.Description;
            bankdetailsVm.Status = bankdetails.Status;


            return View(bankdetailsVm);
        }

        [HttpPost]
        public ActionResult Edit(BankDetailsViewModel bankdetailsVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var bankdetails = new BankDetails();
                    bankdetails.BankId = bankdetailsVm.BankId;
                    bankdetails.BankName = bankdetailsVm.BankName;
                    bankdetails.BranchName = bankdetailsVm.BranchName;
                    bankdetails.AccountNo = bankdetailsVm.AccountNo;
                    bankdetails.NameGivenToBank = bankdetailsVm.NameGivenToBank;
                    bankdetails.Salary = bankdetailsVm.Salary;
                    bankdetails.Description = bankdetailsVm.Description;
                    bankdetails.Status = true;

                    TryUpdateModel(bankdetails, "BankId, BankName, BranchName, AccountNo, NameGivenToBank, Salary, Description, Status");
                    db.BankDetails.Add(bankdetails);
                    db.Entry(bankdetails).State = System.Data.Entity.EntityState.Added;
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

        public int BankId { get; set; }
    }
}