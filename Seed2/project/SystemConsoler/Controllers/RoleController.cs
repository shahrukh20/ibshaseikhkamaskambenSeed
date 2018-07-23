using System;
using System.Linq;
using System.Web.Mvc;

using SystemConsoler.BLL;
using Microsoft.AspNet.Identity.EntityFramework;
using SystemConsoler.BLL.Context;
using Microsoft.AspNet.Identity;
using SystemConsoler.BLL.Models;
using SystemConsoler.CustomFilters;

namespace A11_RBS.Controllers
{
    public class RoleController : Controller
    {
        ConsolerContext context;

        public RoleController()
        {
            context = new ConsolerContext();
        }



        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        [AuthLog(Roles = "Salesman")]
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        /// <summary>
        /// Create  a New role
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(ConvertAspNetRoleToApplicationRoleDTO(Role));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        private Role ConvertAspNetRoleToApplicationRoleDTO(IdentityRole aspRole)
        {
            return new Role
            {

                Name = aspRole.Name
            };
        }

    }
}