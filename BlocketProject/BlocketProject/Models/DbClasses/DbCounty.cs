using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.DbClasses
{
     [Table("County")]
    public class DbCounty
    {
         [Key, Column("Id")]
        public int Id { get; set; }
        public string CountyName { get; set; }
    }
}