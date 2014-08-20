using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer;

namespace BlocketProject.Models.Blocks
{
    [ContentType(DisplayName = "SitemapBlock", GUID = "5dc381e5-90e9-487b-bd25-12728c0ca28d", Description = "")]
    public class SitemapBlock : SiteblockData
    {

        [CultureSpecific]
        [Display(
            Name = "Set root page",
            // Description = "Name field's description",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual PageReference listRoot { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Heading",
            // Description = "Name field's description",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string heading { get; set; }

        
    }
}