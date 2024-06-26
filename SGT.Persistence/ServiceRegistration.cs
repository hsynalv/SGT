﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SGT.Application.Abstraction.Services;
using SGT.Application.Abstraction.Services.Authentication;
using SGT.Domain.Entities.Identity;
using SGT.Persistence.Context;
using SGT.Persistence.CustomValidation;
using SGT.Persistence.Services;

namespace SGT.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddDbContext<SGT_APIDbContext>(options =>
                options.UseSqlServer(Configuration.ConnectionString));


            services.AddIdentity<AppUser, AppRole>(options =>
                {
                    options.Password.RequiredLength = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;

                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters = "abcçdefgðhiýjklmnoöpqrsþtuüvwxyzABCÇDEFGHIÝJKLMNOÖPQRSÞTUÜVWXYZ0123456789-._";

                }).AddUserValidator<CustomUserValidator>()
                .AddPasswordValidator<CustomPasswordValidator>()
                .AddEntityFrameworkStores<SGT_APIDbContext>()
                .AddDefaultTokenProviders();



            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();
        }
    }
}
