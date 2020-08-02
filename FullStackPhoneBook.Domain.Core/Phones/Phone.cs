using System;
using System.Collections.Generic;
using System.Text;

namespace FullStackPhoneBook.Domain.Core.Phones
{
    public class Phone: BaseEntity
    {
        public string PhoneNumber { get; set; }
        public PhoneType PhoneType { get; set; }
        public int PersonId { get; set; }

    }
}
