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
        public ActionResult Index(LandingPage currentPage)
        {
            var model = new LandingPageViewModel(currentPage);
            var user = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);

            model.Fbuser = new LandingPageViewModel.FacebookUserModel {
            
                FirstName = user.FirstName,
                LastName = user.LastName,
            
            
            };

            return View(model);
        }
       
    }
}