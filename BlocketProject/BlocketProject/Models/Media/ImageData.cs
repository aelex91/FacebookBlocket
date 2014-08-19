using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace BlocketProject.Models.Media
{
    [ContentType(DisplayName = "ImageData", GUID = "98126e9a-5d45-472c-a60c-e2886aacb3ad", Description = "")]
    public class ImageData : MediaData, IContentImage
    {
        [ImageDescriptor(Width = 48, Height = 48)]
        public override EPiServer.Framework.Blobs.Blob Thumbnail
        {
            get {return base.Thumbnail;}
            set {base.Thumbnail = value;}
        }
    }
}