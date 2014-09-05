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
        public string ErrorMessage { get; set; }
        public XhtmlString MainBody { get; set; }
        public FacebookUserModel Fbuser { get; set; }
        public LandingPageViewModel(LandingPage currentPage)
        {
            Heading = currentPage.Heading;
            MainBody = currentPage.MainBody;

        }

      

        public class FacebookUserModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}