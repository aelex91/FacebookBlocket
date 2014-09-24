using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace BlocketProject.Models.Pages
{
    [ContentType(DisplayName = "ProfilePage", GUID = "da1a2f04-9aa4-42b9-817d-ac845bc95bb0", Description = "")]
    public class ProfilePage : SitePageData
    {

        [CultureSpecific]
        [Display(
            Name = "Heading",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Reference to EditPage",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual PageReference PagereferToEditPage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "First name label",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual string LabelFirstName { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Last name label",
            GroupName = SystemTabNames.Content,
            Order = 400)]
        public virtual string LabelLastName { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Email adress Label",
            GroupName = SystemTabNames.Content,
            Order = 500)]
        public virtual string LabelEmail { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Location Label",
            GroupName = SystemTabNames.Content,
            Order = 600)]
        public virtual string LabelLocation { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Phone Label",
            GroupName = SystemTabNames.Content,
            Order = 700)]
        public virtual string LabelPhone { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Button Label",
            GroupName = SystemTabNames.Content,
            Order = 800)]
        public virtual string LabelButton { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Upload Image Label",
            GroupName = SystemTabNames.Content,
            Order = 900)]
        public virtual string LabelImageUpload { get; set; }

        [Required]
        [CultureSpecific]
        [Display(
            Name = "Event redirect",
            Description = "Set this redirect to the EventPage where you list all events.",
            GroupName = SystemTabNames.Content,
            Order = 1000)]
        public virtual PageReference EventRedirect { get; set; }



        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            Heading = "Heading";
            LabelButton = "Save Profile.";
        }

    }
}