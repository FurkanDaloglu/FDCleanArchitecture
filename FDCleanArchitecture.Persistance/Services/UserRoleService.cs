using FDCleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using FDCleanArchitecture.Application.Services;
using FDCleanArchitecture.Domain.Entities;
using FDCleanArchitecture.Domain.Repositories;
using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDCleanArchitecture.Persistance.Services
{
    public sealed class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUserRoleRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            UserRole userRole = new()
            {
                RoleId = request.RoleId,
                AppUserId = request.AppUserId
            };

            await _repository.AddAsync(userRole, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
