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

namespace BlocketProject.Controllers
{
    public class InformationBlockController : BlockController<InformationBlock>
    {
        public override ActionResult Index(InformationBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }
}
