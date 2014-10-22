using BlocketProject.Models.Pages;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class CustomNavPageViewModel
    {
        public List<PageData> AvailablePageList { get; set; }
        public List<PageData> SelectedPageList { get; set; }
    }
}