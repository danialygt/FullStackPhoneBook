using FullStackPhoneBook.Domain.Core.Tags;
using FullStackPhoneBook.EndPoints.MVC.Models.People;
using System.Collections.Generic;

namespace FullStackPhoneBook.EndPoints.Models.People
{
    public class AddNewPersonDisplayViewModel : AddNewPersonViewModel
    {

        public List<Tag> TagsForDisplay { get; set; }
    }
}
