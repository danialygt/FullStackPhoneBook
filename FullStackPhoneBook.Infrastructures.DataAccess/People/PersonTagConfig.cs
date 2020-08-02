using FullStackPhoneBook.Domain.Core.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullStackPhoneBook.Infrastructures.DataAccess.People
{
    internal class PersonTagConfig : IEntityTypeConfiguration<PersonTag>
    {
        public void Configure(EntityTypeBuilder<PersonTag> builder)
        {
            builder.Property(c => c.PersonId).IsRequired();
            builder.Property(c => c.TagId).IsRequired();


        }
    }
}
