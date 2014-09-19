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
using BlocketProject.Helpers;
using BlocketProject.Models.ViewModels;

namespace BlocketProject.Controllers
{
    public class UsersOnlineBlockController : BlockController<UsersOnlineBlock>
    {
        public override ActionResult Index(UsersOnlineBlock currentBlock)
        {
            var model = new UsersOnlineViewModel(currentBlock);
            // hämta alla användare registrerade.
            // hämtade alla användare som är female regade
            // alla male reggade.
            model.RegistredUsers = ConnectionHelper.GetRegisteredUsers();
            model.MaleUsers = ConnectionHelper.MaleRegistered();
            model.FemaleUsers = ConnectionHelper.FemaleRegistered();
            
            return PartialView(model);
        }
    }
}
