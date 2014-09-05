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
using BlocketProject.Helpers;

namespace BlocketProject.Controllers
{
    public class AdsPageController : PageController<AdsPage>
    {
        public ActionResult Index(AdsPage currentPage)
        {
            var model = new AdsPageViewModel(currentPage);
            if (currentPage.CurrentUserAds == true)
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
        public void AdPage(int AdId)
        {
            DbUserAds ad = Helpers.ConnectionHelper.GetAdById(AdId);

            var model = new AdsPageViewModel.UserAdsModel();
            SetAdValues(ad);

            //UrlHelper url = new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);
            //Response.Redirect(UrlHelpers.PageLinkUrl(url, page).ToHtmlString());
        }

        public AdsPageViewModel.UserAdsModel SetAdValues(DbUserAds ad)
        {
            var model = new AdsPageViewModel.UserAdsModel();

            model.AdDescription = ad.AdDescription;
            model.CategoryId = ad.CategoryId;
            model.ExpirationDate = ad.ExpirationDate;
            model.ImageUrl = ad.ImageUrl;
            model.Price = ad.Price;
            model.PublishDate = ad.PublishDate;
            model.Title = ad.Title;
            model.UserId = ad.UserId;
            return model;
        }
    }
}