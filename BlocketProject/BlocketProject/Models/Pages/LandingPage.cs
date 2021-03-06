﻿using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace BlocketProject.Models.Pages
{
    [ContentType(DisplayName = "LandingPage", GUID = "1f3e32e3-1d74-4c71-bc5a-e9e52f7298e2", Description = "")]
    public class LandingPage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading of the landing page.",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Heading { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Content Area",
            Description = "Idea for this content area is for information blocks so a user knows what to do ",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual ContentArea ContentArea { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            Heading = "Thank you ";
        }

    }
}