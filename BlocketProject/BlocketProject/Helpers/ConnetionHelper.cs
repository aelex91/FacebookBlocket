using BlocketProject.Models.DbClasses;
using BlocketProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace BlocketProject.Helpers
{

    public static class ConnetionHelper
    {
        static LetemsaleDbContext db = new LetemsaleDbContext();

        public static List<AdsPageViewModel.UserAdsModel> GetAllAds()
        {
            var query = (from p in db.DbUserAds
                         select new AdsPageViewModel.UserAdsModel
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

        public static string GetUserFacebookId(string id)
        {
            var result = (from r in db.DbUserInformation
                          where r.FacebookId == id
                          select r.FacebookId).FirstOrDefault();
            return result;
        }

        public static string GetUserEmail(string id)
        {
            var result = (from r in db.DbUserInformation
                          where r.FacebookId == id
                          select r.Email).FirstOrDefault();
            return result;
        }

        public static string GetUserImageUrl(string facebookId)
        {
            WebResponse response = null;
            string pictureUrl = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create(string.Format("https://graph.facebook.com/{0}/picture?type=large", facebookId));
                response = request.GetResponse();
                pictureUrl = response.ResponseUri.ToString();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (response != null) response.Close();
            }
            return pictureUrl;
        }

        public static DbUserInformation GetUserInformation(string email)
        {
            var result = (from r in db.DbUserInformation
                          where r.Email == email
                          select r).FirstOrDefault();
            return result;
        }

        public static List<ProfilePageViewModel.UserAdsModel> GetUserAds(int? id)
        {


            var query = (from r in db.DbUserInformation
                         join a in db.DbUserAds on r.UserId equals a.UserId
                         where a.UserId == id
                         select new ProfilePageViewModel.UserAdsModel
                         {
                             UserId = a.UserId,
                             AdDescription = a.AdDescription,
                             ImageUrl = a.ImageUrl,
                             Price = a.Price,
                             PublishDate = a.PublishDate,
                             Title = a.Title,


                         }).ToList();

            return query;
        }


    }
}