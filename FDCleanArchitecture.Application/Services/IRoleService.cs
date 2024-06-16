using FDCleanArchitecture.Application.Features.RoleFeature.Commands.CreateRole;

namespace FDCleanArchitecture.Application.Services
{
    public interface IRoleService
    {
        Task CreateAsync(CreateRoleCommand request);
    }
}
