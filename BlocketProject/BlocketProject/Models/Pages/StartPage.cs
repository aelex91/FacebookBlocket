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
    }
}