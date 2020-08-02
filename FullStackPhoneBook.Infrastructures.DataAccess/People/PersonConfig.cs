using FullStackPhoneBook.Domain.Core.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullStackPhoneBook.Infrastructures.DataAccess.People
{
    internal class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.LastName ).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Image    ).IsUnicode(false);
            builder.Property(c => c.Email    ).HasMaxLength(256).IsRequired();
            builder.Property(c => c.Address  ).HasMaxLength(500);
        }
    }
}
