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
    [Authorize]
    public class CreateAdPageController : PageController<CreateAdPage>
    {
        UrlHelper url = new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ChangeIdOnDropDownList(string dropdownId)
        {
            //Get the muncipalities for the current id from drop down county.

            var results = ConnectionHelper.GetMuncipalitiesFromId(Convert.ToInt32(dropdownId));
            var dic = results.Select(m => new SelectListItem()
            {
                Text = m.Value,
                Value = m.Key.ToString(),

            });

            return Json(dic, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(CreateAdPage currentPage)
        {
            var model = new CreateAdsPageViewModel(currentPage);
            model.CurrentUser = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);
            model.CreateEvent = new CreateEvent
            {
                Email = model.EmailLabel,
                Phone = model.Phonelabel,
                EventTitle = model.EventLabel,
                Price = model.PriceLabel,
                Text = currentPage.TextLabel,
                Category = ConnectionHelper.GetCategories(),
                Genders = ConnectionHelper.GetGenders(),
                Municipality = ConnectionHelper.GetMuncipalities(),
                County = ConnectionHelper.GetCounties(),
                HideInformation = false,
                MaxGuests = currentPage.PersonLabel,
                Date = currentPage.DateLabel,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CreateAdsPageViewModel model, CreateAdPage currentPage, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                if (model.CreateEvent.Price == null || model.CreateEvent.Price == string.Empty)
                {
                    model.CreateEvent.Price = "0";
                }
                var user = ConnectionHelper.GetUserInformationByEmail(User.Identity.Name);
                model.CurrentUser = user;
                if (model.CurrentUser.NumberOfEvents >= currentPage.NumberOfEvents)
                {
                    model.ErrorMessage = "You can only have " + currentPage.NumberOfEvents + " adds.";
                    return RedirectToAction("Index", new { node = currentPage.ReferenceToLandingPage, message = model.ErrorMessage });
                }
                model.CurrentUser = user;
                if (file == null)
                {
                    return null;
                }
                if (file.ContentLength > 0)
                {
                    FileUpload(file);
                }

                ConnectionHelper.SaveAdInformationToDb(model, file);
                ConnectionHelper.SaveNumberOfEventsToUser(User.Identity.Name);
                model.ErrorMessage = "Your event has been created.";
                return Redirect(UrlHelpers.PageLinkUrl(url, currentPage.ReferenceToLandingPage).ToHtmlString());
            }
            else
            {
                //skapa metod som fyller alla dropdownlists
                model.CreateEvent.Category = ConnectionHelper.GetCategories();
                model.CreateEvent.Genders = ConnectionHelper.GetGenders();
                model.CreateEvent.Municipality = ConnectionHelper.GetMuncipalities();
                model.CreateEvent.County = ConnectionHelper.GetCounties();
               
                model.DefaultImage = currentPage.DefaultImage;

                return View("Index", model);

            }
        }
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (file.ContentType.Contains("jpg") || file.ContentType.Contains("png") || file.ContentType.Contains("jpeg"))
                {

                    // kolla gamla värdet på bilden och overidea.

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