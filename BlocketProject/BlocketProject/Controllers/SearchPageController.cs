using BlocketProject.Helpers;
using BlocketProject.Models.Pages;
using BlocketProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlocketProject.Controllers
{
    public class SearchPageController : Controller
    {

        public ActionResult Search(SearchPage currentPage)
        {
            var model = new SearchPageViewModel(currentPage);
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchField)
        {
            var model = new SearchPageViewModel();
            model = ConnectionHelper.Search(searchField);

            return View("Search", model);
        }

    }
}
