using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Components.DictionaryAdapter;

namespace BlocketProject.Models.ViewModels
{
    public class HomeModel
    {
        public class UserInformation
        {
            public int? UserId { get; set; }
            public DateTime Birthday { get; set; }
            public string FacebookId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Location { get; set; }
            public string ImageUrl { get; set; }
            public string Gender { get; set; }
            public DateTime RegisterDate { get; set; }
        }
    }
}