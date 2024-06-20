using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SGT.Application.Abstraction.Services;
using SGT.Application.DTOs.User;
using SGT.Application.Exceptions;
using SGT.Domain.Entities.Identity;

namespace SGT.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;
        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<CreateUserResponseDto> CreateAsync(CreateUserDto model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Email = model.Email,
                NameSurname = model.NameSurname,
            }, model.Password);

            CreateUserResponseDto response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate,
            int addOnAccessTokenDate)
        {

            user.RefreshToken = refreshToken;
            user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
            IdentityResult result = await _userManager.UpdateAsync(user);
        }
    }
}
