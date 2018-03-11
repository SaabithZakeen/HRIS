using HRIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace HRIS.Controllers
{
    public class LoginController : Controller
    {
        //// GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            //ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        ////
        //// POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                MvcApplication.CurruntUser = User.Identity.Name;
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