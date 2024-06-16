using AutoMapper;
using FDCleanArchitecture.Application.Abstractions;
using FDCleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using FDCleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using FDCleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using FDCleanArchitecture.Application.Services;
using FDCleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDCleanArchitecture.Persistance.Services
{
    public sealed class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(UserManager<AppUser> userManager, IMapper mapper, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginCommandResponse> CreateNewTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            AppUser appUser=await _userManager.FindByIdAsync(request.UserId);
            if (appUser == null) throw new Exception("Kullanıcı bulunamadı");

            if(appUser.RefrechToken != request.RefreshToken)
                throw new Exception("Refresh Token geçerli değil.");

            if(appUser.RefreshTokenExpires <DateTime.Now)
                throw new Exception("Refresh Tokenin süresi dolmuş");

            LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(appUser);
            return response;
        }

        public async Task<LoginCommandResponse> LoginAsync(LoginCommand request,CancellationToken cancellationToken)
        {
            AppUser? appUser = await _userManager.Users.Where(p =>
            p.UserName == request.UserNameOrEmail || p.Email == request.UserNameOrEmail)
                .FirstOrDefaultAsync(cancellationToken);

            if (appUser == null) throw new Exception("Kullanıcı bulunamadı");

            var result= await _userManager.CheckPasswordAsync(appUser, request.Password);
            if(result)
            {
                var response = await _jwtProvider.CreateTokenAsync(appUser);
                return response;
            }
            throw new Exception("Şifreyi yanlış girdiniz");
        }

        public async Task RegisterAsync(RegisterCommand request)
        {
            AppUser appUser=_mapper.Map<AppUser>(request);
            var result = await _userManager.CreateAsync(appUser, request.Password);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
        }
    }
}
