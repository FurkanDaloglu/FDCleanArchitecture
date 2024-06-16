using FDCleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using FDCleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using FDCleanArchitecture.Application.Features.AuthFeatures.Commands.Register;

namespace FDCleanArchitecture.Application.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterCommand request);
        Task<LoginCommandResponse> LoginAsync(LoginCommand request,CancellationToken cancellationToken);
        Task<LoginCommandResponse> CreateNewTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request,CancellationToken cancellationToken);
    }
}
