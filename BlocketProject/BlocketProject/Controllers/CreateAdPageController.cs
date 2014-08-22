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
    public class CreateAdPageController : PageController<CreateAdPage>
    {
        public ActionResult Index(CreateAdPage currentPage)
        {
            

            return View(currentPage);
        }
    }
}