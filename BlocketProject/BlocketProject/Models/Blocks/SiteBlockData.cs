using EPiServer.Core;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.Blocks
{
    public abstract class SiteblockData : BlockData
    {
        public PageData CurrentPage
        {
            get
            {
                var pageRouteHelper = ServiceLocator.Current.GetInstance<EPiServer.Web.Routing.PageRouteHelper>();
                PageData currentPage = pageRouteHelper.Page;
                return currentPage;
            }


        }
        
    
    }
}