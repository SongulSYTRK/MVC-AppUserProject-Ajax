using MVC_AppUserProject.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AppUserProject.Models.Entities.Concrete
{
    public class UserRole:BaseEntity
    {
        public string RoleName { get; set; }
        public decimal Salery { get; set; }
        public string  Description { get; set; }
        public virtual List<AppUser> AppUsers{ get; set; }
}
}