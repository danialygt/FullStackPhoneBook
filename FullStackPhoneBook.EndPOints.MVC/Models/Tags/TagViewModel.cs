using FullStackPhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackPhoneBook.EndPoints.MVC.Models.Tags
{
    public class TagViewModel
    {
        public List<Tag> tags { get; set; }
        public TagModel newTag { get; set; }
    }
}
