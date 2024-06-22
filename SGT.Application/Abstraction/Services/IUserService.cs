﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGT.Application.DTOs.User;
using SGT.Domain.Entities.Identity;

namespace SGT.Application.Abstraction.Services
{
    public interface IUserService
    {
        Task<CreateUserResponseDto> CreateAsync(CreateUserDto model);
        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
        Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
    }
}
