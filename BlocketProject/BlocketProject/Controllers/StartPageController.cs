using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using BlocketProject.Models.Pages;

namespace BlocketProject.Controllers
{
    public class StartPageController : PageController<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
          
            return View(currentPage);
        }
        [HttpPost]
        public ActionResult Hejsan()
        {
            Response.Write("hej");
            return View("Index");
        }
    }
}