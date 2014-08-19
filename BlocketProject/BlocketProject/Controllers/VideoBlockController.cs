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
    public class VideoBlockController : BlockController<VideoBlock>
    {
        public override ActionResult Index(VideoBlock currentBlock)
        {
            return PartialView(currentBlock);
        }


    }
}
