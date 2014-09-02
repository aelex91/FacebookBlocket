using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer;
using System.Collections.Generic;
using EPiServer.Web;

namespace BlocketProject.Models.Blocks
{
    [ContentType(DisplayName = "InformationBlock", GUID = "0ad25181-c75b-41f2-b06d-b322edc5fd2a", Description = "")]
    public class InformationBlock : BlockData
    {
        [UIHint(UIHint.Image)]
        [Display(
        Name = "Image",
        Description = "",
        GroupName = SystemTabNames.Content,
        Order = 100)]
        public virtual Url Image { get; set; }

        [Display(
        Name = "Information",
        Description = "",
        GroupName = SystemTabNames.Content,
        Order = 200)]
        public virtual string Information { get; set; }

        [Display(
        Name = "Button text",
        Description = "",
        GroupName = SystemTabNames.Content,
        Order = 300)]
        public virtual string ButtonText { get; set; }
    }
}