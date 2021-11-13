using MVC_AppUserProject.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MVC_AppUserProject.Models.EntityTypeConfiguration.Abstract
{
    public abstract class BaseEntityTypeConfiguration<T>:EntityTypeConfiguration<T>  where T:BaseEntity
    {
        public BaseEntityTypeConfiguration()
        {
            HasKey(x=>x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CreateDate).HasColumnName("CreateDate").HasColumnType("datetime2").IsRequired();
            Property(x => x.UpdateDate).HasColumnName("UpdateDate").HasColumnType("datetime2").IsOptional();
            Property(x => x.DeleteDate).HasColumnName("DeleteDate").HasColumnType("datetime2").IsOptional();
            Property(x => x.status).HasColumnName("Status").IsRequired();
        }
    }
}