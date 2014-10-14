using BlocketProject.Models.DbClasses;
using BlocketProject.Models.Pages;
using BlocketProject.Models.ViewModels;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using System.Web.Routing;

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
                              EventId = p.EventId,
                              UserId = p.UserId,
                              Email = p.Email,
                              Title = p.Title,
                              Price = p.Price,
                              Phone = p.Phone,
                              MaxGuests = p.MaxGuests,
                              HideImportantInformation = p.HideImportantInfo,
                              EventDescription = p.EventDescription,
                              ImageUrl = p.ImageUrl,
                              CategoryId = p.CategoryId,
                              GenderId = p.GenderId,
                              CountyId = p.CountyId,
                              MunicipalityId = p.MunicipalityId,
                              PublishDate = p.PublishDate,
                              ExpirationDate = p.ExpirationDate

                          }).ToList();
            return query;
        }
        public static int FemaleRegistered()
        {
            string female = "female";
            var query = (from p in db.DbUserInformation
                         where p.Gender == female
                         select p).Count();

            return query;

        }
        public static int MaleRegistered()
        {
            string male = "male";
            var query = (from p in db.DbUserInformation
                         where p.Gender == male
                         select p).Count();

            return query;

        }
        public static int GetRegisteredUsers()
        {

            var query = (from p in db.DbUserInformation
                         select p).Count();
            return query;

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
        //public static void SaveEditCurrentUser(ProfilePageViewModel.UserInformation currentUser)
        //{
        //    db.Entry(currentUser).State = EntityState.Modified;
        //    db.SaveChanges();
        //}
        public static void SaveUserToDb(ProfilePageViewModel.UserInformation registerUser)
        {
            var userModel = new DbUserInformation {
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                Email = registerUser.Email,
                Password = registerUser.Password,
                FacebookId = null,
                Location = null,
                ImageUrl = null,
                NumberOfEvents = 0,
                Gender = registerUser.Gender,
                Phone = null,
                Birthday = registerUser.Birthday,
                ModifiedOn = DateTime.Now,
                RegisterDate = DateTime.Now,
                HasFacebook = false,
                Municipality = registerUser.Municipality,
                County = registerUser.County,
            };


            db.DbUserInformation.Add(userModel);

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
                Zipcode = Convert.ToInt32(model.CreateEvent.ZipCode),


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
            var f = db.DbUserEvents.FirstOrDefault(x => x.UserId == id);

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
            var e = db.DbUserEvents.FirstOrDefault(x => x.UserId == id);
            var f = db.DbUserInformation.FirstOrDefault(x => x.UserId == id);

            if (e != null)
            {
                db.DbUserEvents.Remove(e);
                db.SaveChanges();
            }
            if (f != null)
            {
                db.DbUserInformation.Remove(f);
                db.SaveChanges();
            }

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

        public static DbUserEvents GetAdById(int? id)
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

        public static string GetUserEmailById(int id)
        {
            var result = (from r in db.DbUserInformation
                          where r.UserId == id
                          select r.Email).FirstOrDefault();
            return result;
        }

        public static string GetUserEmailById(int? id)
        {
            var result = (from r in db.DbUserInformation
                          where r.UserId == id
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
            catch (Exception)
            {

            }
            finally
            {
                if (response != null) response.Close();
            }
            return pictureUrl;
        }

        public static ProfilePageViewModel.UserInformation GetUserInformationByEmail(string email)
        {
            var result = (from r in db.DbUserInformation
                          where r.Email == email
                          select new BlocketProject.Models.ViewModels.ProfilePageViewModel.UserInformation
                          {
                              Birthday = r.Birthday,
                              Email = r.Email,
                              FacebookId = r.FacebookId,
                              FirstName = r.FirstName,
                              Gender = r.Gender,
                              ImageUrl = r.ImageUrl,
                              LastName = r.LastName,
                              Location = r.Location,
                              NumberOfEvents = r.NumberOfEvents,
                              RegisterDate = r.RegisterDate,
                              UserId = r.UserId,
                              Phone = r.Phone,
                              ModifiedOn = r.ModifiedOn,

                          }).FirstOrDefault();
            return result;
        }

        public static DbUserInformation GetUserInformationByUserId(int UserId)
        {
            var result = (from r in db.DbUserInformation
                          where r.UserId == UserId
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
                             Email = a.Email,
                             UserId = a.UserId,
                             EventId = a.EventId,
                             EventDescription = a.EventDescription,
                             ImageUrl = a.ImageUrl,
                             Price = a.Price,
                             PublishDate = a.PublishDate,
                             ExpirationDate = a.ExpirationDate,
                             Title = a.Title,
                             CategoryId = a.CategoryId,
                             GenderId = a.GenderId,
                             CountyId = a.CountyId,
                             MunicipalityId = a.MunicipalityId,
                             HideImportantInfo = a.HideImportantInfo,
                             MaxGuests = a.MaxGuests,
                             Zipcode = a.Zipcode,
                             Phone = a.Phone
                         }).ToList();

            return query;
        }

        public static List<DbUserInformation> GetAllUsers()
        {
            var query = (from p in db.DbUserInformation select p).ToList();

            return query;
        }

        public static List<DbUserInformation> GetUsersByEventId(int eventId)
        {
            var query = (from p in db.DbUserInformation
                         join a in db.DbGuestList on p.UserId equals a.UserId
                         where a.EventId == eventId
                         select p).ToList();
            return query;
        }

        public static List<DbUserInformation> GetAttendingUsers(int eventId)
        {
            var query = (from p in db.DbUserInformation
                         join a in db.DbGuestList on p.UserId equals a.UserId
                         join d in db.DbAttendingStatus on a.StatusId equals d.StatusId
                         where a.EventId == eventId && a.StatusId == 1
                         select p).ToList();

            return query;
        }

        public static List<DbUserInformation> GetMaybeAttendingUsers(int eventId)
        {
            var query = (from p in db.DbUserInformation
                         join a in db.DbGuestList on p.UserId equals a.UserId
                         join d in db.DbAttendingStatus on a.StatusId equals d.StatusId
                         where a.EventId == eventId && a.StatusId == 3
                         select p).ToList();

            return query;
        }

        public static List<DbUserInformation> GetPendingUsers(int eventId)
        {
            var query = (from p in db.DbUserInformation
                         join a in db.DbGuestList on p.UserId equals a.UserId
                         join d in db.DbAttendingStatus on a.StatusId equals d.StatusId
                         where a.EventId == eventId && a.StatusId == 5
                         select p).ToList();

            return query;
        }

        public static List<DbUserInformation> GetInvitedUsers(int eventId)
        {
            var query = (from p in db.DbUserInformation
                         join a in db.DbGuestList on p.UserId equals a.UserId
                         join d in db.DbAttendingStatus on a.StatusId equals d.StatusId
                         where a.EventId == eventId && a.StatusId == 4
                         select p).ToList();

            return query;
        }

        public static List<DbUserInformation> GetNotAttendingUsers(int eventId)
        {
            var query = (from p in db.DbUserInformation
                         join a in db.DbGuestList on p.UserId equals a.UserId
                         join d in db.DbAttendingStatus on a.StatusId equals d.StatusId
                         where a.EventId == eventId && a.StatusId == 2
                         select p).ToList();

            return query;
        }

        public static DbUserInformation GetInvitee(int id)
        {
            var query = (from p in db.DbUserInformation
                         join a in db.DbGuestList on p.UserId equals a.InvitedByUserId
                         join d in db.DbAttendingStatus on a.StatusId equals d.StatusId
                         where a.UserId == id && a.StatusId == 4
                         select p).FirstOrDefault();

            return query;
        }

        public static string GetCountyNameById(int id)
        {
            var query = (from p in db.DbCounty
                         where p.Id == id
                         select p.CountyName).FirstOrDefault();

            return query;
        }

        public static string GetMunicipalityNameById(int id)
        {
            var query = (from p in db.DbMunicipality where p.Id == id select p.MunicipalityName).FirstOrDefault();

            return query;
        }



        public static DbUserInformation GetUserByFacebookId(string FacebookId)
        {
            var query = (from p in db.DbUserInformation
                         where p.FacebookId == FacebookId
                         select p).FirstOrDefault();

            return query;
        }

        public static List<DbUserInformation> GetFriendsByUserId(int UserId)
        {
            var query = (from p in db.DbUserInformation
                         join a in db.DbFriends on p.UserId equals a.FriendId
                         where a.UserId == UserId
                         select p).ToList();

            return query;
        }

        public static void SetAttendingStatus(int UserId, int EventId)
        {
            var query = (from p in db.DbGuestList
                         join a in db.DbUserInformation on p.UserId equals a.UserId
                         where a.UserId == UserId && p.EventId == EventId
                         select p).FirstOrDefault();

            query.StatusId = 1;
            db.SaveChanges();

        }

        public static void RemoveAttendingStatus(int UserId, int EventId)
        {
            var query = (from p in db.DbGuestList
                         join a in db.DbUserInformation on p.UserId equals a.UserId
                         where a.UserId == UserId && p.EventId == EventId
                         select p).FirstOrDefault();

            query.StatusId = 2;
            db.SaveChanges();

        }

        public static void SetMaybeAttendingStatus(int UserId, int EventId)
        {
            var query = (from p in db.DbGuestList
                         join a in db.DbUserInformation on p.UserId equals a.UserId
                         where a.UserId == UserId && p.EventId == EventId
                         select p).FirstOrDefault();

            query.StatusId = 3;
            db.SaveChanges();

        }

        public static string GetCategoryNameById(int id)
        {
            var query = (from p in db.DbCategories
                         where p.Id == id
                         select p.CategoryName).FirstOrDefault();
            return query;
        }

        public static bool CheckIfFriendExistInDB(int id, int userId)
        {
            var query = (from p in db.DbFriends
                         where p.FriendId == id && p.UserId == userId
                         select p).FirstOrDefault();
            if (query != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckInvitableFriends(int id, int eventId)
        {
            var query = (from p in db.DbGuestList
                         where p.UserId == id && p.EventId == eventId
                         select p).FirstOrDefault();
            if (query != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void InviteFriends(int friendId, int eventId, int userId, string message, string messageTitle)
        {

            DbGuestList newGuest = new DbGuestList();
            DbMessages newMessage = new DbMessages();
            var user = GetUserInformationByUserId(userId);
            var friend = GetUserInformationByUserId(friendId);
            var ad = GetAdById(eventId);

            if (message.Contains("[User]"))
            {
                message = message.Replace("[User]", user.FirstName + " " + user.LastName);
            }
            if (message.Contains("[EventName]"))
            {
                message = message.Replace("[EventName]", ad.Title);
            }

            if (messageTitle.Contains("[User]"))
            {
                messageTitle = messageTitle.Replace("[User]", user.FirstName + " " + user.LastName);
            }
            if (messageTitle.Contains("[EventName]"))
            {
                messageTitle = messageTitle.Replace("[EventName]", ad.Title);
            }
            

            newMessage.EventId = eventId;
            newMessage.UserId = friendId;
            newMessage.SenderUserId = userId;
            newMessage.MessageTitle = messageTitle;
            newMessage.MessageText = message;
            newMessage.Unread = true;
            newMessage.Timestamp = DateTime.Now;

            newGuest.StatusId = 4;
            newGuest.EventId = eventId;
            newGuest.UserId = friendId;
            newGuest.InvitedByUserId = userId;

            if (friend.NumberOfUnreadMessages < 0 || friend.NumberOfUnreadMessages == null)
            {
                friend.NumberOfUnreadMessages = 0;
            }
            friend.NumberOfUnreadMessages += 1;

            db.DbMessages.Add(newMessage);
            db.DbGuestList.Add(newGuest);
            db.SaveChanges();
        }

        public static List<DbUserInformation> CompareFriends(List<DbUserInformation> friends, List<DbUserInformation> hostFriends)
        {
            var commonFriends = new List<DbUserInformation>();

            if (friends.Count() > hostFriends.Count())
            {
                foreach (var friend in friends)
                {
                    foreach (var hostFriend in hostFriends)
                    {
                        if (friend.UserId == hostFriend.UserId)
                        {
                            commonFriends.Add(hostFriend);
                        }
                    }
                }
            }
            else if (hostFriends.Count() > friends.Count())
            {
                foreach (var hostFriend in hostFriends)
                {
                    foreach (var friend in friends)
                    {
                        if (hostFriend.UserId == friend.UserId)
                        {
                            commonFriends.Add(friend);
                        }
                    }
                }
            }

            return commonFriends;
           
          
        }

        public static string GetGenderName(int id)
        {
            var query = (from p in db.DbGenders
                         where p.GenderId == id
                         select p.Gender).FirstOrDefault();

            return query;
        }

        public static DbUserInformation GetUserByEmail(string email)
        {
            var result = (from r in db.DbUserInformation
                          where r.Email == email
                          select r).FirstOrDefault();
            return result;
        }

        public static List<DbMessages> GetUnreadMessages(int userId)
        {
            var query = (from p in db.DbMessages
                             join a in db.DbUserInformation on p.UserId equals a.UserId
                             where a.UserId == userId && a.NumberOfUnreadMessages > 0
                             select p).ToList();

            return query;
        }

        public static List<DbMessages> GetAllMessages(int userId)
        {
            var query = (from p in db.DbMessages
                         join a in db.DbUserInformation on p.UserId equals a.UserId
                         where a.UserId == userId
                         select p).ToList();

            return query;
        }

        public static DbMessages GetMessageByMessageId(int messageId)
        {
            var query = (from p in db.DbMessages
                         where p.MessageId == messageId
                         select p).FirstOrDefault();
            if (query.Unread == true)
            {
                var user = GetUserInformationByUserId(query.UserId);
                query.Unread = false;
                user.NumberOfUnreadMessages -= 1;
                db.SaveChanges();
            }
            return query;
        }

        public static SearchPageViewModel Search(string searchQuery)
        {
            SearchPageViewModel model = new SearchPageViewModel();

            List<DbUserInformation> users = db.DbUserInformation.Where(x => x.FirstName.Contains(searchQuery) || x.LastName.Contains(searchQuery)).ToList();
            List<DbUserEvents> events = db.DbUserEvents.Where(x => x.Title.Contains(searchQuery) || x.EventDescription.Contains(searchQuery)).ToList();

            model.eventResults = events;
            model.userResults = users;

            return model;
        }

        public static List<DbUserEvents> GetAllUserEventsByUserId(int id)
        {
            var query = (from p in db.DbUserEvents
                         join a in db.DbUserInformation on p.UserId equals a.UserId
                         where p.UserId == id
                         select p).ToList();

            return query;
        }

        public static _LayoutModel GetLayoutModel()
        {
            _LayoutModel model = new _LayoutModel();
            StandardPage page = new StandardPage();

            model.LinkList = new Dictionary<string,string>();
            List<PageReference> PageList = new List<PageReference>();

            PageList.Add(page.StartPage.FooterPageReference1);
            PageList.Add(page.StartPage.FooterPageReference2);
            PageList.Add(page.StartPage.FooterPageReference3);
            PageList.Add(page.StartPage.FooterPageReference4);

            foreach (var link in PageList)
            {
                var pageData = DataFactory.Instance.GetPage(link);
                model.LinkList.Add(GetLinkByPageReference(link), pageData.Name);
                
            }

            return model;
        }

        public static string GetLinkByPageReference(PageReference pReference)
        {
            var locate = new ServiceLocationHelper(ServiceLocator.Current);
            var page = locate.ContentRepository().Get<PageData>(pReference);
            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            var pageUrl = urlResolver.GetUrl(page.ContentLink);
            return pageUrl;
        }


    }

}