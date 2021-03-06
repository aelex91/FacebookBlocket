﻿using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer;
using EPiServer.Web;

namespace BlocketProject.Models.Pages
{
    [ContentType(DisplayName = "CreateAdPage", GUID = "9b55474a-cae0-4882-8f1b-1b0c084433c6", Description = "")]
    public class CreateAdPage : PageData
    {

        [CultureSpecific]
        [Display(
            Name = "Heading for page",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "NameLabel",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string Namelabel { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Email Label",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual string EmailLabel { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Zip code Label",
            GroupName = SystemTabNames.Content,
            Order = 340)]
        public virtual string ZipCodeLabel { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Phone Label",
            GroupName = SystemTabNames.Content,
            Order = 500)]
        public virtual string PhoneLabel { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Category Label",
            GroupName = SystemTabNames.Content,
            Order = 600)]
        public virtual string CategoryLabel { get; set; }


        [CultureSpecific]
        [Display(
            Name = "TextLabel",
            GroupName = SystemTabNames.Content,
            Order = 700)]
        public virtual string TextLabel { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Price Label",
            GroupName = SystemTabNames.Content,
            Order = 800)]
        public virtual string PriceLabel { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Upload Image Label",
            GroupName = SystemTabNames.Content,
            Order = 900)]
        public virtual string UploadImageLabel { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Button Label",
            GroupName = SystemTabNames.Content,
            Order = 1000)]
        public virtual string ButtonLabel { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Title for Event Label",
            GroupName = SystemTabNames.Content,
            Order = 1100)]
        public virtual string EventLabel { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Label for persons",
            GroupName = SystemTabNames.Content,
            Order = 1150)]
        public virtual string PersonLabel { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Set number of ads",
            Description = "Set the number of ads you want a user to be avaliable to create",
            GroupName = SystemTabNames.Content,
            Order = 1200)]
        public virtual int NumberOfEvents { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Refer to Landing Page",
            Description = "Redirects users to the Landing Page.",
            GroupName = SystemTabNames.Content,
            Order = 1300)]
        public virtual ContentReference ReferenceToLandingPage { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Set default image.",
            Description = "Set default image when a user creates an event.",
            GroupName = SystemTabNames.Content,
            Order = 1400)]
        [UIHint(UIHint.Image)]
        public virtual Url DefaultImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Datelabel",
            GroupName = SystemTabNames.Content,
            Order = 1500)]
        public virtual string DateLabel { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {

            base.SetDefaultValues(contentType);
            Heading = "";
            Namelabel = "Namn";
            EmailLabel = "Email";
            PhoneLabel = "Telefon";
            CategoryLabel = "Kategori";
            EventLabel = "Rubrik";
            TextLabel = "Text";
            PriceLabel = "Pris";
            UploadImageLabel = "Ladda upp bild";
            ButtonLabel = "Ladda upp annons";
            NumberOfEvents = 5;
            ButtonLabel = "Ladda upp evenemanget";
            ZipCodeLabel = "Postnummer";
            PersonLabel = "Antal Personer";
            DateLabel = "Välj datum";

        }

    }

}