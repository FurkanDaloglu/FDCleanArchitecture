using FDCleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using FDCleanArchitecture.Application.Services;
using MediatR;

namespace FDCleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;

public sealed record CreateNewTokenByRefreshTokenCommand(
    string UserId,
    string RefreshToken) :IRequest<LoginCommandResponse>;


public sealed class CreateNewTokenByRefreshTokenCommandHandler : IRequestHandler<CreateNewTokenByRefreshTokenCommand, LoginCommandResponse>
{
    private readonly IAuthService _authService;

    public CreateNewTokenByRefreshTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginCommandResponse> Handle(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response=await _authService.CreateNewTokenByRefreshTokenAsync(request,cancellationToken);
        return response;
    }
}

