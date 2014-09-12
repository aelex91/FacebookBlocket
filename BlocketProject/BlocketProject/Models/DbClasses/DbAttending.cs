using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.DbClasses
{
    [Table("Attending")]
    public class DbAttending
    {
        [Key, Column("IsAttending")]
        public bool IsAttending { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
    }

}