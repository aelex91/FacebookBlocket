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
    public class LandingPageController : PageController<LandingPage>
    {
        [HttpGet]
        public ActionResult Index(LandingPage currentPage, string message)
        {

            // TODO:
            //Ändra så att urlen i webbläsaren inte tar med message. cutta bort den här.

            var model = new LandingPageViewModel(currentPage);
            var user = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);
            model.ErrorMessage = message;
            if (model.Fbuser != null)
            {
                model.Fbuser = new LandingPageViewModel.FacebookUserModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                };
            }
            return View(model);
        }

    }
}