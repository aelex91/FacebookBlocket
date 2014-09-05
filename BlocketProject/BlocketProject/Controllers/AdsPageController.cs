using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using BlocketProject.Models.Pages;
using BlocketProject.Models.ViewModels;
using BlocketProject.Models.DbClasses;

namespace BlocketProject.Controllers
{
    public class AdsPageController : PageController<AdsPage>
    {
        public ActionResult Index(AdsPage currentPage)
        {
            var model = new AdsPageViewModel(currentPage);

            //Episerver URL för att kunna gå in i metoden nedan och ge ett resultat

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

        [HttpPost]
        public ActionResult AdPage(AdsPage currentPage, int AdId) 
        {
            DbUserAds ad = Helpers.ConnectionHelper.GetAdById(AdId);
            var model = new AdsPageViewModel.UserAdsModel();

            model.AdDescription = ad.AdDescription;
            model.CategoryId = ad.CategoryId;
            model.ExpirationDate = ad.ExpirationDate;
            model.ImageUrl = ad.ImageUrl;
            model.Price = ad.Price;
            model.PublishDate = ad.PublishDate;
            model.Title = ad.Title;
            model.UserId = ad.UserId;
           

            return View("AdPage", model);
        }
    }
}