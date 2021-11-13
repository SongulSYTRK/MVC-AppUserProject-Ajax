using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_AppUserProject.Models.DataTransferObjects
{
    public class UpdateUserRoleDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "must to type into Firstname")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "must to type into Lastname")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        public string Description { get; set; }

        [Required(ErrorMessage = "must to type into Lastname")]
        [DataType(DataType.Currency, ErrorMessage = "must to type curreny")]
        public decimal Salery { get; set; }
        public object UserRole { get; internal set; }
        public object UserRoles { get; internal set; }
    }
}