using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlocketProject.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /SearchControllert/

        public ActionResult Index(string q)
        {
            //           var client = EPiServer.Find.Client.CreateFromConfig();

            return View();
        }

    }
}
