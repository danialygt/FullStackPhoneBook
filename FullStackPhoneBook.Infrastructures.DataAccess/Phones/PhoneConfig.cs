using FullStackPhoneBook.Domain.Core.Phones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullStackPhoneBook.Infrastructures.DataAccess.Phones
{
    class PhoneConfig : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.Property(c => c.PersonId).IsRequired();
            builder.Property(c => c.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(c => c.PhoneType).IsRequired();
        }
    }



}
