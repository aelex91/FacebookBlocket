using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace BlocketProject.Models.Pages
{
    [ContentType(DisplayName = "StartPage", GUID = "061a1365-7fd6-4f72-ad76-4e8f349029ba", Description = "")]
    public class StartPage : PageGroup
    {
                [CultureSpecific]
                [Display(
                    Name = "Set width",
                    Description = "Set the width of the header",
                    GroupName = SystemTabNames.Content,
                    Order = 200)]
                [Range(1, 12)]
                public virtual int SizeCount { get; set; }
         
    }
}