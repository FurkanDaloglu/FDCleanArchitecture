using FDCleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using FDCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDCleanArchitecture.Application.Abstractions
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateTokenAsync(AppUser appUser);
    }
}
