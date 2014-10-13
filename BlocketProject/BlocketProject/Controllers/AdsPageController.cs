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
using System.Web.Routing;
using System;

namespace BlocketProject.Controllers
{
    public class AdsPageController : PageController<AdsPage>
    {

        public ActionResult Index(AdsPage currentPage, int? EventId)
        {
            var model = new AdsPageViewModel(currentPage);
            model.InvitationMessage = currentPage.StartPage.InvitationMessage;
            model.InvitationMessageTitle = currentPage.StartPage.InvitationMessageTitle;
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

                model = SetModelValues(EventId);
                return View("Index", model);

            }
        }
        [HttpPost]
        public ActionResult Index(int EventId, string message, string messageTitle)
        {
            var model = SetModelValues(EventId);
            model.InvitationMessage = message;
            model.InvitationMessageTitle = messageTitle;
            return View("Index", model);

        }

        [HttpPost]
        public ActionResult InviteFriends(List<int> selectedList, int EventId, int userId, AdsPage currentPage)
        {
            var model = new AdsPageViewModel(currentPage);
            model.InvitationMessage = currentPage.StartPage.InvitationMessage;
            model.InvitationMessageTitle = currentPage.StartPage.InvitationMessageTitle;
            foreach (var friend in selectedList)
            {
                if (friend != 0)
                {
                    ConnectionHelper.InviteFriends(friend, EventId, userId, model.InvitationMessage, model.InvitationMessageTitle);
                    
                }
                
            }

            return RedirectToAction("Index", new { @EventId = EventId });

        }


        [HttpPost]
        public ActionResult SetAttendingStatus(int UserId, int EventId)
        {
            ConnectionHelper.SetAttendingStatus(UserId, EventId);

            return RedirectToAction("Index", new { @EventId = EventId });
        }

        [HttpPost]
        public ActionResult RemoveAttendingStatus(int UserId, int EventId)
        {
            ConnectionHelper.RemoveAttendingStatus(UserId, EventId);

            return RedirectToAction("Index", new { @EventId = EventId });

        }

        [HttpPost]
        public ActionResult SetMaybeAttendingStatus(int UserId, int EventId)
        {
            ConnectionHelper.SetMaybeAttendingStatus(UserId, EventId);

            return RedirectToAction("Index", new { @EventId = EventId });

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

        public AdsPageViewModel SetModelValues(int EventId)
        {
            var model = new AdsPageViewModel();

            DbUserEvents ad = Helpers.ConnectionHelper.GetAdById(EventId);
            model.UserEventModel = SetEventValues(ad);
            model.User = ConnectionHelper.GetUserInformationByEmail(ConnectionHelper.GetUserEmailById(ad.UserId));
            model.ListAttendingUsers = ConnectionHelper.GetAttendingUsers(ad.EventId);
            model.ListMaybeAttendingUsers = ConnectionHelper.GetMaybeAttendingUsers(ad.EventId);
            model.ListPendingUsers = ConnectionHelper.GetPendingUsers(ad.EventId);
            model.ListInvitedUsers = ConnectionHelper.GetInvitedUsers(ad.EventId);
            model.ListNotAttendingUsers = ConnectionHelper.GetNotAttendingUsers(ad.EventId);

            return model;
        }

        public AdsPageViewModel SetModelValues(int? EventId)
        {
            var model = new AdsPageViewModel();

            DbUserEvents ad = Helpers.ConnectionHelper.GetAdById(EventId);
            model.UserEventModel = SetEventValues(ad);
            model.User = ConnectionHelper.GetUserInformationByEmail(ConnectionHelper.GetUserEmailById(ad.UserId));
            model.ListAttendingUsers = ConnectionHelper.GetAttendingUsers(ad.EventId);
            model.ListMaybeAttendingUsers = ConnectionHelper.GetMaybeAttendingUsers(ad.EventId);
            model.ListPendingUsers = ConnectionHelper.GetPendingUsers(ad.EventId);
            model.ListInvitedUsers = ConnectionHelper.GetInvitedUsers(ad.EventId);
            model.ListNotAttendingUsers = ConnectionHelper.GetNotAttendingUsers(ad.EventId);

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