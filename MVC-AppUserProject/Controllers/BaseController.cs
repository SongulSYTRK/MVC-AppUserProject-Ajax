using MVC_AppUserProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_AppUserProject.Controllers
{
    public class BaseController:Controller
    {
        public ApplicationProjectContext db;
        public BaseController()
        {
            db = new ApplicationProjectContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}