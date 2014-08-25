using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using BlocketProject.Models.Blocks;
using BlocketProject.Models.Pages;
using EPiServer.ServiceLocation;
using BlocketProject.Models.ViewModels;

namespace BlocketProject.Controllers
{
    public class PageListBlockController : BlockController<PageListBlock>
    {
        public override ActionResult Index(PageListBlock currentBlock)
        {
            var model = new PageListBlockViewModel(currentBlock);

           model.ListPages = GetAllPages(currentBlock);
            return PartialView(model);
        }

        public List<PageData> GetAllPages(PageListBlock block)
        {

            var pageRouteHelper = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.Web.Routing.PageRouteHelper>();
            PageReference currentPageLink = pageRouteHelper.PageLink;
            PageData currentPage = pageRouteHelper.Page;
            var serviceLocator = ServiceLocator.Current.GetInstance<IContentLoader>();

            var children = serviceLocator.GetChildren<PageData>(block.ListRoot);
            return children.ToList();
        }
    }
}
