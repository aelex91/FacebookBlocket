using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.DbClasses
{
    [Table("Municipality")]
    public class DbMunicipality
    {
        [Key, Column("Id")]
        public int Id { get; set; }
        public string MunicipalityName { get; set; }
        public int CountyId { get; set; }

    }
}