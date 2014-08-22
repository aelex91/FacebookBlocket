using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlocketProject.Models.DbClasses
{
    public class LetemsaleDbContext : DbContext
    {
        public LetemsaleDbContext()
            : base("LetemsaleDB")  // connectionstring name define in your web.config
        {

        }
        public DbSet<DbUserAds> DbUserAds { get; set; }
        public DbSet<DbUserInformation> DbUserInformation { get; set; }
    }
}