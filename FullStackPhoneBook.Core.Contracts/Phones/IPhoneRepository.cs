using FullStackPhoneBook.Core.Contracts.Common;
using FullStackPhoneBook.Domain.Core.Phones;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullStackPhoneBook.Core.Contracts.Phones
{
    public interface IPhoneRepository: IBaseRepository<Phone>
    {
    }
}
