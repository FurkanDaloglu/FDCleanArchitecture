using FDCleanArchitecture.Application.Services;
using FDCleanArchitecture.Domain.Dtos;
using MediatR;

namespace FDCleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

public sealed record CreateUserRoleCommand(
    string RoleId,
    string AppUserId):IRequest<MessageResponse>;


public sealed class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, MessageResponse>
{
    private readonly IUserRoleService _userRoleService;

    public CreateUserRoleCommandHandler(IUserRoleService roleService)
    {
        _userRoleService = roleService;
    }

    public async Task<MessageResponse> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        await _userRoleService.CreateAsync(request, cancellationToken);
        return new("Kullanıcıya rol başarılı bir şekilde atandı");
    }
}
