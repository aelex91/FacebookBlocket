using BlocketProject.Models.Pages;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class AdLandingPageViewModel
    {
        public string Heading { get; set; }
        public XhtmlString MainBody { get; set; }

        public AdLandingPageViewModel(AdLandingPage currentPage)
        {
            Heading = currentPage.Heading;
            MainBody = currentPage.MainBody;

        }

        public BlocketProject.Models.ViewModels.AdLandingPageViewModel.FacebookUserModel Fbuser { get; set; }

        public class FacebookUserModel
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
        }
    }
}