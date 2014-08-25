using BlocketProject.Models.Pages;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class StandardPageViewModel
    {
        public ContentReference ContentRef { get; set; }
        public string PageName { get; set; }
        public XhtmlString MainBody { get; set; }
        public ContentArea CArea { get; set; }
        public List<StandardPage> ListStandardPages { get; set; }
        public StandardPageViewModel(StandardPage currentPage)
        {
            this.ContentRef = currentPage.ContentReference;
            this.MainBody = currentPage.MainBody;
            this.PageName = currentPage.Name;
            this.CArea = currentPage.ContentArea;

        }
    }
}