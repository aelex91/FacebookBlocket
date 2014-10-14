using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace BlocketProject.Models.Pages
{
    [ContentType(DisplayName = "StartPage", GUID = "061a1365-7fd6-4f72-ad76-4e8f349029ba", Description = "")]
    public class StartPage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Content Area",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual ContentArea ContentArea { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main Body",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual XhtmlString MainBody { get; set; }

        [Required]
        [Display(
            Name = "Login redirect URL",
            Description = "Specify which page you want your user to be redirected to after signing in.",
            Order = 300
            )]
        public virtual PageReference LoginRedirect { get; set; }

        [Required]
        [Display(
            Name = "Facebookbutton text",
            Description = "The text that will be displayed on the 'Sign in with facebook'-button.",
            Order = 400
            )]
        public virtual string FacebookButtonText { get; set; }

        [Required]
        [CultureSpecific]
        [Display(
            Name = "Invitation Message Title",
            Description = "Title of the message that will be sent to invited users. Use [EventName] or [User] tag if you want them to be a part of the title.",
            GroupName = SystemTabNames.Content,
            Order = 500)]
        public virtual string InvitationMessageTitle { get; set; }

        [Required]
        [CultureSpecific]
        [Display(
            Name = "Invitation Message",
            Description = "The message that will be sent when a user invites others to their event. Always specify a part in the message which contains these tags '[EventName]' or '[User]' if you want to link to the specific event and user in the message.",
            GroupName = SystemTabNames.Content,
            Order = 600)]
        public virtual string InvitationMessage { get; set; }

        [Required]
        [CultureSpecific]
        [Display(
            Name = "Search Page URL",
            Description = "Select your created SearchPage where the users will see their search results.",
            GroupName = SystemTabNames.Content,
            Order = 700)]
        public virtual PageReference SearchPageUrl { get; set; }

        [Required]
        [CultureSpecific]
        [Display(
            Name = "First FooterLink",
            Description = "Select your desired PageReference that will be shown in the right column of the footer. Various information about e.x. cookies, user agreement etc. is recommended.",
            GroupName = SystemTabNames.Content,
            Order = 800)]
        public virtual PageReference FooterPageReference1 { get; set; }

        [Required]
        [CultureSpecific]
        [Display(
            Name = "Second FooterLink",
           Description = "Select your desired PageReference that will be shown in the right column of the footer. Various information about e.x. cookies, user agreement etc. is recommended.",
            GroupName = SystemTabNames.Content,
            Order = 800)]
        public virtual PageReference FooterPageReference2 { get; set; }

        [Required]
        [CultureSpecific]
        [Display(
            Name = "Third FooterLink",
            Description = "Select your desired PageReference that will be shown in the right column of the footer. Various information about e.x. cookies, user agreement etc. is recommended.",
            GroupName = SystemTabNames.Content,
            Order = 800)]
        public virtual PageReference FooterPageReference3 { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Fourth FooterLink",
            Description = "Select your desired PageReference that will be shown in the right column of the footer. Various information about e.x. cookies, user agreement etc. is recommended.",
            GroupName = SystemTabNames.Content,
            Order = 800)]
        public virtual PageReference FooterPageReference4 { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {

            base.SetDefaultValues(contentType);

            LoginRedirect = PageReference.StartPage;
            FacebookButtonText = "Logga in med";
        }

    }

}