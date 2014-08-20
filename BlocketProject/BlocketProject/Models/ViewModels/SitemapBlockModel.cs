using BlocketProject.Models.Blocks;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class SitemapBlockModel
    {
        public string Heading { get; set; }
        public PageReference Listroot { get; set; }
        public IEnumerable<PageData> Pages { get; set; }
        public PageData Startpage { get; set; }
        public List<IContent> getPages { get; set; }

        public SitemapBlockModel(SitemapBlock block)
        {
            Heading = block.heading;
            Listroot = block.listRoot;

        }
    }
}