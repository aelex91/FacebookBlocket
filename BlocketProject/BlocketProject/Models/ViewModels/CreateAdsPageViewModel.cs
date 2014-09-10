using BlocketProject.Models.DbClasses;
using BlocketProject.Models.Pages;
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
            this.TitleLabel = currentPage.TitleLabel;
            this.LabelPerson = currentPage.PersonLabel;


        }
        public string Heading { get; set; }
        public string NameLabel { get; set; }
        public string EmailLabel { get; set; }
        public string Phonelabel { get; set; }
        public string CategoryLabel { get; set; }
        public string PriceLabel { get; set; }
        public string UploadImageLabel { get; set; }
        public string ButtonLabel { get; set; }
        public string TitleLabel { get; set; }
        public string ErrorMessage { get; set; }
        public string LabelPerson { get; set; }
        public EPiServer.Url DefaultImage { get; set; }
        public string TextLabel { get; set; }
        public CreateEvent CreateEvent { get; set; }
        public DbUserInformation CurrentUser { get; set; }
        // properties to create an ad



    }
    public class CreateEvent
    {
        [Required(ErrorMessage = "Required an email")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AdTitle { get; set; }
        [Required(ErrorMessage = "Set a price")]
        public string Price { get; set; }
        [Required(ErrorMessage = "Write something..")]
        public string Text { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }

        //Categories
        public string SelectedCategory { get; set; }
        public string SelectedGender { get; set; }
        public string SelectedNumberOfPeople { get; set; }
        public string SelectedCounty { get; set; }
        public string SelectedMunicipality { get; set; }
        public Dictionary<int, string> Category { get; set; }
        public Dictionary<int, string> Genders { get; set; }
        public Dictionary<int, string> County { get; set; }
        public Dictionary<int, string> Municipality { get; set; }


    }
}