using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RSS2MVC.Models
{
    public class UserChannelContext : DbContext
    {
        public UserChannelContext() : base("DBConn") { }
        public DbSet<UserChannelModel> UserChannelModels { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserChannelModel>().ToTable("UserChannel");
        }
    }
}
