using MediatR;

namespace FDCleanArchitecture.Application.Features.AuthFeatures.Commands.Login;

public sealed record LoginCommand(
    string UserNameOrEmail,
    string Password):IRequest<LoginCommandResponse>;
