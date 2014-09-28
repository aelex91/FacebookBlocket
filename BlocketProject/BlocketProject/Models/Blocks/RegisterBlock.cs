using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace BlocketProject.Models.Blocks
{
    [ContentType(DisplayName = "RegisterBlock", GUID = "4b8d5626-df0e-4ee7-90ff-742735da4030", Description = "")]
    public class RegisterBlock : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Text Label",
            Description = "Text över inloggingen, t.ex: 'Joina hemsidanamn och hitta ditt event ikväll'!",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Text { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Name Label",
            GroupName = SystemTabNames.Content,
            Order = 200)]
        public virtual string FirstNameLabel { get; set; }

        [CultureSpecific]
        [Display(
            Name = "LastName Label",
            GroupName = SystemTabNames.Content,
            Order = 250)]
        public virtual string LastNameLabel { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Password Label",
            GroupName = SystemTabNames.Content,
            Order = 270)]
        public virtual string PasswordLabel { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Birth Label",
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual string BirthLabel { get; set; }

        [CultureSpecific]
        [Display(
            Name = "City Label",
            GroupName = SystemTabNames.Content,
            Order = 400)]
        public virtual string CityLabel { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Gender Label",
            GroupName = SystemTabNames.Content,
            Order = 500)]
        public virtual string GenderLabel { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Email Label",
            GroupName = SystemTabNames.Content,
            Order = 500)]
        public virtual string EmailLabel { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Register Label Sign Up",
            GroupName = SystemTabNames.Content,
            Order = 600)]
        public virtual string RegisterLabel { get; set; }


    }
}