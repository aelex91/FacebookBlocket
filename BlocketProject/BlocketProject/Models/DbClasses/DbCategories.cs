using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.DbClasses
{
    [Table("Categories")]
    public class DbCategories
    {
        [Key, Column("Id")]
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}