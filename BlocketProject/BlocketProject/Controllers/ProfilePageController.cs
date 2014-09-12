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

namespace BlocketProject.Controllers
{
    public class ProfilePageController : PageController<ProfilePage>
    {

        [Authorize] // users must be authenticated to view this page
        public ActionResult Index(ProfilePage currentPage)
        {
            var user = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);
            var model = new ProfilePageViewModel(currentPage);
            if (user == null)
            {
                return View();
            }

            FacebookFriendsModel friends = new FacebookFriendsModel();


            //var b = Session["MyAccessToken"].ToString();
            //var client = new FacebookClient(b);
            //dynamic fbresult = client.Get("me/friends");
            //var data = fbresult["data"].ToString();
            //friends.friendsList = JsonConvert.DeserializeObject<List<FacebookFriend>>(data);

            //model.friendsList = friends.friendsList;

            model.Fbuser = new ProfilePageViewModel.FacebookUserModel();
            model.Fbuser = UserHelper.GetUserValues(model.Fbuser, user);
            model.ListUserAds = ConnectionHelper.GetUserAds(user.UserId);

            return View(model);
        }




    }
}