using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.DbClasses
{
    [Table("Friends")]
    public class DbFriends
    {
        [Key, Column("UserId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }
        public int FriendId { get; set; }
    }
}