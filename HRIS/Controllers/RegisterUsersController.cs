using HRIS.DAL;
using HRIS.Data.Models;
using HRIS.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace HRIS.Controllers
{
    
    //[Authorize(Roles = "Host,Administrator")]
    public class RegisterUsersController : Controller
    {
        // GET: RegisterUsers       

        private HrisContext db = new HrisContext();


		// GET: RegisterUsers
		public ActionResult Index()
        {
			var users = db.webpages_Membership.ToList();
			var usersViewModel = ArrangeUsers(users);

			return View(usersViewModel);
        }

		public JsonResult EditUser(int Id) {
			var userViewModel = new RegisteredUsersViewModel();
			
			var user = db.webpages_Membership.Find(Id);
			var userRole = Roles.GetRolesForUser(user.UserProfile.UserName).FirstOrDefault();
			userViewModel.UserId = user.UserId;
			userViewModel.UserName = user.UserProfile.UserName;
			userViewModel.UserRoleId = db.webpages_UsersInRoles.Where(u => u.UserId == user.UserId).FirstOrDefault().RoleId;
			userViewModel.CreatedDate = user.CreateDate;
            userViewModel.ModifiedDate = DateTime.ParseExact(user.PasswordChangedDate.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture );
			userViewModel.IsActiveUser = (user.IsConfirmed == true) ? "Yes" : "No";
			userViewModel.IsActiveUserState = user.IsConfirmed;
			userViewModel.UserRole = userRole;
			return Json(userViewModel, JsonRequestBehavior.AllowGet);
		}

		public JsonResult UpdateUser(RegisteredUsersViewModel user)
		{
			if(ModelState.IsValid)
			{
				var userToUpdate = db.webpages_Membership.Find(user.UserId);
				
				var userRole = db.webpages_UsersInRoles.Where(r => r.UserId == user.UserId).FirstOrDefault();
				if(userRole != null)
					Roles.RemoveUserFromRole(userToUpdate.UserProfile.UserName, userRole.webpages_Roles.RoleName);
				Roles.AddUserToRole(userToUpdate.UserProfile.UserName, user.UserRole);

				userToUpdate.IsConfirmed = user.IsActiveUserState;
				
				if (TryUpdateModel(userToUpdate, new string[] { "IsConfirmed" }))
				{
					db.Entry(userToUpdate).State = System.Data.Entity.EntityState.Modified;
					db.SaveChanges();
				}			
			}

			var users = db.webpages_Membership.ToList();
			var usersViewModel = ArrangeUsers(users);

			return Json(usersViewModel, JsonRequestBehavior.AllowGet);
		}

        public ActionResult Add()
        {
            //WebSecurity.CreateUserAndAccount("saabith", "");
            //Roles.AddUserToRole(user.UserName, user.UserRole);
            return View();
        }

		public JsonResult AddNewUser(RegisteredUsersViewModel user)
		{
			if (!WebSecurity.UserExists(user.UserName) )
			{
				WebSecurity.CreateUserAndAccount(user.UserName, user.Password);
				Roles.AddUserToRole(user.UserName, user.UserRole);
			}

			var users = db.webpages_Membership.ToList();
			var usersViewModel = ArrangeUsers(users);
			return Json(usersViewModel, JsonRequestBehavior.AllowGet);
		}

		public IList<RegisteredUsersViewModel> ArrangeUsers(IList<webpages_Membership> users)
		{
			var usersViewModel = new List<RegisteredUsersViewModel>();
			foreach (var userItem in users)
			{
				var userViewModel = new RegisteredUsersViewModel();
				userViewModel.UserId = userItem.UserId;
				userViewModel.UserName = userItem.UserProfile.UserName;
				userViewModel.UserRole = Roles.GetRolesForUser(userItem.UserProfile.UserName).FirstOrDefault();
				userViewModel.CreatedDate = userItem.CreateDate;
                userViewModel.ModifiedDate = DateTime.ParseExact(userItem.PasswordChangedDate.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
				userViewModel.IsActiveUser = (userItem.IsConfirmed == true) ? "Yes" : "No";
				usersViewModel.Add(userViewModel);
			}
			return usersViewModel;
		}
	}
}