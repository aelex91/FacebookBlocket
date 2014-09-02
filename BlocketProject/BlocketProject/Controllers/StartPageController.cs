﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using BlocketProject.Models.Pages;
using System.Configuration;
using System.Web.Configuration;
using System.Net;
using System.IO;
using Facebook;
using System.Web;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BlocketProject.Models.DbClasses;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using BlocketProject.Helpers;
using BlocketProject.Models.ViewModels;
using System.Web.Security;


namespace BlocketProject.Controllers
{

    public class StartPageController : PageController<StartPage>
    {
        string appId = WebConfigurationManager.AppSettings["FacebookAppID"];
        string appSecret = WebConfigurationManager.AppSettings["FacebookAppSecret"];
        string scope = WebConfigurationManager.AppSettings["FacebookScope"];
        string redirectUrl = "http://letemsale.com/";

        LetemsaleDbContext db = new LetemsaleDbContext();

        HomeModel.UserInformation model = new HomeModel.UserInformation();

        public ActionResult Index(StartPage currentPage)
        {

            if (Request["code"] != null)
            {
                var info = CheckAuthorization(); // har access att få logga in
                SaveUser(info);
                Login(model);
            }

            return View(currentPage);
        }


        [HttpPost]
        public ActionResult Authenticate()
        {

            CheckAuthorization();
            

            return View("Index");

        }

        public JsonObject CheckAuthorization()
        {


            if (Request["code"] == null)
            {
                Response.Redirect(string.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}", appId, redirectUrl, scope));
            }

            if (Request["code"] != null)
            {

                Dictionary<string, string> tokens = new Dictionary<string, string>();



                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}", appId, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), appSecret);



                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;



                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {

                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    string vals = reader.ReadToEnd();



                    foreach (string token in vals.Split('&'))
                    {
                        tokens.Add(token.Substring(0, token.IndexOf("=")), token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));

                    }

                }

                string access_token = tokens["access_token"];
                var client = new FacebookClient(access_token);

                Session["accessToken"] = client;

                JsonObject user = client.Get("me/") as JsonObject;

                return user;
            }

            return null;


        }

        public HomeModel.UserInformation SaveUser(JsonObject jsonUser)
        {
            JsonUserModel user = new JsonUserModel();
            string jsonString = jsonUser.ToString();

            //StringBuilder sb = new StringBuilder(jsonString);
            //string cleanString = sb
            //    .Replace("å", "a")
            //    .Replace("Å", "A")
            //    .Replace("ä", "a")
            //    .Replace("Ä", "A")
            //    .Replace("ö", "o")
            //    .Replace("Ö", "O").ToString();

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(JsonUserModel));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            user = (JsonUserModel)ser.ReadObject(stream);

            DbUserInformation DbUser = new DbUserInformation();


            

            


            var location = user.location.name;

            DbUser.FacebookId = user.id;
            var UserImageUrl = ConnectionHelper.GetUserImageUrl(DbUser.FacebookId);
            DbUser.FirstName = user.first_name;
            DbUser.LastName = user.last_name;
            DbUser.Email = user.email;
            DbUser.Location = location;
            DbUser.ImageUrl = UserImageUrl;

            model.FacebookId = DbUser.FacebookId;
            model.FirstName = DbUser.FirstName;
            model.LastName = DbUser.LastName;
            model.Email = DbUser.Email;
            model.Location = DbUser.Location;
            model.ImageUrl = DbUser.ImageUrl;
           
            var checkDbId = ConnectionHelper.GetUserFacebookId(DbUser.FacebookId);
            var checkUsers = ConnectionHelper.GetAllUsers();

            if (checkDbId != DbUser.FacebookId)
            {
                db.DbUserInformation.Add(DbUser);
                db.SaveChanges();
            }

            return model;
        }

        public void Login(HomeModel.UserInformation user)
        {
            
            bool isAuthenticated = false;
            var checkUserEmail = ConnectionHelper.GetUserEmailById(user.FacebookId);


            if (checkUserEmail != null)
            {
                isAuthenticated = true;
                
            }
            if(isAuthenticated == true)
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                Response.Redirect(redirectUrl + "profilepage");
               
            }
            else
            {

            }

        }


    }
}