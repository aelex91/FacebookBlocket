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

    }
}
