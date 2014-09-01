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
        }

        public List<UserAdsModel> ListUserAdsModel { get; set; }
        public string Heading { get; set; }
        public string AdCategory { get; set; }

        public class UserAdsModel
        {
            public int? UserId { get; set; }
            public int AdId { get; set; }
              [Required(ErrorMessage = "Title is required.")]
            public string Title { get; set; }
             [Required(ErrorMessage = "Price is required.")]
            public int Price { get; set; }
             [Required(ErrorMessage = "Description is required.")]
            public string AdDescription { get; set; }
            public string ImageUrl { get; set; }
            public string PublishDate { get; set; }
            public int CategoryId { get; set; }
        }
    }
}