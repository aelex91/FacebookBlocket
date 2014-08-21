using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace BlocketProject.Models.Pages
{
    [ContentType(DisplayName = "AdsPage", GUID = "93f82d57-f1b8-473f-9ba1-14843f10b8c5", Description = "")]
    public class AdsPage : PageData
    {

        [CultureSpecific]
        [Display(
            Name = "Title",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Category",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string AdCategory { get; set; }

    }
}