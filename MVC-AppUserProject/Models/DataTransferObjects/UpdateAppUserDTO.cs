using MVC_AppUserProject.Models.Entities.Abstract;
using MVC_AppUserProject.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_AppUserProject.Models.DataTransferObjects
{
    public class UpdateAppUserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "must to type into Firstname")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "must to type into Lastname")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        public string LastName { get; set; }

        public int UserRoleId { get; set; }
        public List<UserRole> UserRole { get; set; }

    } 
}