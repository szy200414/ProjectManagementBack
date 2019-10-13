using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementBack.WebApi.Models.User
{
    public class CreateUserViewModel
    {
        [Required]
        //[StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        //[StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        //[EmailAddress]
        public string Email { get; set; }
        [Required]
        //[StringLength(6)]
        public string Password { get; set; }
        public string ImagePath { get; set; }
        public string Tel { get; set; }

    }
}