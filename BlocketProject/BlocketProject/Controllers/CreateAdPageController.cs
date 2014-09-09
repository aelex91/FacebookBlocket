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
using BlocketProject.Models;

namespace BlocketProject.Controllers
{
    public class CreateAdPageController : PageController<CreateAdPage>
    {
        public ActionResult Index(CreateAdPage currentPage)
        {
            var model = new CreateAdsPageViewModel(currentPage);
            model.CurrentUser = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);

            model.CreateEvent = new CreateEvent
            {
                Email = currentPage.EmailLabel,
                Phone = currentPage.PhoneLabel,
                AdTitle = currentPage.TitleLabel,
                Price = currentPage.PriceLabel,
                Text = currentPage.TextLabel,
                ZipCode = currentPage.ZipCodeLabel,
                Adress = currentPage.AdressLabel,
                Category = ConnectionHelper.GetCategories(),
                Genders = ConnectionHelper.GetGenders(),
            };


            return View(model);
        }

        [HttpPost]
        public ActionResult CreateAd(CreateAdsPageViewModel model, CreateAdPage currentPage, HttpPostedFileBase file)
        {
            var user = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);
            model.CurrentUser = user;
            if (model.CurrentUser.NumberOfAds >= currentPage.NumberOfAds)
            {
                model.ErrorMessage = "You can only have " + currentPage.NumberOfAds + " adds.";
                return RedirectToAction("Index", new { node = currentPage.ReferenceToLandingPage, message = model.ErrorMessage });
            }
            else
            {

                if (ModelState.IsValid)
                {
                    var userEmail = User.Identity.Name;

                    var datetime = DateTime.Now;


                    if (file == null)
                    {
                        return null;
                    }
                    if (file.ContentLength > 0)
                    {
                        FileUpload(file, model);
                    }

                    ConnectionHelper.SaveAdInformationToDb(model, file);
                    ConnectionHelper.SaveNumberOfAdsToUser(User.Identity.Name);
                }
            }
            UrlHelper url = new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);
            return Redirect(UrlHelpers.PageLinkUrl(url, PageReference.StartPage).ToHtmlString());
        }
        public ActionResult FileUpload(HttpPostedFileBase file, CreateAdsPageViewModel model)
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
            return RedirectToAction("Index", model);
        }
    }
}