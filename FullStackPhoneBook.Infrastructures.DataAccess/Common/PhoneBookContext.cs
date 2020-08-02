using FullStackPhoneBook.Domain.Core.People;
using FullStackPhoneBook.Domain.Core.Phones;
using FullStackPhoneBook.Domain.Core.Tags;
using FullStackPhoneBook.Infrastructures.DataAccess.People;
using FullStackPhoneBook.Infrastructures.DataAccess.Phones;
using FullStackPhoneBook.Infrastructures.DataAccess.Tags;
using Microsoft.EntityFrameworkCore;

namespace FullStackPhoneBook.Infrastructures.DataAccess.Common
{
    public class PhoneBookContext : DbContext
    {
        
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonTag> PersonTags { get; set; }
        public DbSet<Phone> Phones { get; set; }


        public PhoneBookContext(DbContextOptions<PhoneBookContext> option) : base(option)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new PersonTagConfig());
            modelBuilder.ApplyConfiguration(new PhoneConfig());
            modelBuilder.ApplyConfiguration(new TagConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
