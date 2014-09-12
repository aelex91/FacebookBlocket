using BlocketProject.Helpers;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlocketProject.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            UrlHelper url = new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);
            Response.Redirect(UrlHelpers.PageLinkUrl(url, PageReference.StartPage).ToHtmlString());

        }
        [Authorize]
        public ActionResult DeleteEvent(int id)
        {
            var userId = ConnectionHelper.GetUserIdByEmail(User.Identity.Name);
          //ta även bort användarens numberofad.
            ConnectionHelper.DeleteUserEvent(id);
            ConnectionHelper.RemoveUserNumberOfEvents(userId);
            string successMessage = "You have removed you event.";
            return RedirectToAction("Index", new { node = PageReference.StartPage, successMessage  });
        }
        [Authorize]
        public ActionResult DeleteUser(int id) //ändra till episerver users kan bara ta bort
        {
            var eventId = ConnectionHelper.GetUserAds(id);
            ConnectionHelper.DeleteUser(id);
            //ConnectionHelper.DeleteUserEvent(
            return RedirectToAction("Index", new { node = PageReference.StartPage });
        }

    }
}
