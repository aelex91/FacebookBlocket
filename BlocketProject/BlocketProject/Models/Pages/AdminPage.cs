using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace BlocketProject.Models.Pages
{
    [ContentType(DisplayName = "AdminPage", GUID = "9119bfc4-8bcf-4239-b1a7-e677790c2f21", Description = "This page is created to list all users from the facebook database. Here you can remove,block and add users.")]
    public class AdminPage : PageData
    {
        
                [CultureSpecific]
                [Display(
                    Name = "Header",
                    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                    GroupName = SystemTabNames.Content,
                    Order = 100)]
                public virtual string Header { get; set; }
         
    }
}