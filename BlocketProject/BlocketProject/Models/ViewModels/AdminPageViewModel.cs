using BlocketProject.Models.DbClasses;
using BlocketProject.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class AdminPageViewModel
    {
        public AdminPageViewModel(AdminPage currentPage)
        {

            this.Heading = currentPage.Header;
        }
        public string Heading { get; set; }
        public List<DbUserInformation> GetFacebookUsers { get; set; }
    }
}