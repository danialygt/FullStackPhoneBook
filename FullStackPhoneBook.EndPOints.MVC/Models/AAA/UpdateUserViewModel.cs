using System.ComponentModel.DataAnnotations;

namespace FullStackPhoneBook.EndPoints.MVC.Models.AAA
{
    public class UpdateUserViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        public string FullName { get; set; }
    }

}
