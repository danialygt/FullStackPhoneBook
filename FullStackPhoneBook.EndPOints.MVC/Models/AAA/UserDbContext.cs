using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FullStackPhoneBook.EndPoints.MVC.Models.AAA
{
    public class UserDbContext : IdentityDbContext<AppUser, MyIdentityRole ,int>
    {
        public DbSet<BadPassword> BadPasswords { get; set; }
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }


    }
}
