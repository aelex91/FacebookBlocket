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


namespace BlocketProject.Controllers
{
    public class StartPageController : PageController<StartPage>
    {
        string appId = WebConfigurationManager.AppSettings["FacebookAppID"];
        string appSecret = WebConfigurationManager.AppSettings["FacebookAppSecret"];
        string scope = "user_likes, publish_stream, manage_pages, user_friends, email";
        string redirectUrl = "http://letemsale.com/";

        public ActionResult Index(StartPage currentPage)
        {

            if (Request["code"] != null)
            {
                CheckAuthorization();
            }

            return View(currentPage);
        }

        [HttpPost]
        public ActionResult Authenticate()
        {

            CheckAuthorization();
            return RedirectToAction("Index");
        }

        public void CheckAuthorization()
        {

            if (Request["code"] == null)
            {

                Response.Redirect(string.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}", appId, redirectUrl, scope));

            }

            else
            {

                Dictionary<string, string> tokens = new Dictionary<string, string>();



                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",

                    appId, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), appSecret);



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

                JsonObject user = client.Get("me/") as JsonObject;

                JObject json = JObject.Parse(user.ToString());





            }


        }
    }
}