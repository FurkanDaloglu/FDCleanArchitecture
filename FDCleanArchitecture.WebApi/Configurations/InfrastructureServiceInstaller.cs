
using FDCleanArchitecture.Application.Abstractions;
using FDCleanArchitecture.Infrastructure.Authentication;
using FDCleanArchitecture.WebApi.OptionsSetup;

namespace FDCleanArchitecture.WebApi.Configurations
{
    public sealed class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();
        }
    }
}
