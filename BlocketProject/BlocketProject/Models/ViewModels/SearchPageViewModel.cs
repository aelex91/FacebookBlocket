using BlocketProject.Models.DbClasses;
using BlocketProject.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public string SearchQuery { get; set; }
        public Dictionary<int, EventModel> EventModelList { get; set; }
        public Dictionary<int, MvcHtmlString> UserHtmlStringDictionary { get; set; }
        public int NumberOfResults { get; set; }

        public class EventModel
        {
            public MvcHtmlString EventHtmlString { get; set; }
            public MvcHtmlString EventTitleHtmlString { get; set; }
        }
    }

}