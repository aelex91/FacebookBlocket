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
                    Name = "Heading",
                    GroupName = SystemTabNames.Content,
                    Order = 100)]
                public virtual string Heading { get; set; }
         
    }
}