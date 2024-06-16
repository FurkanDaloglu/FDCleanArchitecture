
using FDCleanArchitecture.Application.Services;
using FDCleanArchitecture.Domain.Repositories;
using FDCleanArchitecture.Persistance.Context;
using FDCleanArchitecture.Persistance.Repositories;
using FDCleanArchitecture.Persistance.Services;
using FDCleanArchitecture.Presentation.Repositories;
using FDCleanArchitecture.WebApi.Middleware;
using GenericRepository;

namespace FDCleanArchitecture.WebApi.Configurations
{
    public sealed class PersistanceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserRoleService, UserRoleService>();

            services.AddTransient<ExceptionMiddleware>();
            services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        }
    }
}
