using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RSS2MVC.Models
{
    public class RSSUrlContext : DbContext
    {
        public RSSUrlContext() : base("DBConn") { }
        public DbSet<RSSUrlModel> RSSUrlModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RSSUrlModel>().ToTable("RSSUrls");
        }
    }
}
