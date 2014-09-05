using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using BlocketProject.Models.Pages;
using BlocketProject.Models.ViewModels;
using System.Web;
using System.IO;
using BlocketProject.Helpers;
using System;

namespace BlocketProject.Controllers
{
    public class CreateAdPageController : PageController<CreateAdPage>
    {
        public ActionResult Index(CreateAdPage currentPage)
        {
            var model = new CreateAdsPageViewModel(currentPage);
            var user = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);
         
            model.Category = ConnectionHelper.GetCategories();
            model.Genders = ConnectionHelper.GetGenders();
            
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateAd(CreateAdPage currentPage, HttpPostedFileBase file, string email, string phone, string title, string price, string text, string category,string gender)
        {
            var user = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);
            var model = new CreateAdsPageViewModel(currentPage);
            if (user.NumberOfAds >= currentPage.NumberOfAds)
            {
                model.ErrorMessage = "You can only have "+ currentPage.NumberOfAds + " adds.";
                return RedirectToAction("Index", new { node = currentPage.ReferenceToLandingPage, message = model.ErrorMessage });
            }
            else
            {
          
          
          
            if (ModelState.IsValid)
            {
                var userEmail = User.Identity.Name;
                if (ConnectionHelper.CheckNumberOfAds(userEmail) > currentPage.NumberOfAds)
                {
                    return RedirectToAction("Index", model);
                }
                var datetime = DateTime.Now;


                if (file == null)
                {
                    return null;
                }
                if (file.ContentLength > 0)
                {
                    FileUpload(file,model);
                }
                var priceAsInt = Convert.ToInt32(price);
                var phoneAsInt = Convert.ToInt32(phone);
                var categoryAsInt = Convert.ToInt32(category);
                ConnectionHelper.SaveAdInformationToDb(email, phoneAsInt, categoryAsInt, 1, "/images/" + file.FileName, title, datetime, ConnectionHelper.GetUserIdByEmail(User.Identity.Name), priceAsInt,text);
                ConnectionHelper.SaveNumberOfAdsToUser(User.Identity.Name);
                //ladda in värderna vi får från vyn in till en användares databas.
                //skicka tillbaka personen till en tack sida?
            }
            }
            UrlHelper url = new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);
            return Redirect(UrlHelpers.PageLinkUrl(url, currentPage.ReferenceToLandingPage ?? PageReference.StartPage).ToHtmlString());
        }
        public ActionResult FileUpload(HttpPostedFileBase file,CreateAdsPageViewModel model)
        {
            if (file != null)
            {
                if (file.ContentType.Contains("jpg") || file.ContentType.Contains("png") || file.ContentType.Contains("jpeg"))
                {


                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(
                                           Server.MapPath("~/images"), pic);
                    // file is uploaded
                    file.SaveAs(path);

                    // save the image path path to the database or you can send image 
                    // directly to database
                    // in-case if you want to store byte[] ie. for DB
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }
                }
                else
                {
                    Response.Write("Image is weird dude..");
                    return null;
                }

            }


            // after successfully uploading redirect the user
            return RedirectToAction("Index",model);
        }
    }
}