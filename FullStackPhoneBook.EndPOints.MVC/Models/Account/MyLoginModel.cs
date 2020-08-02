using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackPhoneBook.EndPoints.MVC.Models.Account
{
    public class MyLoginModel
    {

        [Required]
        [Display(Name = "User Name / Email")]
        public string Name { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }




        public string ReturnUrl { get; set; } = "/";
    }
}