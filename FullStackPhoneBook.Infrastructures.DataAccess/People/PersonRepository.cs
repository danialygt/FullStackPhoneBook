using FullStackPhoneBook.Core.Contracts.People;
using FullStackPhoneBook.Domain.Core.People;
using FullStackPhoneBook.Infrastructures.DataAccess.Common;

namespace FullStackPhoneBook.Infrastructures.DataAccess.People
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(PhoneBookContext dbContext) : base(dbContext)
        {
        }
    }
}
