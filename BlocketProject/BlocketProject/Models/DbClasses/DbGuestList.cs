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
        [Key, Column("Id")]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int StatusId { get; set; }
        public int? InvitedByUserId { get; set; }
    }
}