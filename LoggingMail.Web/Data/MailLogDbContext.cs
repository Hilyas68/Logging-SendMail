using LoggingMail.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LoggingMail.Web.Data
{
    public class MailLogDbContext : IdentityDbContext<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public MailLogDbContext() : base($"name={nameof(MailLogDbContext)}")
        {

        }
    }
}
