using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.DbClasses
{
    [Table("UserInformation")]
    public class DbUserInformation
    {
        [Key, Column("UserId")]
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