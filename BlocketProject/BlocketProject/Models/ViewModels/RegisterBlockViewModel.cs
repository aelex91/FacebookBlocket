using BlocketProject.Models.Blocks;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlocketProject.Models.ViewModels
{
    public class RegisterBlockViewModel
    {

        public RegisterBlockViewModel() { }
        public RegisterBlockViewModel(RegisterBlock currentBlock)
        {
            this.FirstNameLabel = currentBlock.FirstNameLabel;
            this.LastNameLabel = currentBlock.LastNameLabel;
            this.EmailLabel = currentBlock.EmailLabel;
            this.CityLabel = currentBlock.CityLabel;
            this.GenderLabel = currentBlock.GenderLabel;
            this.Text = currentBlock.Text;
            this.ButtonLabel = currentBlock.RegisterLabel;
            this.PasswordLabel = currentBlock.PasswordLabel;
        }

        public string FirstNameLabel { get; set; }
        public string LastNameLabel { get; set; }
        public string BirthLabel { get; set; }
        public string CityLabel { get; set; }
        public string GenderLabel { get; set; }
        public string EmailLabel { get; set; }
        public string PasswordLabel { get; set; }
        public string Text { get; set; }
        public string ButtonLabel { get; set; }
        public Register RegisterUser { get; set; }
        public PageReference testurl { get; set; }

    }

    public class Register
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Password { get; set; }
        [Required]
        public string SelectedGender { get; set; }

        public string SelectedCity { get; set; }
        [Required]
        public string SelectedDay { get; set; }
        [Required]
        public string SelectedMonth { get; set; }
        [Required]
        public string SelectedYear { get; set; }
        [Required]
        public string SelectedCounty { get; set; }
        [Required]
        public string SelectedMunicipality { get; set; }

        public Dictionary<int, string> City { get; set; }
        public Dictionary<int, string> Gender { get; set; }
        public Dictionary<int, int> Day { get; set; }
        public Dictionary<int, string> Month { get; set; }
        public Dictionary<int, int> Year { get; set; }

        public Dictionary<int, string> County { get; set; }
        public Dictionary<int, string> Municipality { get; set; }


    }
}