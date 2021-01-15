using NewspaperMVCProject.EntityLayer.Entities.Concrete;
using NewspaperMVCProject.Map.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperMVCProject.DataAccesLayer.Context
{
     public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"Server=DESKTOP-2A32802\SQLEXPRESS01;Database=NewspaperMVC;Integrated Security=True;";
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new PostMap());
            modelBuilder.Configurations.Add(new CommentMap());
            //modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("datetime2")); oluşturdugumuz datetime tipindekşi veriler datetime2 olarak çevrilecektir

            base.OnModelCreating(modelBuilder);
        }

    }
}
