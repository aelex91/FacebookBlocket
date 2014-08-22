﻿using System;
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
            public string FirstName { get; set; }
            public int LastName { get; set; }
            public string Email { get; set; }
            public string Adress { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}