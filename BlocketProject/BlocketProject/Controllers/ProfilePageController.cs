using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using BlocketProject.Models.Pages;
using BlocketProject.Models.ViewModels;
using BlocketProject.Models.DbClasses;
using System.Web.Security;
using BlocketProject.Helpers;
using Facebook;
using Newtonsoft.Json;
using System;
using System.Web.Configuration;
using System.IO;
using System.Net;
using System.Data.Entity;
using System.Web;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;


namespace BlocketProject.Controllers
{
    public class ProfilePageController : PageController<ProfilePage>
    {
        string appId = WebConfigurationManager.AppSettings["FacebookAppID"];
        string appSecret = WebConfigurationManager.AppSettings["FacebookAppSecret"];
        string scope = WebConfigurationManager.AppSettings["FacebookScope"];
        UrlHelper url = new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);


        [Authorize] // users must be authenticated to view this page
        public ActionResult Index(ProfilePage currentPage, int? UserId)
        {
            var model = new ProfilePageViewModel(currentPage);
            var user = new ProfilePageViewModel.UserInformation();
            if (UserId == null)
            {
                user = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);
                model.CurrentUser = user;
            }

            else
            {
                user = ConnectionHelper.GetUserInformationByEmail(ConnectionHelper.GetUserEmailById(UserId));
                if (user.Email != User.Identity.Name)
                {
                    model.OtherUser = user;
                }
                else
                {
                    model.CurrentUser = user;
                }
            }

            if (user.Location == "")
            {
                return RedirectToAction("EditProfile");
            }

            if (user == null)
            {
                return View(model);
            }

            model.ListUserAds = ConnectionHelper.GetUserAds(user.UserId);

            return View(model);
        }

        public ActionResult EditProfile(ProfilePage currentPage)
        {

            var model = new ProfilePageViewModel(currentPage);
            model.CurrentUser = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);
            if (model.CurrentUser.Location == "")
            {
                return View("EditProfile", model);
            }
            return View("EditProfile", model);
        }
        [HttpPost]
        public ActionResult SaveProfile(ProfilePageViewModel model, ProfilePage currentPage, HttpPostedFileBase file)
        {
            var db = new LetemsaleDbContext();
            if (ModelState.IsValid)
            {
                var oldUser = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);
                var image = "";
                if (file == null)
                {
                    image = oldUser.ImageUrl;
                }
                else
                {
                    if (file.ContentType.Contains("jpg") || file.ContentType.Contains("png") || file.ContentType.Contains("jpeg"))
                    {
                        try
                        {

                            if (!oldUser.ImageUrl.Contains("https"))
                            {
                                var fixedPath = Server.MapPath("~/" + oldUser.ImageUrl);
                                System.IO.File.Delete(fixedPath);
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        // kolla gamla värdet på bilden och overidea.

                        string pic = System.IO.Path.GetFileName(Guid.NewGuid() + file.FileName);
                        string path = System.IO.Path.Combine(
                                               Server.MapPath("/images"), pic);
                        // file is uploaded
                        file.SaveAs(path);

                        // save the image path path to the database or you can send image 
                        // directly to database
                        // in-case if you want to store byte[] ie. for DB
                        //using (MemoryStream ms = new MemoryStream())
                        //{
                        //    file.InputStream.CopyTo(ms);
                        //    byte[] array = ms.GetBuffer();
                        //}
                        image = "/images/" + pic;
                    }
                    else
                    {
                        Response.Write("Image is weird dude..");
                        return null;
                    }

                }

                var dbUser = new DbUserInformation
                {
                    FirstName = model.CurrentUser.FirstName ?? oldUser.FirstName,
                    LastName = model.CurrentUser.LastName ?? oldUser.LastName,
                    Email = oldUser.Email,
                    Phone = model.CurrentUser.Phone ?? oldUser.Phone,
                    ImageUrl = image,
                    ModifiedOn = DateTime.Now,
                    RegisterDate = oldUser.RegisterDate,
                    UserId = oldUser.UserId,
                    FacebookId = oldUser.FacebookId,
                    Gender = oldUser.Gender,
                    NumberOfEvents = oldUser.NumberOfEvents,
                    Location = model.CurrentUser.Location ?? oldUser.Location,
                };

                db.Entry(dbUser).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View("EditProfile", model);
            }

        }
        [Authorize]
        public ActionResult DeleteEvent(int id)
        {

            var userId = ConnectionHelper.GetUserIdByEmail(User.Identity.Name);
            //ta även bort användarens numberofad.
            ConnectionHelper.DeleteUserEvent(id);
            ConnectionHelper.RemoveUserNumberOfEvents(userId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EventRedirect(ProfilePageViewModel model, ProfilePage currentPage, int id)
        {
            model = new ProfilePageViewModel(currentPage);
            return RedirectToAction("Index", new { node = model.EventRedirect, EventId = id });
        }

        [HttpPost]
        public ActionResult ProfileRedirect(ProfilePageViewModel model, ProfilePage currentPage, int id)
        {
            model = new ProfilePageViewModel(currentPage);
            return RedirectToAction("Index", new { node = model.ProfileRedirect, UserId = id });
        }

        [HttpPost]
        public ActionResult Inbox()
        {
            var allMessages = ConnectionHelper.GetAllMessages(ConnectionHelper.GetUserByEmail(User.Identity.Name).UserId);
            var model = new ProfilePageViewModel();

            model.UserMessages = allMessages;

            return View("Inbox", model);

        }

        [HttpPost]
        public ActionResult ReadMessage(int messageId)
        {
            var model = ConnectionHelper.GetMessageByMessageId(messageId);
            return PartialView("ReadMessage", model);
        }
    }
}