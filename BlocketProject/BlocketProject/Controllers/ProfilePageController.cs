using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using BlocketProject.Models.Pages;
using BlocketProject.Models.ViewModels;
using BlocketProject.Models.DbClasses;
using System.Web.Security;
using BlocketProject.Helpers;

namespace BlocketProject.Controllers
{
    public class ProfilePageController : PageController<ProfilePage>
    {

        [Authorize] // users must be authenticated to view this page
        public ActionResult Index(ProfilePage currentPage)
        {
            var user = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);
           
            var model = new ProfilePageViewModel(currentPage);
            model.Fbuser = new ProfilePageViewModel.FacebookUserModel();
        model.Fbuser =  UserHelper.GetUserValues(model.Fbuser, user);
            model.ListUserAds = ConnectionHelper.GetUserAds(user.UserId);

            return View(model);
        }



    }
}