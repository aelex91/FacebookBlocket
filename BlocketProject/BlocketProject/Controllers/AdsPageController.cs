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
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;

namespace BlocketProject.Controllers
{
    public class AdsPageController : PageController<AdsPage>
    {

        public ActionResult Index(AdsPage currentPage, int? EventId)
        {
            var model = new AdsPageViewModel(currentPage);
            if (EventId == null)
            {

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
            else
            {
                DbUserEvents ad = Helpers.ConnectionHelper.GetAdById(EventId);
                model.UserEventModel = SetEventValues(ad);
                model.User = ConnectionHelper.GetUserInformationByEmail(ConnectionHelper.GetUserEmailById(ad.UserId));
                model.ListAttendingUsers = ConnectionHelper.GetAttendingUsers(ad.EventId);
                return View("Index", model);

            }

        }

        

        [HttpPost]
        public ActionResult Index(int EventId)
        {
            DbUserEvents ad = Helpers.ConnectionHelper.GetAdById(EventId);
            var model = new AdsPageViewModel();
            model.UserEventModel = SetEventValues(ad);
            model.User = ConnectionHelper.GetUserInformationByEmail(ConnectionHelper.GetUserEmailById(ad.UserId));
            model.ListAttendingUsers = ConnectionHelper.GetAttendingUsers(ad.EventId);
            return View("Index", model);

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
            model.EventId = userEvent.EventId;

            return model;
        }

        public string GetLinkByPageReference(PageReference pReference)
        {
            var locate = new ServiceLocationHelper(ServiceLocator.Current);
            var page = locate.ContentRepository().Get<PageData>(pReference);
            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            var pageUrl = urlResolver.GetUrl(page.ContentLink);
            return pageUrl;
        }
    }
}