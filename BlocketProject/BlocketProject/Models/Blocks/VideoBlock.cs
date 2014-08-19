using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using EPiServer;

namespace BlocketProject.Models.Blocks
{
    [ContentType(DisplayName = "VideoBlock", GUID = "0f76473c-ef14-46b4-9b90-fe7d99649fe2", Description = "")]
    public class VideoBlock : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Video Title",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Video file",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string VideoFile { get; set; }

        [Display(
                    Order = 300)]
        [UIHint(UIHint.Image)]
        public virtual Url Image { get; set; }

        [Display(
            Name = "Autoplay",
            Order = 400
            )]
        public virtual Boolean Autoplay { get; set; }


        [Display(
            Name = "Display Title",
            Order = 500
            )]
        public virtual Boolean ShowTitle { get; set; }

 
    }
}