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
    }
}