using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace BlocketProject.Models.Pages
{
    [ContentType(DisplayName = "PageGroup", GUID = "21be8b82-c253-434b-942e-77442232fdd0", Description = "")]
    public class PageGroup : PageData
    {

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Content Area",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual ContentArea ContentArea { get; set; }

    }
}