using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackPhoneBook.EndPoints.MVC.Models.People
{
    public abstract class AddNewPersonViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        public IFormFile Image { get; set; }
        public List<FullStackPhoneBook.Domain.Core.Tags.Tag> TagsForDisplay { get; internal set; }
    }
}
