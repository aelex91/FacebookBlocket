using BlocketProject.Models.DbClasses;
using BlocketProject.Models.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class AdsPageViewModel
    {
        public AdsPageViewModel(AdsPage currentPage)
        {
            Heading = currentPage.Heading;
            CurrentUserAds = currentPage.CurrentUserAds;
            InvitationMessage = currentPage.InvitationMessage;
            InvitationMessageTitle = currentPage.InvitationMessageTitle;
        }

        public AdsPageViewModel() { }

        public List<UserAdsModel> ListUserAdsModel { get; set; }
        public List<UserAdsModel> ListCurrentUserAdsModel { get; set; }
        public string Heading { get; set; }
        public bool CurrentUserAds { get; set; }
        public UserAdsModel UserEventModel { get; set; }
        public string InvitationMessage { get; set; }
        public string InvitationMessageTitle { get; set; }

        public ProfilePageViewModel.UserInformation User { get; set; }
        public List<DbUserInformation> ListAttendingUsers { get; set; }
        public List<DbUserInformation> ListPendingUsers { get; set; }
        public List<DbUserInformation> ListMaybeAttendingUsers { get; set; }
        public List<DbUserInformation> ListInvitedUsers { get; set; }
        public List<DbUserInformation> ListNotAttendingUsers { get; set; }


        public class UserAdsModel
        {
            public int EventId { get; set; }
            public int UserId { get; set; }
            public string Email { get; set; }
            [Required(ErrorMessage = "Title is required.")]
            public string Title { get; set; }
            [Required(ErrorMessage = "Price is required.")]
            public int Price { get; set; }
            public int Phone { get; set; }
            public int MaxGuests { get; set; }
            public bool HideImportantInformation { get; set; }
            [Required(ErrorMessage = "Description is required.")]
            public string EventDescription { get; set; }
            public string ImageUrl { get; set; }
            public int CategoryId { get; set; }
            public int GenderId { get; set; }
            public int CountyId { get; set; }
            public int MunicipalityId { get; set; }
            public DateTime PublishDate { get; set; }
            public DateTime ExpirationDate { get; set; }

        }
    }
}