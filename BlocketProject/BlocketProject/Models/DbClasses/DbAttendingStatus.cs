using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.DbClasses
{
    [Table("AttendingStatus")]
    public class DbAttendingStatus
    {
        
        [Key, Column("StatusId")]
        public int StatusId { get; set; }
        public string StatusName { get; set; }

    }
}