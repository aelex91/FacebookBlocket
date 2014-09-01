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

namespace BlocketProject.Controllers
{
    public class CreateAdPageController : PageController<CreateAdPage>
    {
        public ActionResult Index(CreateAdPage currentPage)
        {
            //MÅSTE VARA AUTHENTICATED. FÖR ATT SYNAS
            // en användare ska kunna skapa en egen AD.
            // så på profil sida har vi en knapp till adsidan (måste vara authorize för att komma dit)
            // när man kommer till sidan ska man kunna skriva upp information om sin add.
            //skapa upp en knapp, textfält, upload bild, pris, osv
            var model = new CreateAdsPageViewModel(currentPage);

            return View(model);
        }
        [HttpPost]
        public ActionResult CreateAd(CreateAdPage currentPage,HttpPostedFileBase file,string name)
        {
              var model = new CreateAdsPageViewModel(currentPage);
              if (file == null)
              {
                  model.ErrorMessage = "Choose an Image";
                  return View("Index", model.ErrorMessage);
              }
            if (file.ContentLength > 0)
            {
                FileUpload(file);
            }
        
            //ladda in värderna vi får från vyn in till en användares databas.
            //skicka tillbaka personen till en tack sida?
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