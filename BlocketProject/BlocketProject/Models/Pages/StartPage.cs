using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace BlocketProject.Models.Pages
{
    [ContentType(DisplayName = "StartPage", GUID = "061a1365-7fd6-4f72-ad76-4e8f349029ba", Description = "")]
    public class StartPage : PageData
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

        public override void SetDefaultValues(ContentType contentType)
        {

            base.SetDefaultValues(contentType);

            LoginRedirect = PageReference.StartPage;
            FacebookButtonText = "Logga in med";
        }

    }

}