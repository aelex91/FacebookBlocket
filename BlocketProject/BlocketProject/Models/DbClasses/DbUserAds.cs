using BlocketProject.Helpers;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.DbClasses
{
    [Table("UserAds")]
    public class DbUserAds
    {
        [Key, Column("AdId")]
        public int? AdId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdDescription { get; set; }
        public string ImageUrl { get; set; }
        public string PublishDate { get; set; }
        public int? CategoryId { get; set; }
    }
}