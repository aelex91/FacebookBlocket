using BlocketProject.Models.DbClasses;
using BlocketProject.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class ProfilePageViewModel
    {
        public ProfilePageViewModel(ProfilePage currentPage)
        {
            Heading = currentPage.Heading;

        }
        public string Heading { get; set; }

        public class FacebookUserModel
        {
            public int? UserId { get; set; }
            public string FacebookId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string ImageUrl { get; set; }

        }

    }
}