using FullStackPhoneBook.Core.Contracts.Common;
using FullStackPhoneBook.Core.Contracts.Tags;
using FullStackPhoneBook.Domain.Core.People;
using FullStackPhoneBook.Domain.Core.Tags;
using FullStackPhoneBook.Infrastructures.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullStackPhoneBook.Infrastructures.DataAccess.Tags
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(PhoneBookContext dbContext) : base(dbContext)
        {
        }
    }
}
