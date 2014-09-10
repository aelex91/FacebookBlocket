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
                    Order = 1)]
                public virtual string Heading { get; set; }

                public override void SetDefaultValues(ContentType contentType)
                {
                    base.SetDefaultValues(contentType);
                    Heading = "Heading";
                }
         
    }
}