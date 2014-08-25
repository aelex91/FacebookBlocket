using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace BlocketProject.Models.Blocks
{
    [ContentType(DisplayName = "PageListBlock", GUID = "d70dc683-feab-47f0-8663-c056729c7475", Description = "")]
    public class PageListBlock : BlockData
    {
        
                [CultureSpecific]
                [Display(
                    Name = "Heading",
                    GroupName = SystemTabNames.Content,
                    Order = 100)]
                public virtual String Heading { get; set; }

                [CultureSpecific]
                [Display(
                    Name = "List Pages",
                    GroupName = SystemTabNames.Content,
                    Order = 200)]
                public virtual ContentReference ListRoot { get; set; }
         
    }
}