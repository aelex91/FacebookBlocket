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
            var user = ConnetionHelper.GetUserInformation(User.Identity.Name);

            var model = new ProfilePageViewModel(currentPage);
            model.Fbuser = new ProfilePageViewModel.FacebookUserModel();

            model.Fbuser.Location = user.Location;
            model.Fbuser.FacebookId = user.FacebookId;
            model.Fbuser.FirstName = user.FirstName;
            model.Fbuser.LastName = user.LastName;
            model.Fbuser.UserId = user.UserId;
            model.Fbuser.Email = user.Email;
            model.Fbuser.ImageUrl = user.ImageUrl;

            model.ListUserAds = ConnetionHelper.GetUserAds(user.UserId);

            return View(model);
        }

        

    }
}