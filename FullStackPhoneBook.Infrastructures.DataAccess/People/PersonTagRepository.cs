using FullStackPhoneBook.Core.Contracts.People;
using FullStackPhoneBook.Domain.Core.People;
using FullStackPhoneBook.Infrastructures.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullStackPhoneBook.Infrastructures.DataAccess.People
{
    public class PersonTagRepository : BaseRepository<PersonTag>, IPersonTagRepository
    {
        public PersonTagRepository(PhoneBookContext dbContext) : base(dbContext)
        {
        }
    }
}
