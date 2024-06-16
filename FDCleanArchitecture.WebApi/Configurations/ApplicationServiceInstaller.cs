
using FDCleanArchitecture.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace FDCleanArchitecture.WebApi.Configurations
{
    public sealed class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration,IHostBuilder host)
        {
            services.AddMediatR(cfr =>
cfr.RegisterServicesFromAssembly(typeof(FDCleanArchitecture.Application.AssemblyReference).Assembly));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(FDCleanArchitecture.Application.AssemblyReference).Assembly);
        }
    }
}
