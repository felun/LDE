using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LDE.Web.Resources;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using LDE.Web.ViewModels;
using AspNetCore.Identity.MongoDB;
using Microsoft.AspNetCore.Identity;

namespace LDE.Web.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(
            UserManager<MongoIdentityUser> userManager,
            SignInManager<MongoIdentityUser> signInManager,
            IStringLocalizer<SharedResources> sharedLocalizer):base(userManager, sharedLocalizer)
        {
        }

        public IActionResult Index()
        {
            var user = GetCurrentUserAsync();
            return View(new MainPageViewModel(Request));
        }

        public IActionResult About()
        {
            var model = new MainPageViewModel(Request);

            return View("About."+ model.Culture.TwoLetterISOLanguageName);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        //[HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

    }
}
