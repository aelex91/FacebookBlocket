using BlocketProject.Helpers;
using BlocketProject.Models.DbClasses;
using BlocketProject.Models.Pages;
using BlocketProject.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlocketProject.Controllers
{
    public class SearchPageController : PageController<SearchPage>
    {

        public ActionResult Index(SearchPage currentPage)
        {
            SearchPageViewModel lists = (SearchPageViewModel)Session["Model"];
            Session.Clear();
            var model = new SearchPageViewModel(currentPage);
            model.eventResults = lists.eventResults;
            model.userResults = lists.userResults;
            model.SearchQuery = lists.SearchQuery;

            return View(model);
        }

        [HttpPost]
        public ActionResult Search(string searchField)
        {
            var model = new SearchPageViewModel();
            var page = new SearchPage();
            var pageReference = page.StartPage.SearchPageUrl;
            model = ConnectionHelper.Search(searchField);
            model.SearchQuery = searchField;
            Session["Model"] = model;

            return RedirectToAction("Index", pageReference);
        }



    }
}
