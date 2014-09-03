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
            // hämta listnamnen 
            var model = new CreateAdsPageViewModel(currentPage);
            //    model.SelectedCategory = ConnectionHelper.GetCategories();


            model.Category = ConnectionHelper.GetCategories();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateAd(CreateAdPage currentPage, HttpPostedFileBase file, string email, string phone, string Adtitle, string price, string text, string Category)
        {
            var model = new CreateAdsPageViewModel(currentPage)
            {

                File = file,
                Email = email,
                Phone = phone,
                AdTitle = Adtitle,
                Price = price,
                Text = text,

            };
            if (ModelState.IsValid)
            {
                var userEmail = User.Identity.Name;
                if (ConnectionHelper.CheckNumberOfAds(userEmail) > 5)
                {

                    return View("Index", model);
                }
                var datetime = DateTime.Now.ToShortDateString();


                if (file == null)
                {
                    return null;
                }
                if (file.ContentLength > 0)
                {
                    FileUpload(file);
                }
                var priceAsInt = Convert.ToInt32(price);
                var phoneAsInt = Convert.ToInt32(phone);
                var categoryAsInt = Convert.ToInt32(Category);
                ConnectionHelper.SaveAdInformationToDb(email, phoneAsInt, categoryAsInt, 1, "/images/" + file.FileName, Adtitle, datetime, ConnectionHelper.GetUserIdByEmail(User.Identity.Name), priceAsInt);
                ConnectionHelper.SaveNumberOfAdsToUser(email);
                //ladda in värderna vi får från vyn in till en användares databas.
                //skicka tillbaka personen till en tack sida?
            }
            return View("Index", model);
        }
        public ActionResult FileUpload(HttpPostedFileBase file)
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
            return RedirectToAction("Index");
        }
    }
}