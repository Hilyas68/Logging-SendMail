using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace LoggingMail.Web.Models
{
    public class AppUser : IdentityUser<int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public DateTime CreatedOn { get; set; }
    }

    public class AppRole : IdentityRole<int, AppUserRole>
    {

    }
    public class AppUserLogin : IdentityUserLogin<int>
    {
    }

    public class AppUserRole : IdentityUserRole<int>
    {

    }

    public class AppUserClaim : IdentityUserClaim<int>
    {

    }
}