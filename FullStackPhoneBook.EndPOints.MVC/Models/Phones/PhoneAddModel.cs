using FullStackPhoneBook.Domain.Core.People;
using FullStackPhoneBook.Domain.Core.Phones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackPhoneBook.EndPoints.MVC.Models.Phones
{
    public class PhoneAddModel
    {
        public Person person { get; set; }
        public Phone phone { get; set; }
        public PhoneType phoneTypes { get; set; }
    }
}
