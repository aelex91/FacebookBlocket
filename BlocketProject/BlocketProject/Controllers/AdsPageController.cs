using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using BlocketProject.Models.Pages;
using BlocketProject.Models.ViewModels;

namespace BlocketProject.Controllers
{
    public class AdsPageController : PageController<AdsPage>
    {
        public ActionResult Index(AdsPage currentPage)
        {
            
            var GetAllAds = Helpers.ConnectionHelper.GetAllAds();
           
            var model = new AdsPageViewModel(currentPage);

            model.ListUserAdsModel = GetAllAds;

            // hämta värden från db. klar
            // fyll dom i en model,
            //skicka vidare modellen.
           
            return View(model);
        }
    }
}