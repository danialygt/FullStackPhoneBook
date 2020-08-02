using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackPhoneBook.EndPoints.MVC.Models.Tags
{
    public class TagModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "نام")]
        public string Title { get; set; }

    }
}
