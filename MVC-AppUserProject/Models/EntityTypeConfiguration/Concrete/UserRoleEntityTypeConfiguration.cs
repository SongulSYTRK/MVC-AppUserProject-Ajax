using MVC_AppUserProject.Models.Entities.Concrete;
using MVC_AppUserProject.Models.EntityTypeConfiguration.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppUserProject.Models.EntityTypeConfiguration.Concrete
{
    public class UserRoleEntityTypeConfiguration:BaseEntityTypeConfiguration<UserRole>
    {
        public UserRoleEntityTypeConfiguration()
        {
            ToTable("dbo.UserRoles");
            Property(x => x.RoleName)
                .HasMaxLength(20)
                .HasColumnName("RoleName")
                .HasColumnType("nvarchar")
                .IsRequired();


            Property(x => x.Salery)
                .HasColumnType("smallint")
                .HasColumnName("Salery")
                .IsRequired();

            Property(x => x.Description)
                .HasMaxLength(200)
                .HasColumnName("Description")
                .HasColumnType("nvarchar")
                .IsRequired();

            HasMany(x => x.AppUsers)
                .WithRequired(x => x.UserRole)
                .HasForeignKey(x => x.UserRoleId)
                .WillCascadeOnDelete(false);
        }
    }
}