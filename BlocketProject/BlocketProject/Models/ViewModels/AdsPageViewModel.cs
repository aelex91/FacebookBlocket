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
        }
        
        

        public List<UserAdsModel> ListUserAdsModel { get; set; }
        public List<UserAdsModel> ListCurrentUserAdsModel { get; set; }
        public string Heading { get; set; }
        public bool CurrentUserAds { get; set; }
        public string AdCategory { get; set; }

        public class UserAdsModel
        {
            public int? UserId { get; set; }
            public int EventId { get; set; }
              [Required(ErrorMessage = "Title is required.")]
            public string Title { get; set; }
             [Required(ErrorMessage = "Price is required.")]
            public int Price { get; set; }
             [Required(ErrorMessage = "Description is required.")]
            public string EventDescription { get; set; }
            public string ImageUrl { get; set; }
            public DateTime PublishDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public int CategoryId { get; set; }
            public int SubCategoryId { get; set; }
            public string Text { get; set; }
        }
    }
}