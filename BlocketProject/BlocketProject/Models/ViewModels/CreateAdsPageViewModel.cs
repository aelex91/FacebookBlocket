using BlocketProject.Models.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class CreateAdsPageViewModel
    {

        public string Heading { get; set; }
        [Required(ErrorMessage = "Compiletime error required")]
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