using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RSS2MVC.Models
{
    public class UserInfoContext : DbContext
    {
        public UserInfoContext() : base("DBConn") { }
        public DbSet<UserInfoModel> UserInfoModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserInfoModel>().ToTable("UserInfo");
        }
    }
}
