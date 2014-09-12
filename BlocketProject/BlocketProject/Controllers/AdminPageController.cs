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
    public class AdminPageController : PageController<AdminPage>
    {
        public ActionResult Index(AdminPage currentPage)
        {
            var model = new AdminPageViewModel(currentPage);
           //Hämta alla användare och lista ut dessa i vyn.
            model.GetFacebookUsers = ConnectionHelper.GetAllUsers();
            return View(model);
        }
    }
}