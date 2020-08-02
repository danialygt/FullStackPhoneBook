using FullStackPhoneBook.Core.Contracts.Common;
using FullStackPhoneBook.Domain.Core.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullStackPhoneBook.Core.Contracts.People
{
    public interface IPersonRepository: IBaseRepository<Person>
    {
    }
}
