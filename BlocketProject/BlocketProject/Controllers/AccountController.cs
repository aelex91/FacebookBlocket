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
            //UrlHelper url = new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);
            //skapa en metod som tar bort ett id ur userads samt tar bort numberofevents i user tabellen.
            ConnectionHelper.DeleteUserEvent(id);
            return RedirectToAction("Index", new { node = PageReference.StartPage });
        }
        [Authorize]
        public ActionResult DeleteUser(int id) //ändra till episerver users kan bara ta bort
        {
            //UrlHelper url = new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);
            //skapa en metod som tar bort ett id ur userads samt tar bort numberofevents i user tabellen.
            ConnectionHelper.DeleteUser(id);
            return RedirectToAction("Index", new { node = PageReference.StartPage });
        }

    }
}
