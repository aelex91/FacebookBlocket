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
using System.Web.Security;

namespace BlocketProject.Controllers
{
    public class LogoutBlockController : BlockController<LogoutBlock>
    {
        public override ActionResult Index(LogoutBlock currentBlock)
        {
            return PartialView(currentBlock);
        }

        [HttpPost]
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return PartialView("Index");

        }
    }
}
