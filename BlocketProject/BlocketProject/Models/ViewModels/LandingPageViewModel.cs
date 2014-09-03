using BlocketProject.Models.Pages;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class LandingPageViewModel
    {
        public string Heading { get; set; }
        public XhtmlString MainBody { get; set; }

        public LandingPageViewModel(LandingPage currentPage)
        {
            Heading = currentPage.Heading;
            MainBody = currentPage.MainBody;

        }

        public BlocketProject.Models.ViewModels.LandingPageViewModel.FacebookUserModel Fbuser { get; set; }

        public class FacebookUserModel
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
        }
    }
}