using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EarthWatts.Api.Models
{
    public class RegisterUserView
    {
        [Required(ErrorMessage = "The first name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "The password is required")]
        public string Password { get; set; }
    }
}