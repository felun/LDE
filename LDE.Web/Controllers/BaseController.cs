using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using AspNetCore.Identity.MongoDB;


namespace LDE.Web.Controllers
{
    public class BaseController : Controller
    {

        protected readonly UserManager<MongoIdentityUser> _userManager;
        //private readonly SignInManager<MongoIdentityUser> _signInManager;
        //private readonly IEmailSender _emailSender;
        //private readonly ISmsSender _smsSender;
        //private readonly ILogger _logger;

        protected IStringLocalizer<SharedResources> _sharedLocalizer;

        public BaseController(
            UserManager<MongoIdentityUser> userManager,
            IStringLocalizer<SharedResources> sharedLocalizer
            //IEmailSender emailSender,
            //ISmsSender smsSender,
            //ILoggerFactory loggerFactory
            )
        {
            _userManager = userManager;
            _sharedLocalizer = sharedLocalizer;
            //_emailSender = emailSender;
            //_smsSender = smsSender;
            //_logger = loggerFactory.CreateLogger<AccountController>();
        }

      
        protected Task<MongoIdentityUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        protected IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
