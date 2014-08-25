using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using BlocketProject.Models.Pages;
using System.Configuration;
using EPiServer.ServiceLocation;
using BlocketProject.Models.ViewModels;

namespace BlocketProject.Controllers
{
    public class StandardPageController : PageController<StandardPage>
    {
        public ActionResult Index(StandardPage currentPage)
        {
            var model = new StandardPageViewModel(currentPage);

      

            return View(model);
        }
        
    }
}