using BlocketProject.Models.DbClasses;
using Facebook;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Controllers
{
    public class FacebookUserModel
    {
        public JsonObject user { get; set; }
        public List<DbUserInformation> friends { get; set; }
    }
}