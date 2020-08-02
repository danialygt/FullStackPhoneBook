using FullStackPhoneBook.Core.Contracts.Phones;
using FullStackPhoneBook.Domain.Core.Phones;
using FullStackPhoneBook.Infrastructures.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullStackPhoneBook.Infrastructures.DataAccess.Phones
{
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(PhoneBookContext dbContext) : base(dbContext)
        {
        }
    }
}
