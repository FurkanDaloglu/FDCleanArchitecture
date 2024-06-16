using FDCleanArchitecture.Application.Services;
using FDCleanArchitecture.Domain.Dtos;
using MediatR;

namespace FDCleanArchitecture.Application.Features.RoleFeature.Commands.CreateRole;

public sealed class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, MessageResponse>
{
    private readonly IRoleService _roleService;

    public CreateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<MessageResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        await _roleService.CreateAsync(request);
        return new("Rol kaydı başarıyla tamamlandı");
    }
}
