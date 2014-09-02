using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using BlocketProject.Models.Pages;
using BlocketProject.Helpers;
using BlocketProject.Models.ViewModels;

namespace BlocketProject.Controllers
{
    public class AdLandingPageController : PageController<AdLandingPage>
    {
        public ActionResult Index(AdLandingPage currentPage)
        {
            var user = ConnectionHelper.GetUserInformation(User.Identity.Name);
            var model = new AdLandingPageViewModel(currentPage);
            
            model.Fbuser = new AdLandingPageViewModel.FacebookUserModel();

            model.Fbuser.firstName = user.FirstName;
            model.Fbuser.lastName = user.LastName;
            
            return View(model);
        }
    }
}