using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace BlocketProject.Models.DbClasses
{
    [Table("GuestList")]
    public class DbGuestList
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        [Key, Column("StatusId")]
        public int StatusId { get; set; }
        public int InvitedByUserId { get; set; }
    }
}