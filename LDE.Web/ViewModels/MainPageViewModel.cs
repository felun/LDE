using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LDE.Web.ViewModels
{
    public class MainPageViewModel
    {
        protected HttpRequest Request { get; private set; }
        public MainPageViewModel(HttpRequest request)
        {
            Request = request;
        }
        public CultureInfo Culture {
            get {
                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                // Culture contains the information of the requested culture
                var culture = rqf.RequestCulture.Culture;
                return culture;
            }
        }

        
    }
}
