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
            var query = (from p in db.DbUserEvents
                         select new AdsPageViewModel.UserAdsModel
                          {
                              UserId = p.UserId,
                              EventDescription = p.EventDescription,
                              ImageUrl = p.ImageUrl,
                              Price = p.Price,
                              PublishDate = p.PublishDate,
                              Title = p.Title,

                          }).ToList();
            return query;
        }

        public static void FillDropDownLists()
        { 
        // hämta alla drop down lists.
        
        }

        public static List<AdsPageViewModel.UserAdsModel> GetCurrentUserAds(int? id)
        {
            var query = (from r in db.DbUserInformation
                         join a in db.DbUserEvents on r.UserId equals a.UserId
                         where a.UserId == id
                         select new AdsPageViewModel.UserAdsModel
                         {
                             UserId = a.UserId,
                             EventDescription = a.EventDescription,
                             ImageUrl = a.ImageUrl,
                             Price = a.Price,
                             PublishDate = a.PublishDate,
                             Title = a.Title,


                         }).ToList();
            return query;
        }

        public static void SaveAdInformationToDb(CreateAdsPageViewModel model, HttpPostedFileBase file)
        {
            DateTime expirationDate = Convert.ToDateTime(model.CreateEvent.Date);
            expirationDate.AddDays(1);
            var selectedGender = Convert.ToInt32(model.CreateEvent.SelectedGender);
            var priceAsInt = Convert.ToInt32(model.CreateEvent.Price);
            var phoneAsInt = Convert.ToInt32(model.CreateEvent.Phone);
            var selectedcategoryAsInt = Convert.ToInt32(model.CreateEvent.SelectedCategory);
            var selectedGenderAsInt = Convert.ToInt32(model.CreateEvent.SelectedGender);
            var selectedCountyAsInt = Convert.ToInt32(model.CreateEvent.SelectedCounty);
            var selectedMunicipalityAsInt = Convert.ToInt32(model.CreateEvent.SelectedCounty);
            var modelUserAds = new DbUserEvents
            {
                Email = model.CreateEvent.Email,
                Phone = phoneAsInt,
                CategoryId = selectedcategoryAsInt,
                ImageUrl = "/images/" + file.FileName,
                Title = model.CreateEvent.EventTitle,
                PublishDate = DateTime.Now,
                ExpirationDate = expirationDate,
                UserId = model.CurrentUser.UserId,
                Price = priceAsInt,
                GenderId = selectedGender,
                HideImportantInfo = model.CreateEvent.HideInformation,
                CountyId = selectedCountyAsInt,
                MunicipalityId = selectedMunicipalityAsInt,
                MaxGuests = Convert.ToInt32(model.CreateEvent.MaxGuests),
                EventDescription = model.CreateEvent.Text,

            };
            db.DbUserEvents.Add(modelUserAds);
        }
        public static void SaveNumberOfEventsToUser(string email)
        {
            var checkNumberOfEvents = CheckNumberOfEvents(email);
            var query = (from p in db.DbUserInformation
                         where p.Email == email
                         select p).FirstOrDefault();
            try
            {
                if (checkNumberOfEvents == null)
                {
                    query.NumberOfEvents = 1;
                }
                else
                {
                    query.NumberOfEvents = query.NumberOfEvents + 1;
                }
                db.DbUserInformation.Attach(query);
                var entry = db.Entry(query);
                entry.Property(p => p.NumberOfEvents).IsModified = true;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }


        }
        public static void DeleteUserEvent(int id)
        {
            var f = db.DbUserEvents.FirstOrDefault(x => x.EventId == id);

            db.DbUserEvents.Remove(f);
            db.SaveChanges();

        }
        public static void RemoveUserNumberOfEvents(int id)
        {
            //plocka bort numberofads sätt till 0
            var change = db.DbUserInformation.FirstOrDefault(x => x.UserId == id);
            change.NumberOfEvents = 0;
            db.SaveChanges();

        }
        public static void DeleteUser(int id)
        {
            var f = db.DbUserInformation.FirstOrDefault(x => x.UserId == id);
            db.DbUserInformation.Remove(f);
            db.SaveChanges();

        }
        public static int? CheckNumberOfEvents(string email)
        {

            var query = (from p in db.DbUserInformation
                         where email == p.Email
                         select p.NumberOfEvents).FirstOrDefault();

            return query;
        }
        public static Dictionary<int, string> GetCategories()
        {
            var query = (from p in db.DbCategories
                         select p).ToDictionary(t => t.Id, t => t.CategoryName);

            return query;
        }

        public static Dictionary<int, string> GetGenders()
        {
            var query = (from p in db.DbGenders
                         select p).ToDictionary(t => t.GenderId, t => t.Gender);

            return query;
        }
        public static Dictionary<int, string> GetCounties()
        {

            var query = (from p in db.DbCounty
                         select p).ToDictionary(x => x.Id, x => x.CountyName);
            return query;
        }
        public static Dictionary<int, string> GetCountiesById(int id)
        {
            // skapa så att d
            var query = (from p in db.DbCounty
                         select p).ToDictionary(x => x.Id, x => x.CountyName);
            return query;
        }
        public static Dictionary<int, string> GetMuncipalitiesFromId(int id)
        {
            // Hämta municipalities beroende på id för county.
            var query = (from p in db.DbMunicipality
                         where p.CountyId == id
                         join ut in db.DbCounty on p.CountyId equals ut.Id
                         select p).ToDictionary(t => t.Id, t => t.MunicipalityName);

            return query.ToDictionary(x => x.Key, x => x.Value);
        }
        public static Dictionary<int, string> GetMuncipalities()
        {
            // Hämta municipalities beroende på id för county.
            var query = (from p in db.DbMunicipality
                         join ut in db.DbCounty on p.CountyId equals ut.Id
                         select p).ToDictionary(t => t.Id, t => t.MunicipalityName);

            return query;
        }

        public static DbUserEvents GetAdById(int id)
        {
            var query = (from p in db.DbUserEvents where p.EventId == id select p).FirstOrDefault();

            return query;
        }
        public static string GetUserName(int? id)
        {
            var result = (from r in db.DbUserInformation
                          join a in db.DbUserEvents on r.UserId equals a.UserId
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

        public static int GetUserAdId(int UserId)
        {
            var query = (from p in db.DbUserEvents
                         where p.UserId == UserId
                         select p.EventId).FirstOrDefault();
            return query;
        }

        public static List<ProfilePageViewModel.UserAdsModel> GetUserAds(int id)
        {


            var query = (from r in db.DbUserInformation
                         join a in db.DbUserEvents on r.UserId equals a.UserId
                         where a.UserId == id
                         select new ProfilePageViewModel.UserAdsModel
                         {
                             UserId = a.UserId,
                             EventId = a.EventId,
                             EventDescription = a.EventDescription,
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