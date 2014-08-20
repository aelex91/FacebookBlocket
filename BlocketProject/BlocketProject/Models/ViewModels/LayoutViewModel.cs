using BlocketProject.Models.Blocks;
using BlocketProject.Models.Pages;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class LayoutViewModel
    {
        public PageData currentpage { get; set; }
        public int SizeCount { get; set; }
    }
}