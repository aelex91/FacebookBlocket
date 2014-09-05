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
            Name = "Heading",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Ad Category",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string AdCategory { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Only show current users ads",
            Description = "Checking this will only show the ads from the currently active user.",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual bool CurrentUserAds { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            Heading = "Ads";
            CurrentUserAds = false;
        }




    }
}