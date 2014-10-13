using BlocketProject.Models.DbClasses;
using BlocketProject.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class SearchPageViewModel
    {
        public SearchPageViewModel(SearchPage currentPage)
        {
        }
        public SearchPageViewModel()
        {
        }
        public List<DbUserInformation> userResults { get; set; }
        public List<DbUserEvents> eventResults { get; set; }
    }

}