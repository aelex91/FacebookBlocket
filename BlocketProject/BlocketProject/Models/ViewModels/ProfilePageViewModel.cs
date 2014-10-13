using BlocketProject.Models.DbClasses;
using BlocketProject.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            this.LabelFirstName = currentPage.LabelFirstName;
            this.LabelLastName = currentPage.LabelLastName;
            this.LabelLocation = currentPage.LabelLocation;
            this.LabelPhone = currentPage.LabelPhone;
            this.LabelButton = currentPage.LabelButton;
            this.LabelEmail = currentPage.LabelEmail;
            this.EventRedirect = currentPage.EventRedirect;

        }
        public string InvitationMessage { get; set; }
        public string InvitationMessageTitle { get; set; }
        public PageReference ProfileRedirect { get; set; }
        public PageReference EventRedirect { get; set; }
        public string LabelFirstName { get; set; }
        public string LabelLastName { get; set; }
        public string LabelEmail { get; set; }
        public string LabelLocation { get; set; }
        public string LabelPhone { get; set; }
        public string LabelButton { get; set; }
        public string Heading { get; set; }
        public UserInformation CurrentUser { get; set; }
        public UserInformation OtherUser { get; set; }
        public List<UserAdsModel> ListUserAds { get; set; }
        public List<DbMessages> UserMessages { get; set; }
        public DbMessages MessageModel { get; set; }


        public class UserInformation
        {
            public int UserId { get; set; }
            public string FacebookId { get; set; }
            [MaxLength(30, ErrorMessage = "Namnet får max vara {1} tecken lång")]
            public string FirstName { get; set; }
            [MaxLength(30, ErrorMessage = "Efternamnet får max vara {1} tecken lång")]
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Location { get; set; }
            public string ImageUrl { get; set; }
            public string Gender { get; set; }
            public DateTime Birthday { get; set; }
            public DateTime RegisterDate { get; set; }
            public DateTime ModifiedOn { get; set; }
            public int? NumberOfEvents { get; set; }
            [MaxLength(25, ErrorMessage = "Skriv in ett korrekt telefonnummer")]
            public string Phone { get; set; }
            public int Password { get; set; }
            public bool HasFacebook { get; set; }
            public string Municipality { get; set; }
            public string County { get; set; }
        }


        public class UserAdsModel
        {
            public int EventId { get; set; }
            public string Email { get; set; }
            public int UserId { get; set; }
            public string Title { get; set; }
            public int Price { get; set; }
            public int Phone { get; set; }
            public string EventDescription { get; set; }
            public string ImageUrl { get; set; }
            public int CategoryId { get; set; }
            public int GenderId { get; set; }
            public DateTime PublishDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public int MunicipalityId { get; set; }
            public int CountyId { get; set; }
            public bool HideImportantInfo { get; set; }
            public int MaxGuests { get; set; }
            public int Zipcode { get; set; }
        }
        public string GetLinkByPageReference(PageReference pReference)
        {
            var locate = new ServiceLocationHelper(ServiceLocator.Current);
            var page = locate.ContentRepository().Get<PageData>(pReference);
            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            var pageUrl = urlResolver.GetUrl(page.ContentLink);
            return pageUrl;
        }

        public Dictionary<string, object> GetLinkByPageReference(PageReference pReference, object routeValues)
        {
            var locate = new ServiceLocationHelper(ServiceLocator.Current);
            var page = locate.ContentRepository().Get<PageData>(pReference);
            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            var pageUrl = urlResolver.GetUrl(page.ContentLink);
            Dictionary<string, object> values = new Dictionary<string, object>();

            values.Add(pageUrl, routeValues);
            return values;
        }

    }
}