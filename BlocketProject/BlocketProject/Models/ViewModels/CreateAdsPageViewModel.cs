using BlocketProject.Models.Pages;
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

        public string Heading { get; set; }
        public string NameLabel { get; set; }
        public string EmailLabel { get; set; }
        public string Phonelabel { get; set; }
        public string CategoryLabel { get; set; }
        public string DescriptionLabel { get; set; }
        public string PriceLabel { get; set; }
        public string UploadImageLabel { get; set; }
        public string ButtonLabel { get; set; }
        public string TitleLabel { get; set; }
        public string ErrorMessage { get; set; }

        // properties to create an ad
        public HttpPostedFileBase File { get; set; }
        [Required(ErrorMessage = "Required an email")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AdTitle { get; set; }
        [Required(ErrorMessage = "Set a price")]
        public string Price { get; set; }
        [Required(ErrorMessage = "Write something..")]
        public string Text { get; set; }
       

        //Categories
        public string SelectedCategory { get; set; }
        public Dictionary<int, string> Category { get; set; }

        public CreateAdsPageViewModel(CreateAdPage currentPage)
        {

            this.Heading = currentPage.Heading;
            this.NameLabel = currentPage.Namelabel;
            this.EmailLabel = currentPage.EmailLabel;
            this.Phonelabel = currentPage.PhoneLabel;
            this.CategoryLabel = currentPage.CategoryLabel;
            this.DescriptionLabel = currentPage.AdDescriptionLabel;
            this.PriceLabel = currentPage.PriceLabel;
            this.UploadImageLabel = currentPage.UploadImageLabel;
            this.ButtonLabel = currentPage.ButtonLabel;
            this.TitleLabel = currentPage.TitleLabel;

        }
    }
}