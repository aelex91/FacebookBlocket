using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    public class FacebookFriendsModel
    {
        public List<FacebookFriend> friendsList { get; set; }
    }

    public class FacebookFriend
    {
        public string name { get; set; }
        public string id { get; set; }
    }
}