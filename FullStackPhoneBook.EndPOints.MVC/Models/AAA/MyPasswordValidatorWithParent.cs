using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackPhoneBook.EndPoints.MVC.Models.AAA
{
    public class MyPasswordValidatorWithParent : PasswordValidator<AppUser>
    {
        private readonly UserDbContext userDbContext;

        public MyPasswordValidatorWithParent(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public override Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            var parentResult = base.ValidateAsync(manager, user, password).Result;
            List<IdentityError> errors = new List<IdentityError>();
            if (!parentResult.Succeeded)
            {
                errors = parentResult.Errors.ToList();
            }
            if (user.UserName == password || user.UserName.Contains(password))
            {
                errors.Add(new IdentityError
                {
                    Code = "Password",
                    Description = "Passswordet ba usirete yekiyeyaaa"
                });
            }

            if(userDbContext.BadPasswords.Any(c => c.Password == password))
            {
                errors.Add(new IdentityError
                {
                    Code = "Password",
                    Description = "Passswordet Nmisheeee ba in horofi ke zadi"
                });
            }

            return Task.FromResult(errors.Any() ?
                IdentityResult.Failed(errors.ToArray()) :
                IdentityResult.Success
                );
        }
    }


}
