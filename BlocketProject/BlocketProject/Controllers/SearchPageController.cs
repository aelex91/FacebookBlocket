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
            if (lists != null)
            {
                model.eventResults = lists.eventResults;
                model.userResults = lists.userResults;
                model.SearchQuery = lists.SearchQuery;
                model.EventModelList = lists.EventModelList;
                model.UserHtmlStringDictionary = lists.UserHtmlStringDictionary;
            }

            return View(model);

        }


        [HttpPost]
        public ActionResult Search(string searchField, SearchPage currentPage)
        {
            SearchPageViewModel model = new SearchPageViewModel();
            var page = new SearchPage();
            var pageReference = page.StartPage.SearchPageUrl;
            if (searchField != null && searchField != "")
            {
                model = ConnectionHelper.Search(searchField);
                model.SearchQuery = searchField;

                var eventDictionary = new Dictionary<int, SearchPageViewModel.EventModel>();
                var userDictionary = new Dictionary<int, MvcHtmlString>();

                foreach (var _event in model.eventResults)
                {
                    SearchPageViewModel.EventModel eventModel = new SearchPageViewModel.EventModel();
                    if (!eventDictionary.ContainsKey(_event.EventId))
                    {
                        if (_event.EventDescription.ToLower().Contains(model.SearchQuery.ToLower()))
                        {
                            var position = _event.EventDescription.ToLower().IndexOf(model.SearchQuery.ToLower());
                            var searchTerm = _event.EventDescription.Substring(position, model.SearchQuery.Length);
                            var newEventString = _event.EventDescription.Remove(position, model.SearchQuery.Length).Insert(position, "<b>" + searchTerm + "</b>");
                            var htmlEventString = new MvcHtmlString(newEventString);
                            eventModel.EventHtmlString = htmlEventString;
                        }
                        else
                        {
                            eventModel.EventHtmlString = new MvcHtmlString(_event.EventDescription);
                        }
                        if (_event.Title.ToLower().Contains(model.SearchQuery.ToLower()))
                        {
                            var position = _event.Title.ToLower().IndexOf(model.SearchQuery.ToLower());
                            var searchTerm = _event.Title.Substring(position, model.SearchQuery.Length);
                            var newEventTitleString = _event.Title.Remove(position, model.SearchQuery.Length).Insert(position, "<b>" + searchTerm + "</b>");
                            var htmlEventTitleString = new MvcHtmlString(newEventTitleString);
                            eventModel.EventTitleHtmlString = htmlEventTitleString;
                        }
                        else
                        {
                            eventModel.EventTitleHtmlString = new MvcHtmlString(_event.Title);
                        }

                        eventDictionary.Add(_event.EventId, eventModel);
                    }
                    else
                    {
                        continue;
                    }
                }

                foreach (var user in model.userResults)
                {

                    var htmlUserString = new MvcHtmlString(null);
                    var newUserName = user.FirstName + " " + user.LastName;
                    if (newUserName.ToLower().Contains(model.SearchQuery.ToLower()))
                    {
                        var position = newUserName.ToLower().IndexOf(model.SearchQuery.ToLower());
                        var searchTerm = newUserName.Substring(position, model.SearchQuery.Length);
                        newUserName = newUserName.Remove(position, model.SearchQuery.Length).Insert(position, "<b>" + searchTerm + "</b>");
                        htmlUserString = new MvcHtmlString(newUserName);
                    }
                    else
                    {
                        htmlUserString = new MvcHtmlString(newUserName);
                    }
                    
                    userDictionary.Add(user.UserId, htmlUserString);
                }

                model.EventModelList = eventDictionary;
                model.UserHtmlStringDictionary = userDictionary;
                model.NumberOfResults = model.EventModelList.Count() + model.UserHtmlStringDictionary.Count();

                if (currentPage != null)
                {
                    return View("Index", model);
                }
                else
                {

                    Session["Model"] = model;

                    return RedirectToAction("Index", pageReference);
                }
            }
            else if (currentPage == null)
            {
                Session["Model"] = model;
                return RedirectToAction("Index", pageReference);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }



    }
}
