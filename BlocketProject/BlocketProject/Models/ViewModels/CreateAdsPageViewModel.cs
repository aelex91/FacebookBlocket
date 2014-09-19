using BlocketProject.Models.DbClasses;
using BlocketProject.Models.Pages;
using EPiServer;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlocketProject.Models.ViewModels
{
    public class CreateAdsPageViewModel
    {
        public CreateAdsPageViewModel() { }
        public CreateAdsPageViewModel(CreateAdPage currentPage)
        {
            this.DefaultImage = currentPage.DefaultImage;
            this.Heading = currentPage.Heading;
            this.NameLabel = currentPage.Namelabel;
            this.EmailLabel = currentPage.EmailLabel;
            this.Phonelabel = currentPage.PhoneLabel;
            this.CategoryLabel = currentPage.CategoryLabel;
            this.TextLabel = currentPage.TextLabel;
            this.PriceLabel = currentPage.PriceLabel;
            this.UploadImageLabel = currentPage.UploadImageLabel;
            this.ButtonLabel = currentPage.ButtonLabel;
            this.EventLabel = currentPage.EventLabel;
            this.PersonLabel = currentPage.PersonLabel;
            this.DateLabel = currentPage.DateLabel;

        }

        public string DateLabel { get; set; }
        public string Heading { get; set; }
        public string NameLabel { get; set; }
        public string EmailLabel { get; set; }
        public string Phonelabel { get; set; }
        public string CategoryLabel { get; set; }
        public string PriceLabel { get; set; }
        public string UploadImageLabel { get; set; }
        public string ButtonLabel { get; set; }
        public string EventLabel { get; set; }
        public string ErrorMessage { get; set; }
        public string PersonLabel { get; set; }
        public Url DefaultImage { get; set; }
        public string TextLabel { get; set; }
        public CreateEvent CreateEvent { get; set; }
        public BlocketProject.Models.ViewModels.ProfilePageViewModel.UserInformation CurrentUser { get; set; }

    }
    public class CreateEvent
    {

        [Required(ErrorMessage = "Vänligen fyll i Email")]
        [EmailAddress]
        public string Email { get; set; }
        [PhoneAttribute]
        [Range(0, int.MaxValue, ErrorMessage = "Ange ett korrekt telefon nummer")]
        public string Phone { get; set; }
        [Required]
        public string EventTitle { get; set; }
        public string Price { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "Annonstexten får max vara {1} tecken lång")]
        public string Text { get; set; }
        public bool HideInformation { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Välj ett korrekt värde")]
        public string MaxGuests { get; set; }

        public Dictionary<int, string> Category { get; set; }
        public Dictionary<int, string> Genders { get; set; }
        public Dictionary<int, string> County { get; set; }
        public Dictionary<int, string> Municipality { get; set; }
        //Categories
        [Required]
        public string SelectedCategory { get; set; }
        [Required]
        public string SelectedGender { get; set; }
        [Required]
        public string SelectedCounty { get; set; }
        [Required]
        public string SelectedMunicipality { get; set; }
    }
}