using FullStackPhoneBook.Core.Contracts.Common;
using FullStackPhoneBook.Domain.Core.People;
using FullStackPhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullStackPhoneBook.Core.Contracts.Tags
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
    }
}
