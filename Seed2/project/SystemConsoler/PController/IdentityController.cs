using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using SystemConsoler.BLL.Context;

namespace SystemConsoler.PController
{
    public class IdentityController : Controller
    {
        internal ApplicationSignInManager _signInManager;
        internal ApplicationUserManager _userManager;
        ConsolerContext db = new ConsolerContext();

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public string[] GetUserRole()
        {
            return System.Web.Security.Roles.GetRolesForUser(User.Identity.Name);
        }
        public int GetUserId()
        {
            int userId = int.Parse(User.Identity.GetUserId());
            var user = db.Users.FirstOrDefault(x => x.ApplicationUser == userId);
            return user.Id;
        }
    }
}