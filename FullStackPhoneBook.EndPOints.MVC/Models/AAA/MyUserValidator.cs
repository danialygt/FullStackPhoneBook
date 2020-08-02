using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackPhoneBook.EndPoints.MVC.Models.AAA
{
    public class MyUserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {

            List<IdentityError> errors = new List<IdentityError>();
            if (!user.Email.Contains("danialygt.ir"))
            {
                errors.Add(new IdentityError
                {
                    Code = "Emailemone ",
                    Description = "emailet danialygt bashe"

                });
            }

            return Task.FromResult(errors.Any() ?
                IdentityResult.Failed(errors.ToArray()) :
                IdentityResult.Success
                );
        }
    }


}
