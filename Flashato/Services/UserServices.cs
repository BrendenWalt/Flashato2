using Flashato.Models;
using Flashato.Models.Requests;
using Flashato.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;

namespace Flashato.Services
{
    public class UserServices : IUserService
    {

        private ApplicationSignInManager _signInManager = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
        private ApplicationUserManager _userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();

        public IdentityResult Register(RegistrationRequest model)
        {
            ApplicationUser user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            IdentityResult result = _userManager.Create(user, model.Password);
            if (result.Succeeded)
            {
                _signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            }

            return result;

        }

        public string GetCurrentUserId()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }

    }
}