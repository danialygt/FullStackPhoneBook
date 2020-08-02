using Microsoft.AspNetCore.Identity;
using System;

namespace FullStackPhoneBook.EndPoints.MVC.Models.AAA
{
    public class AppUser : IdentityUser<int>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
    }

}
