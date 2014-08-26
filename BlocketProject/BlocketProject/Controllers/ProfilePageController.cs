using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using BlocketProject.Models.Pages;
using BlocketProject.Models.ViewModels;

namespace BlocketProject.Controllers
{
    public class ProfilePageController : PageController<ProfilePage>
    {
        [Authorize] // users must be authenticated to view this page
        public ActionResult Index(ProfilePage currentPage)
        {


            var model = new ProfilePageViewModel(currentPage);


            
            return View(model);
        }
    }
}