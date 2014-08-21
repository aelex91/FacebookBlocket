using BlocketProject.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class AdsPageViewModel
    {
        public AdsPageViewModel(AdsPage currentPage)
        {

        }
        public class UserAds
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int Price { get; set; }
            public string AdDescription { get; set; }
            public string ImageUrl { get; set; }
            public DateTime PublishDate { get; set; }
            public int CategoryId { get; set; }
        }
    }
}