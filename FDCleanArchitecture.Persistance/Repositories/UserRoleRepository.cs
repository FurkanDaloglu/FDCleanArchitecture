using FDCleanArchitecture.Domain.Entities;
using FDCleanArchitecture.Domain.Repositories;
using FDCleanArchitecture.Persistance.Context;
using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDCleanArchitecture.Persistance.Repositories
{
    public sealed class UserRoleRepository : Repository<UserRole, AppDbContext>, IUserRoleRepository
    {
        public UserRoleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
