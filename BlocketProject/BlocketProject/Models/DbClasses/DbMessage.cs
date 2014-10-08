using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.DbClasses
{
    [Table("Messages")]
    public class DbMessages
    {
        [Key, Column("MessageId")]
        public int MessageId { get; set; }
        public string MessageTitle { get; set; }
        public string MessageText { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int SenderUserId { get; set; }
        public bool Unread { get; set; }
        public DateTime Timestamp { get; set; }
    }
}