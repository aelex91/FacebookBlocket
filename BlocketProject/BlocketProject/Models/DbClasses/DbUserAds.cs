﻿using BlocketProject.Helpers;
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
        public int AdId { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Phone { get; set; }
        public string AdDescription { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}