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
using System.Collections;

namespace BlocketProject.Controllers
{
    public class RegisterBlockController : BlockController<RegisterBlock>
    {
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

        public override ActionResult Index(RegisterBlock currentBlock)
        {

            var model = new RegisterBlockViewModel(currentBlock);
            model.RegisterUser = new Register();
            model.RegisterUser.Gender = ConnectionHelper.GetGenders();
            model.RegisterUser.Municipality = ConnectionHelper.GetMuncipalities();
            model.RegisterUser.County = ConnectionHelper.GetCounties();
            var dayDic = new Dictionary<int, int>();
            var monthDic = new Dictionary<int, string>();
            var yearDic = new Dictionary<int, int>();
            //skapa en loop som fyller en dictionary med värden, id och int siffra.

            string[] record = new string[20];

            var stringList = new string[13] { "Månad", "Januari", "Februari", "Mars", "April", "Maj", "Juni", "Juli", "Augutsti", "September", "Oktober", "November", "December" };
            for (int i = 0; i < stringList.Length; i++)
            {
                record[i] = stringList[i];

            }
            for (int i = 1; i <= 31; i++)
            {
                dayDic.Add(i, i);

            }
            for (int i = 0; i <= 12; i++)
            {

                monthDic.Add(i, record[i]);
            }
            for (int i = 1915; i <= 1996; i++)
            {

                yearDic.Add(i, i);
            }
            ArrayList result = new ArrayList((from p in monthDic
                                              select new
                                              {
                                                  Value = p.Value,
                                                  Key = p.Key
                                              }).ToArray());

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
        [AllowAnonymous]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RegisterUser(RegisterBlockViewModel model)
        {
            var message = string.Empty;
            if (model.RegisterUser.SelectedMonth == "0")
            {
                model.RegisterUser.Gender = ConnectionHelper.GetGenders();
                model.RegisterUser.Municipality = ConnectionHelper.GetMuncipalities();
                model.RegisterUser.County = ConnectionHelper.GetCounties();
                return PartialView("Index", model);
            }

            if (ModelState.IsValid)
            {
                string date = model.RegisterUser.SelectedDay + "/" + model.RegisterUser.SelectedMonth + "/" + model.RegisterUser.SelectedYear;
                DateTime dt = Convert.ToDateTime(date);

                if (model.RegisterUser.SelectedGender == "Female" || model.RegisterUser.SelectedGender == "Male")
                {
                    // check from database if email is registred.

                    // spara in men först kolla om användarens email redan finns. sätt även HasFacebook till false.


                    var CheckIfEmailExists = ConnectionHelper.GetUserInformationByEmail(model.RegisterUser.Email);
                    if (CheckIfEmailExists == null)
                    {
                        //ConnectionHelper.SaveUserToDb(model.RegisterUser);
                        // metod logga in
                        var birthday = model.RegisterUser.SelectedDay;
                        var userModel = new BlocketProject.Models.ViewModels.ProfilePageViewModel.UserInformation
                        {
                            FirstName = model.RegisterUser.FirstName,
                            LastName = model.RegisterUser.LastName,
                            Municipality = model.RegisterUser.SelectedMunicipality,
                            County = model.RegisterUser.SelectedCounty,
                            Gender = model.RegisterUser.SelectedGender,
                            Birthday = dt,
                            RegisterDate = DateTime.Now,
                            HasFacebook = false,
                            
                         
                            //   Birthday = model.RegisterUser.Day + model.RegisterUser.Month + model.RegisterUser.Year,
                        };

                    }
                    else
                    {
                        ModelState.AddModelError(model.RegisterUser.Email, " Finns redan.");
                        return View("Index", "Startpage", model);
                    }

                }
            }
            else
            {
                model.RegisterUser.Gender = ConnectionHelper.GetGenders();
                model.RegisterUser.Municipality = ConnectionHelper.GetMuncipalities();
                model.RegisterUser.County = ConnectionHelper.GetCounties();
                ModelState.AddModelError("CustomError", "Sorrybrotha");
                return View("Index", "StartPage");

            }

            return View("Index", "StartPage", model);
        }

    }
}
