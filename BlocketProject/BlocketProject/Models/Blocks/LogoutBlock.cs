using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace BlocketProject.Models.Blocks
{
    [ContentType(DisplayName = "LogoutBlock", GUID = "5eed3554-fce2-414b-a443-357b8f9eafe0", Description = "")]
    public class LogoutBlock : BlockData
    {
        
                [CultureSpecific]
                [Display(
                    Name = "Button text",
                    Description = "Text that will be displayed on the logout button.",
                    GroupName = SystemTabNames.Content,
                    Order = 100)]
                public virtual String ButtonText { get; set; }


                public override void SetDefaultValues(ContentType contentType)
                {
                    base.SetDefaultValues(contentType);
                    ButtonText = "Logout";
                }
    }
}