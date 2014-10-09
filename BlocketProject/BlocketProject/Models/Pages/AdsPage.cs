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

        [Required]
        [CultureSpecific]
        [Display(
            Name = "Invitation Message Title",
            Description = "Title of the message that will be sent to invited users. Use [EventName] or [User] tag if you want them to be a part of the title.",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string InvitationMessageTitle { get; set; }

        [Required]
        [CultureSpecific]
        [Display(
            Name = "Invitation Message",
            Description = "The message that will be sent when a user invites others to their event. Always specify a part in the message which contains these tags '[EventName]', '[User]' if you want to link to the specific event and user in the message.",
            GroupName = SystemTabNames.Content,
            Order = 210)]
        public virtual string InvitationMessage { get; set; }

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