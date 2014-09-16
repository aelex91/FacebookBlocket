using BlocketProject.Models.DbClasses;
using BlocketProject.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class ProfilePageViewModel
    {
        public ProfilePageViewModel() { }
        public ProfilePageViewModel(ProfilePage currentPage)
        {
            Heading = currentPage.Heading;
            this.ReferToEditPage = currentPage.PagereferToEditPage;
            this.LabelFirstName = currentPage.LabelFirstName;
            this.LabelLastName = currentPage.LabelLastName;
            this.LabelLocation = currentPage.LabelLocation;
            this.LabelPhone = currentPage.LabelPhone;
            this.LabelButton = currentPage.LabelButton;

        }
        public string LabelFirstName { get; set; }
        public string LabelLastName { get; set; }
        public string LabelEmail { get; set; }
        public string LabelLocation { get; set; }
        public string LabelPhone { get; set; }
        public string LabelButton { get; set; }
        public PageReference ReferToEditPage { get; set; }
        public string Heading { get; set; }
        public UserInformation CurrentUser { get; set; }
        public List<UserAdsModel> ListUserAds { get; set; }
        public List<FacebookFriend> friendsList { get; set; }

        public class UserInformation
        {
            public int UserId { get; set; }
            public DateTime Birthday { get; set; }
            public string FacebookId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Location { get; set; }
            public string ImageUrl { get; set; }
            public string Gender { get; set; }
            public DateTime RegisterDate { get; set; }
            public int? NumberOfEvents { get; set; }
            public int Phone { get; set; }
        }


        public class UserAdsModel
        {
            public int UserId { get; set; }
            public int EventId { get; set; }
            public string Title { get; set; }
            public int Price { get; set; }
            public string EventDescription { get; set; }
            public string ImageUrl { get; set; }
            public DateTime PublishDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public int CategoryId { get; set; }
        }
        public string GetLinkByPageReference(PageReference pReference)
        {
            var locate = new ServiceLocationHelper(ServiceLocator.Current);
            var page = locate.ContentRepository().Get<PageData>(pReference);
            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            var pageUrl = urlResolver.GetVirtualPath(page.ContentLink);
            return pageUrl;
        }

    }
}