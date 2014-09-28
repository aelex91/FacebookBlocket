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
        public bool IsMaybeAttending { get; set; }
        public bool IsNotAttending { get; set; }
        public bool IsPending { get; set; }
        public bool IsInvited { get; set; }
        public int InvitedByUserId { get; set; }
    }

}