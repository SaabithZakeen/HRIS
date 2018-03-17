using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRIS.DAL;
using HRIS.Models;
using System.Web.Security;
using WebMatrix.WebData;

namespace HRIS.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private HrisContext db = new HrisContext();
        // GET: Admin/Login

        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            //ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        
        ////
        //// POST: /Admin/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model, string returnUrl)
        {
            returnUrl = "Login/Index";
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                MvcApplication.CurruntUser = model.UserName;
                var user = db.UserProfile.ToList().Where(u => u.UserName == model.UserName).FirstOrDefault();
                MvcApplication.CurruntUserId = user.ID;
                MvcApplication.CurruntEmployeeId = db.Employee.Where(u => u.UserLoginId == MvcApplication.CurruntUserId).FirstOrDefault().Id;
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Incorrect Username or Password.");

            return View(model);
        }

        public ActionResult Register()
        {
            try
            {

                if (!WebSecurity.UserExists("saabith"))
                {
                    //WebSecurity.CreateUserAndAccount("SysAdmin", "Admin@#123");
                    //WebSecurity.CreateUserAndAccount("SysUser", "Admin@#123");
                    //WebSecurity.CreateUserAndAccount("SysAudit", "Admin@#123");
                    //string[] admin = new string[] { "SysAdmin" };
                    //Roles.AddUsersToRole(admin, "admin");
                    //string[] user = new string[] { "SysUser" };
                    //Roles.AddUsersToRole(user, "user");
                    //string[] audit = new string[] { "SysAudit" };
                    //Roles.AddUsersToRole(audit, "audit");
               
                    WebSecurity.CreateUserAndAccount("saabith", "abcABC123@@@");
                    Roles.AddUserToRole("saabith", "administrator");
                }
                //if (!WebSecurity.UserExists("User")) WebSecurity.CreateUserAndAccount("User", "User@#123");
                //if (!WebSecurity.UserExists("Audit")) WebSecurity.CreateUserAndAccount("Audit", "Audit@#123");
                //Roles.CreateRole("administrator");
                //Roles.CreateRole("user");
                //Roles.CreateRole("audit");
                
            }
            catch (MembershipCreateUserException e)
            {
                ModelState.AddModelError("", "Error");
            }
            return View();
        }
    }
}