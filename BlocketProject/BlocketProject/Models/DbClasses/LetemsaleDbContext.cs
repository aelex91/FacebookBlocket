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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<LetemsaleDbContext>(null);
            base.OnModelCreating(modelBuilder);
        } // om du har uppdaterat databasen på senaste måste du skriva in detta ^

        public DbSet<DbUserEvents> DbUserEvents { get; set; }
        public DbSet<DbUserInformation> DbUserInformation { get; set; }
        public DbSet<DbCategories> DbCategories { get; set; }
        public DbSet<DbGenders> DbGenders { get; set; }
        public DbSet<DbMunicipality> DbMunicipality { get; set; }
        public DbSet<DbCounty> DbCounty { get; set; }
    }
}