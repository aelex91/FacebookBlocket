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
        public int UserId { get; set; }
        public string FacebookId { get; set; }
        public DateTime Birthday { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public int? NumberOfEvents { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public int? PhoneValidation { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}