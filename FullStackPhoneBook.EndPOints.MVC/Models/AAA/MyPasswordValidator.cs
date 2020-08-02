using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackPhoneBook.EndPoints.MVC.Models.AAA
{


    // ino estefade nakardim choon validate haye parent ro estefade nmikone

    public class MyPasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();
            if(user.UserName == password || user.UserName.Contains(password))
            {
                errors.Add(new IdentityError
                {
                    Code = "Password",
                    Description = "Passswordet ba usirete yekiyeyaaa"

                });
            }

            return Task.FromResult(errors.Any()?
                IdentityResult.Failed(errors.ToArray()):
                IdentityResult.Success
                );
        }
    }


}
