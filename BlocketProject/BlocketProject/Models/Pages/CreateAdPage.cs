using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

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
            Name = "Ad Description Label",
            GroupName = SystemTabNames.Content,
            Order = 700)]
        public virtual string AdDescriptionLabel { get; set; }

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
            Name = "Title for ad Label",
            GroupName = SystemTabNames.Content,
            Order = 1100)]
        public virtual string TitleLabel { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {

            base.SetDefaultValues(contentType);
            Heading = "";
            Namelabel = "Namn";
            EmailLabel = "Email";
            PhoneLabel = "Telefon";
            CategoryLabel = "Kategori";
            TitleLabel = "Rubrik";
            AdDescriptionLabel = "Text";
            PriceLabel = "Pris";
            UploadImageLabel = "Ladda upp bild";
            ButtonLabel = "Ladda upp annons";

        }

    }

}