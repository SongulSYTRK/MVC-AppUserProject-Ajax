using MVC_AppUserProject.Models.Entities.Concrete;
using MVC_AppUserProject.Models.EntityTypeConfiguration.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppUserProject.Models.EntityTypeConfiguration.Concrete
{
    public class AppUserEntityTypeConfiiguration:BaseEntityTypeConfiguration<AppUser>
    {
        public AppUserEntityTypeConfiiguration()
        {
            ToTable("dbo.AppUsers");
            Property(x => x.FirstName)
                .HasMaxLength(50)
                .HasColumnName("FirstName")
                .HasColumnType("nvarchar").
                IsRequired();

            Property(x => x.LastName)
                .HasMaxLength(50)
                .HasColumnName("LastName")
                .HasColumnType("nvarchar")
                .IsRequired();
           
        }
    }
}