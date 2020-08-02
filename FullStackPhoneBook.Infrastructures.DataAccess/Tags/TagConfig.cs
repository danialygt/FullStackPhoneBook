using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FullStackPhoneBook.Domain.Core.Tags;

namespace FullStackPhoneBook.Infrastructures.DataAccess.Tags
{
    internal class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(50).IsRequired();
        }
    }
}
