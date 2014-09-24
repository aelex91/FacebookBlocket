﻿using BlocketProject.Models.Blocks;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlocketProject.Models.ViewModels
{
    public class RegisterBlockViewModel
    {
        public RegisterBlockViewModel(RegisterBlock currentBlock)
        {
            this.FirstNameLabel = currentBlock.FirstNameLabel;
            this.LastNameLabel = currentBlock.LastNameLabel;
            this.EmailLabel = currentBlock.EmailLabel;
            this.CityLabel = currentBlock.CityLabel;
            this.GenderLabel = currentBlock.GenderLabel;
            this.Text = currentBlock.Text;
        }
        public string FirstNameLabel { get; set; }
        public string LastNameLabel { get; set; }
        public string BirthLabel { get; set; }
        public string CityLabel { get; set; }
        public string GenderLabel { get; set; }
        public string EmailLabel { get; set; }
        public string Text { get; set; }
        public Register RegisterUser { get; set; }
        public PageReference testurl { get; set; }

    }

    public class Register
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public string SelectedGender { get; set; }
        public string SelectedCity { get; set; }

        public string SelectedDay { get; set; }
        public string SelectedMonth { get; set; }
        public string SelectedYear { get; set; }

        public Dictionary<int, string> City { get; set; }
        public Dictionary<int, string> Gender { get; set; }
        public Dictionary<int, int> Day { get; set; }
        public Dictionary<int, int> Month { get; set; }
        public Dictionary<int, int> Year { get; set; }

    }
}