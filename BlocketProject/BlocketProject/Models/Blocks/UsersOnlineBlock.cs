using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer;
using EPiServer.Web;

namespace BlocketProject.Models.Blocks
{
    [ContentType(DisplayName = "UsersOnlineBlock", GUID = "c42e6ea6-aa18-4248-b3d2-d2d87fcc962f", Description = "")]
    public class UsersOnlineBlock : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Name",
            Description = "Name field's description",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Name { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Logo for male",
            Description = "Name field's description",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        [UIHint(UIHint.Image)]
        public virtual Url Logomale { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Logo for female",
            Description = "Name field's description",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        [UIHint(UIHint.Image)]
        public virtual Url Logofemale { get; set; }



    }
}