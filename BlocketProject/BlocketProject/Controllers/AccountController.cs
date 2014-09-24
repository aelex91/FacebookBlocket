using BlocketProject.Helpers;
using BlocketProject.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
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
        public ActionResult DeleteUser(int id) //ändra till episerver users kan bara ta bort
        {
            // hämta en url från 
            var repository = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<IContentRepository>();
            ConnectionHelper.DeleteUser(id);
            //ConnectionHelper.DeleteUserEvent(id);
            return View("Index", "Admin", new { language = EPiServer.Globalization.ContentLanguage.PreferredCulture.Name });
        }
        [AllowAnonymous]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RegisterUser(RegisterBlockViewModel model)
        {
            if (model.RegisterUser.SelectedMonth == "0")
            {
                return View("Index", "Startpage");
            }

            if (ModelState.IsValid)
            {

                var emailCheck = ConnectionHelper.GetUserInformationByEmail(model.RegisterUser.Email);
                // check from database if email is registred.

                // spara in men först kolla om användarens email redan finns. sätt även HasFacebook till false.
                if (emailCheck == null)
                {
                    //spara in nya värden till database

                }
                else
                {
                    ModelState.AddModelError(model.RegisterUser.Email, " Finns redan.");
                    return View("Index", "Startpage", model);
                }

            }
            return View("Index", "Startpage");
        }

    }
}
