using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SGT.Domain.Entities.Identity;

namespace SGT.Persistence.CustomValidation
{
    public class CustomPasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
            List<IdentityError> errors = new();
            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsUserName",
                    Description = "Password cannot contain username"
                });
            }

            //if (password.ToLower().Contains("12345"))
            //{
            //    errors.Add(new IdentityError
            //    {
            //        Code = "PasswordContains12345",
            //        Description = "Password cannot contain 12345"
            //    });
            //}

            if (password.ToLower().Contains(user.Email.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsEmail",
                    Description = "Password cannot contain E-mail address"
                });
            }


            if (errors.Count > 0)
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
            else
            {
                return Task.FromResult(IdentityResult.Success);
            }


        }
    }
}
