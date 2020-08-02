using System;
using System.Collections.Generic;
using System.Text;
using FullStackPhoneBook.Domain.Core.Tags;


namespace FullStackPhoneBook.Domain.Core.People
{
    public class PersonTag:BaseEntity
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
