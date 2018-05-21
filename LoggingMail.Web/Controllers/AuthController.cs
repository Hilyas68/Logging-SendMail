using LoggingMail.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LoggingMail.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private UserManager<AppUser, int> _userManager;

        public AuthController()
        {
            _userManager = Startup.UserManagerFactory.Invoke();
        }

        public IAuthenticationManager Authentication => this.Request.GetOwinContext().Authentication;


        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginInfo info)
        {
            //string username = "htope68@gmail.com";
            //string password = "admin";

            if (this.ModelState.IsValid)
            {
                var loginDetails = _userManager.Find(info.Username, info.Password);
                if (loginDetails != null)
                {
                    SignIn(info);

                    return Redirect(GetRedirectUrl(info.ReturnUrl));
                }
                else
                {
                    this.ModelState.AddModelError("", "Username or password is invalid");
                }
            }

            return View(info);
        }

        private void SignIn(LoginInfo info)
        {
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity("ApplicationCookie");
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, info.Username));
            //claimsIdentity.AddClaim(new Claim("PassportUrl", Url.Content("~/images/profile.png")));


            Authentication.SignIn(claimsIdentity);
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }
    }
}