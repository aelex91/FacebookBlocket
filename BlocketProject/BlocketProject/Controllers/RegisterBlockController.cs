using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using BlocketProject.Models.Blocks;
using BlocketProject.Models.ViewModels;
using BlocketProject.Helpers;
using System.Web.UI.WebControls;
using EPiServer.Web.Routing;
using EPiServer.ServiceLocation;

namespace BlocketProject.Controllers
{
    public class RegisterBlockController : BlockController<RegisterBlock>
    {
        public override ActionResult Index(RegisterBlock currentBlock)
        {

            var model = new RegisterBlockViewModel(currentBlock);
            model.RegisterUser = new Register();
            model.RegisterUser.Gender = ConnectionHelper.GetGenders();
            var dayDic = new Dictionary<int, int>();
            var monthDic = new Dictionary<int, int>();
            var yearDic = new Dictionary<int, int>();
            //skapa en loop som fyller en dictionary med värden, id och int siffra.

            for (int i = 1915; i <= 1996; i++)
            {

                yearDic.Add(i, i);
            }
            for (int i = 1; i <= 31; i++)
            {
                dayDic.Add(i, i);
                if (i <= 12)
                {
                    monthDic.Add(i, i);
                }
            }
            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            model.testurl = ContentReference.StartPage;
            var pageUrl = urlResolver.GetUrl(model.testurl);
            model.RegisterUser.Day = dayDic;

            model.RegisterUser.Month = monthDic;
            model.RegisterUser.Year = yearDic;
            model.RegisterUser.Year.OrderBy(x => x.Value);
            //Registrera en användare med en httppost.
            // Hämta värderna från textboxarna använd dig utav modelstate.isvalid.
            // Spara in, Förnamn efternamn // Kolla om en användare med det namnet redan finns,
            // vad man vill egentligen skriva in
            // Födelsedatum, Stad och kön samt email. Skicka personen till profilsidan
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult SaveUser(RegisterBlock currentBlock)
        {

            return View("Index");
        }
    }
}
