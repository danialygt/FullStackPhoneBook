using FullStackPhoneBook.EndPoints.MVC.Models.People;
using System.Collections.Generic;

namespace FullStackPhoneBook.EndPoints.Models.People
{
    public class AddNewPersonGetViewModel : AddNewPersonViewModel
    {
        public List<int> SelectedTag { get; set; }
    }
}
