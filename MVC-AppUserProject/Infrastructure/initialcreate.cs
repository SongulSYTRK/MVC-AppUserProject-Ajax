using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace MVC_AppUserProject.Infrastructure
{
    public class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MVCAppUserList",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }
    }
}