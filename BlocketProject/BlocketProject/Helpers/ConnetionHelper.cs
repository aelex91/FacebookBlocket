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
                              UserId = p.UserId,
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
        public static string GetUserName(int? id)
        {
            var result = (from r in db.DbUserInformation
                          join a in db.DbUserAds on r.UserId equals a.UserId
                          where a.UserId == id
                          select r.FirstName).FirstOrDefault();

            return result;
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