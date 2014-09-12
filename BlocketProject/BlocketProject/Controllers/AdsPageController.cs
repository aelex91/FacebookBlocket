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
        public ActionResult AdPage(int EventId)
        {
            DbUserEvents ad = Helpers.ConnectionHelper.GetAdById(EventId);

            var model = new AdsPageViewModel.UserAdsModel();
            SetEventValues(ad);

            return View("Adpage", model);
        }

        public AdsPageViewModel.UserAdsModel SetEventValues(DbUserEvents userEvent)
        {
            var model = new AdsPageViewModel.UserAdsModel();

            model.UserId = userEvent.UserId;
            model.Email = userEvent.Email;
            model.Title = userEvent.Title;
            model.Price = userEvent.Price;
            model.Phone = userEvent.Phone;
            model.MaxGuests = userEvent.MaxGuests;
            model.HideImportantInformation = userEvent.HideImportantInfo;
            model.EventDescription = userEvent.EventDescription;
            model.ImageUrl = userEvent.ImageUrl;
            model.CategoryId = userEvent.CategoryId;
            model.GenderId = userEvent.GenderId;
            model.CountyId = userEvent.CountyId;
            model.MunicipalityId = userEvent.MunicipalityId;
            model.PublishDate = userEvent.PublishDate;
            model.ExpirationDate = userEvent.ExpirationDate;

            return model;
        }
    }
}