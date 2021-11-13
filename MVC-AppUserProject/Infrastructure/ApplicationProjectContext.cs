using MVC_AppUserProject.Models.Entities.Concrete;
using MVC_AppUserProject.Models.EntityTypeConfiguration.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_AppUserProject.Infrastructure
{
    public class ApplicationProjectContext:DbContext
    {
        public ApplicationProjectContext()
        {
            Database.Connection.ConnectionString = @"Server=DESKTOP-Q9BCSBK;Database=MVCAppUserList;Integrated Security=True;";
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserEntityTypeConfiiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}