using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.DbClasses
{
    [Table("Genders")]
    public class DbGenders
    {
        [Key, Column("GenderId")]
        public int GenderId { get; set; }
        public string Gender { get; set; }
    }
}