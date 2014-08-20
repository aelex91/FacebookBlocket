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
using EPiServer.ServiceLocation;
using BlocketProject.Models.Pages;
using BlocketProject.Models.ViewModels;
using EPiServer.Filters;


namespace BlocketProject.Controllers
{
    public class SitemapBlockController : BlockController<SitemapBlock>
    {

        public override ActionResult Index(SitemapBlock currentBlock)
        {
            var pages = GetChildren(currentBlock.listRoot);
            var repository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var startPage = repository.Get<StartPage>(PageReference.StartPage);


            var model = new SitemapBlockModel(currentBlock)
            {
                Listroot = currentBlock.listRoot,
                Pages = pages,
                Startpage = startPage,
            };
            model.getPages = Filter(pages, currentBlock.listRoot).ToList();
            return PartialView(model);
        }



        public List<PageData> GetChildren(PageReference pageLink)
        {
            var pages = new List<PageData>();
            var repository = ServiceLocator.Current.GetInstance<IContentRepository>();
            PageReference listRoot = pageLink;
            if (listRoot != null)
            {
                var child = repository.GetChildren<PageData>(listRoot);
                pages = child.ToList();
            }
            return pages;

        }
        private IEnumerable<IContent> Filter(IEnumerable<IContent> contentItems, PageReference PageListRoot)
        {
            var repository = ServiceLocator.Current.GetInstance<IContentRepository>();
            PageReference rootLink = PageListRoot;
            var footerLevelPages = repository.GetChildren<PageData>(rootLink);
            footerLevelPages = FilterForVisitor.Filter(footerLevelPages).OfType<PageData>().Where(x => x.VisibleInMenu);
            return footerLevelPages;
        }
    }
}
