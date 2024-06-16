using FDCleanArchitecture.Domain.Dtos;
using MediatR;

namespace FDCleanArchitecture.Application.Features.AuthFeatures.Commands.Register
{
    public sealed record RegisterCommand(
        string Email,
        string UserName,
        string NameLastName,
        string Password):IRequest<MessageResponse>;
}
