using BlocketProject.Models.DbClasses;
using BlocketProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Helpers
{
    public static class UserHelper
    {
        public static ProfilePageViewModel.FacebookUserModel GetUserValues(ProfilePageViewModel.FacebookUserModel model,DbUserInformation user)
        {
            model.Location = user.Location;
            model.FacebookId = user.FacebookId;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.UserId = user.UserId;
            model.Email = user.Email;
            model.ImageUrl = user.ImageUrl;
            model.NumberOfAds = user.NumberOfAds;
            return model;
        }
    }
}