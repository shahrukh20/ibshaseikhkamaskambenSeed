using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SystemConsoler.BLL.Models;

namespace SystemConsoler.BLL.Context
{
    public class UserRole : IdentityUserRole<int>
    {
    }

    public class UserClaim : IdentityUserClaim<int>
    {
    }

    public class UserLogin : IdentityUserLogin<int>
    {
    }

    public class Role : IdentityRole<int, UserRole>
    {
        public Role() { }
        public Role(string name) { Name = name; }
    }
    public class ApplicationUser : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
        public DateTime? ActiveUntil;

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class UserStore : UserStore<ApplicationUser, Role, int,
    UserLogin, UserRole, UserClaim>
    {
        public UserStore(ConsolerContext context) : base(context)
        {
        }
    }
    public partial class ConsolerContext : IdentityDbContext<ApplicationUser, Role, int,
        UserLogin, UserRole, UserClaim>
    {

        public ConsolerContext()
            : base("DefaultConnection")
        {
        }
        public virtual DbSet<User> Users { get; set; }

    }
}
