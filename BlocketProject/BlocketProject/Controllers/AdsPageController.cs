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
            var model = new AdsPageViewModel(currentPage);
            

            if(currentPage.CurrentUserAds == true)
            {
                var user = Helpers.ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);
                var value = Helpers.ConnectionHelper.GetCurrentUserAds(user.UserId);
                model.ListCurrentUserAdsModel = value;
                return View(model);
            }
            else
            {
                var value = Helpers.ConnectionHelper.GetAllAds();
                model.ListUserAdsModel = value;
                return View(model);
            }
           
            
        }
    }
}