using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using BlocketProject.Models.Pages;
using BlocketProject.Models.ViewModels;
using BlocketProject.Helpers;

namespace BlocketProject.Controllers
{
    public class AdsPageController : PageController<AdsPage>
    {
        public ActionResult Index(AdsPage currentPage)
        {
            var model = new AdsPageViewModel(currentPage);
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
          
            return View(model);
        }
    }
}