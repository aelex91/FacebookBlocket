using System.Collections.Generic;
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

        public ActionResult Index(StartPage currentPage)
        {

            if (Request["code"] != null)
            {
                CheckAuthorization(); // har access att få logga in
               
              
            }

            return View(currentPage);
        }


        [HttpPost]
        public ActionResult Authenticate()
        {


           
            CheckAuthorization();
            var info = CheckAuthorization();
            SaveUser(info);
            var saveuser = SaveUser(info);
           

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

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(JsonUserModel));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            user = (JsonUserModel)ser.ReadObject(stream);

            DbUserInformation DbUser = new DbUserInformation();

            var location = user.hometown.name;
            string[] collection = location.Split(',');
            string city = collection[0];
            string country = collection[1];
            country.TrimStart();



            DbUser.FacebookId = user.id;
            var UserImageUrl = ConnetionHelper.GetUserImageUrl(DbUser.FacebookId);
            DbUser.FirstName = user.first_name;
            DbUser.LastName = user.last_name;
            DbUser.Email = user.email;
            DbUser.City = city;
            DbUser.Country = country;
            DbUser.ImageUrl = UserImageUrl;

            HomeModel.UserInformation model = new HomeModel.UserInformation
            {
            
            
            
            };

            var checkDbId = ConnetionHelper.GetUserFacebookId(DbUser.FacebookId);


            if (checkDbId != DbUser.FacebookId)
            {
                db.DbUserInformation.Add(DbUser);
                db.SaveChanges();
                Membership.CreateUser(DbUser.Email, DbUser.FacebookId);
            }

            return model;
        }
        public ActionResult Login(DbUserInformation user)
        {

            if (Membership.ValidateUser(user.Email, user.FacebookId))
            {
                FormsAuthentication.SetAuthCookie(user.Email, true);
                return RedirectToAction("Index", "ProfilePageController");
            }
            else
            {
                return View("Index");
            }

        }

    }
}