using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using BlocketProject.Models.Pages;
using BlocketProject.Models.ViewModels;
using EPiServer.Personalization;

namespace BlocketProject.Controllers
{
    public class CustomNavPageController : PageController<CustomNavPage>
    {
        public ActionResult Index(CustomNavPage currentPage)
        {
            CustomNavPageViewModel model = new CustomNavPageViewModel();
            if ((CustomNavPageViewModel)Session["model"] != null)
            {
                model = (CustomNavPageViewModel)Session["model"];
            }
                
            else
            {
                model.AvailablePageList = GetAvailablePages();
                model.SelectedPageList = new List<PageData>();
            }
            Session["model"] = model;

            return View(model);
        }

        public ActionResult SetCustomLinks(int pageID)
        {
            var model = (CustomNavPageViewModel)Session["model"];
            Session.Clear();
            var selectedPage = new PageData();
            if (model.SelectedPageList == null || model.SelectedPageList.Count == 0)
            {
                model.SelectedPageList = new List<PageData>();
            }
            if (model.AvailablePageList != null || model.AvailablePageList.Count != 0)
            {
                foreach (var page in model.AvailablePageList)
                {
                    if (page.ContentLink.ID == pageID)
                    {
                        model.SelectedPageList.Add(page);
                        selectedPage = page;
                    }
                    else 
                    {
                        continue;
                    }
                }
                model.AvailablePageList.Remove(selectedPage);
            }

            Session["model"] = model;

            return View("Index", model);
        }

        public ActionResult RemoveCustomLinks(int pageID)
        {
            var model = (CustomNavPageViewModel)Session["model"];
            Session.Clear();
            var selectedPage = new PageData();
            if (model.AvailablePageList == null || model.AvailablePageList.Count == 0)
            {
                model.AvailablePageList = new List<PageData>();
            }
            if (model.SelectedPageList != null || model.SelectedPageList.Count != 0)
            {
                foreach (var page in model.SelectedPageList)
                {
                    if (page.ContentLink.ID == pageID)
                    {
                        model.AvailablePageList.Add(page);
                        selectedPage = page;
                    }
                }
                model.SelectedPageList.Remove(selectedPage);
            }

            Session["model"] = model;

            return View("Index", model);
        }

        public List<PageData> GetAvailablePages()
        {
            var availablePageList = new List<PageData>();
            var pageList = DataFactory.Instance.GetChildren(PageReference.StartPage);
            availablePageList.Add(DataFactory.Instance.GetPage(PageReference.StartPage));

            foreach (var page in pageList)
            {
                availablePageList.Add(page);
            }
            
            return availablePageList;
        }

    }
}