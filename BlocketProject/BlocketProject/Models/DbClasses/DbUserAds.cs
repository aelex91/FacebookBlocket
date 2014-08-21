using BlocketProject.Helpers;
using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.DbClasses
{   
    public class DbUserAds
    {
            
            public int? Id { get; set; }
            public string Title { get; set; }
            public int Price { get; set; }
            [Required(ErrorMessage = "")]
            public string AdDescription { get; set; }
            public string ImageUrl { get; set; }
            public DateTime PublishDate { get; set; }
            public int? CategoryId { get; set; }  
    }
}