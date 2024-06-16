using FDCleanArchitecture.Application.Features.RoleFeature.Commands.CreateRole;
using FDCleanArchitecture.Application.Services;
using FDCleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDCleanArchitecture.Persistance.Services
{
    public sealed class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task CreateAsync(CreateRoleCommand request)
        {
            Role role = new()
            {
                Name = request.Name
            };
            await _roleManager.CreateAsync(role);
        }
    }
}
