using MVC_AppUserProject.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppUserProject.Models.Entities.Concrete
{
    public class AppUser:BaseEntity
    {
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        
        public int UserRoleId { get; set; }
        public virtual UserRole UserRole { get; set; }

       
    }


}