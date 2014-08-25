using BlocketProject.Models.Blocks;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class PageListBlockViewModel
    {
        public ContentReference ContentRef { get; set; }
        public List<PageData> ListPages { get; set; }
        public PageListBlockViewModel(PageListBlock currentBlock)
        { 
        }
    }
}