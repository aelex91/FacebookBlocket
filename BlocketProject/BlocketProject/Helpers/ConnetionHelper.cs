using BlocketProject.Models.DbClasses;
using BlocketProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BlocketProject.Helpers
{

    public static class ConnetionHelper
    {
        static LetemsaleDbContext db = new LetemsaleDbContext();

        public static List<BlocketProject.Models.ViewModels.AdsPageViewModel.UserAdsModel> GetAllAds()
        {
            var query = (from p in db.DbUserAds

                         select new BlocketProject.Models.ViewModels.AdsPageViewModel.UserAdsModel
                          {
                             AdDescription = p.AdDescription,
                             ImageUrl = p.ImageUrl,
                             Price = p.Price,
                             PublishDate = p.PublishDate,
                             Title = p.Title,
                             

                          }).ToList();

            return query;
        }
        public static string GetAdById(int? id)
        {

            return "";
        }
        public static List<string> GetAdByCategory()
        {

            return new List<string>();
        }
        public static List<string> GetLatestAds(int? count)
        {

            return new List<string>();

        }
    }
}