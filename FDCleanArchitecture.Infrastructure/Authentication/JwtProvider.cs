﻿using FDCleanArchitecture.Application.Abstractions;
using FDCleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using FDCleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FDCleanArchitecture.Infrastructure.Authentication
{
    public sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;
        private readonly UserManager<AppUser> _userManager;

        public JwtProvider(IOptions<JwtOptions> jwtOptions, UserManager<AppUser> userManager)
        {
            _jwtOptions = jwtOptions.Value;
            _userManager = userManager;
        }

        public async Task<LoginCommandResponse> CreateTokenAsync(AppUser appUser)
        {
            var claims = new Claim[]
            {
                 new Claim(ClaimTypes.NameIdentifier,appUser.Id),
                 new Claim(ClaimTypes.Email,appUser.Email),
                 new Claim(JwtRegisteredClaimNames.Name, appUser.UserName),
                 new Claim("NameLastName",appUser.NameLastName)
            };

            DateTime expires = DateTime.Now.AddHours(1);
            JwtSecurityToken jwtSecurityToken=new(
                issuer:_jwtOptions.Issuer,
                audience:_jwtOptions.Audience,
                claims:claims,
                notBefore:DateTime.Now,
                expires:expires,
                signingCredentials:new SigningCredentials(new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes
                (_jwtOptions.SecretKey)),SecurityAlgorithms.HmacSha256));

            string token=new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            string refreshToke = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

            appUser.RefrechToken = refreshToke;
            appUser.RefreshTokenExpires= expires.AddMinutes(15);
            await _userManager.UpdateAsync(appUser);

            LoginCommandResponse response = new(
                token,
                refreshToke,
                appUser.RefreshTokenExpires,
                appUser.Id);
            return response;
        }
    }
}