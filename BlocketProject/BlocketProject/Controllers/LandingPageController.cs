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
        public ActionResult Index(LandingPage currentPage)
        {
            var model = new LandingPageViewModel(currentPage);
            var user = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);

            if (user != null)
            {

                model.Fbuser.firstName = user.FirstName;
                model.Fbuser.lastName = user.LastName;
            }


            model.Fbuser = new LandingPageViewModel.FacebookUserModel();



            return View(model);
        }
    }
}