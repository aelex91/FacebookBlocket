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
using Facebook;
using Newtonsoft.Json;
using System;
using System.Web.Configuration;
using System.IO;
using System.Net;

namespace BlocketProject.Controllers
{
    public class ProfilePageController : PageController<ProfilePage>
    {
        string appId = WebConfigurationManager.AppSettings["FacebookAppID"];
        string appSecret = WebConfigurationManager.AppSettings["FacebookAppSecret"];
        string scope = WebConfigurationManager.AppSettings["FacebookScope"];

        [Authorize] // users must be authenticated to view this page
        public ActionResult Index(ProfilePage currentPage)
        {
            var user = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);
            var model = new ProfilePageViewModel(currentPage);
            if (user == null)
            {
                return View(model);
            }

            model.CurrentUser = new ProfilePageViewModel.UserInformation();
            model.CurrentUser = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);
            model.ListUserAds = ConnectionHelper.GetUserAds(user.UserId);

            return View(model);
        }

        public ActionResult EditProfile(ProfilePage currentPage)
        {

            var model = new ProfilePageViewModel(currentPage);
            model.CurrentUser = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);

            return View("EditProfile", model);
        }
        [HttpPost]
        public ActionResult SaveProfile(ProfilePageViewModel.UserInformation model)
        {

            return RedirectToAction("Index");
        }


    }
}