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
    [Table("UserEvents")]
    public class DbUserEvents
    {
        [Key, Column("EventId")]
        public int EventId { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Phone { get; set; }
        public string EventDescription { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int GenderId { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int MunicipalityId { get; set; }
        public int CountyId { get; set; }
        public bool HideImportantInfo { get; set; }
        public int MaxGuests { get; set; }
        public int Zipcode { get; set; }
    }
}