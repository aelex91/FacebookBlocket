using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace BlocketProject.Models.Pages
{
    [ContentType(DisplayName = "AdLandingPage", GUID = "1f3e32e3-1d74-4c71-bc5a-e9e52f7298e2", Description = "")]
    public class AdLandingPage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading of the landing page.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Heading { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            Heading = "Thank you ";
        }

    }
}