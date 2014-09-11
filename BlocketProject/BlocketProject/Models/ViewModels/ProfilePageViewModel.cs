﻿using BlocketProject.Models.DbClasses;
using BlocketProject.Models.Pages;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class ProfilePageViewModel
    {
        public ProfilePageViewModel(ProfilePage currentPage)
        {
            Heading = currentPage.Heading;

        }
        public string Heading { get; set; }
        public FacebookUserModel Fbuser { get; set; }
        public List<UserAdsModel> ListUserAds { get; set; }
        public List<FacebookFriend> friendsList { get; set; }

        public class FacebookUserModel
        {
            public int? UserId { get; set; }
            public string FacebookId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Location { get; set; }
            public string ImageUrl { get; set; }
            public int? NumberOfEvents { get; set; }
        }


        public class UserAdsModel
        {
            public int UserId { get; set; }
            public int EventId { get; set; }
            public string Title { get; set; }
            public int Price { get; set; }
            public string EventDescription { get; set; }
            public string ImageUrl { get; set; }
            public DateTime PublishDate { get; set; }
            public DateTime ExpirationDate { get; set; }
            public int CategoryId { get; set; }
        }

    }
}