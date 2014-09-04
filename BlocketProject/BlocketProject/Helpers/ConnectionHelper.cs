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
using System.Web.Mvc;

namespace BlocketProject.Helpers
{

    public static class ConnectionHelper
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

        public static List<AdsPageViewModel.UserAdsModel> GetCurrentUserAds(int? id)
        {


            var query = (from r in db.DbUserInformation
                         join a in db.DbUserAds on r.UserId equals a.UserId
                         where a.UserId == id
                         select new AdsPageViewModel.UserAdsModel
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

        public static void SaveAdInformationToDb(string email, int phone, int catId, int subcatId, string imageUrl, string title, DateTime publishdate, int userId, int price)
        {
            DateTime expirationDate = DateTime.Now.AddDays(14);

            var modelUserAds = new DbUserAds
            {
                Email = email,
                Phone = phone,
                CategoryId = catId,
                SubCategoryId = subcatId,
                ImageUrl = imageUrl,
                Title = title,
                PublishDate = publishdate,
                ExpirationDate = expirationDate,
                UserId = userId,
                Price = price,
            };
            db.DbUserAds.Add(modelUserAds);



        }
        public static void SaveNumberOfAdsToUser(string email)
        {
            var checkNumberofAds = CheckNumberOfAds(email);
            checkNumberofAds = checkNumberofAds + 1;
            var query = (from p in db.DbUserInformation
                         where p.Email == email
                         select p).FirstOrDefault();
            try
            {
                if (checkNumberofAds == null)
                {
                    query.NumberOfAds = 1;
                }
                else
                {
                    query.NumberOfAds = query.NumberOfAds + 1;
                }
                db.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }

        
        }
        public static int? CheckNumberOfAds(string email)
        {

            var query = (from p in db.DbUserInformation
                         where email == p.Email
                         select p.NumberOfAds).FirstOrDefault();

            return query;
        }
        public static Dictionary<int, string> GetCategories()
        {
            var query = (from p in db.DbCategories
                         select p).ToDictionary(t => t.Id, t => t.CategoryName);

            return query;
        }

        public static DbUserAds GetAdById(int id)
        {
            var query = (from p in db.DbUserAds where p.AdId == id select p).FirstOrDefault();

            return query;
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

            if (result != null)
            {
                return result;
            }

            else
            {
                return null;
            }
        }

        public static string GetUserEmailById(string id)
        {
            var result = (from r in db.DbUserInformation
                          where r.FacebookId == id
                          select r.Email).FirstOrDefault();
            return result;
        }
        public static int GetUserIdByEmail(string email)
        {
            var result = (from r in db.DbUserInformation
                          where r.Email == email
                          select r.UserId).FirstOrDefault();
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

        public static DbUserInformation GetUserInformationByEmail(string email)
        {
            var result = (from r in db.DbUserInformation
                          where r.Email == email
                          select r).FirstOrDefault();
            return result;
        }

        public static List<ProfilePageViewModel.UserAdsModel> GetUserAds(int id)
        {


            var query = (from r in db.DbUserInformation
                         join a in db.DbUserAds on r.UserId equals a.UserId
                         where a.UserId == id
                         select new ProfilePageViewModel.UserAdsModel
                         {
                             UserId = a.UserId,
                             AdId = a.AdId,
                             AdDescription = a.AdDescription,
                             ImageUrl = a.ImageUrl,
                             Price = a.Price,
                             PublishDate = a.PublishDate,
                             ExpirationDate = a.ExpirationDate,
                             Title = a.Title,


                         }).ToList();

            return query;
        }

        public static List<DbUserInformation> GetAllUsers()
        {
            var query = (from p in db.DbUserInformation select p).ToList();

            return query;
        }


    }
}