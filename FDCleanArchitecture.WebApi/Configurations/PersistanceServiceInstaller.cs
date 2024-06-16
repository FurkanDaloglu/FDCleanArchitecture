
using FDCleanArchitecture.Domain.Entities;
using FDCleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace FDCleanArchitecture.WebApi.Configurations
{
    public sealed class PersistanceServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
        {
            services.AddAutoMapper(typeof(FDCleanArchitecture.Persistance.AssemblyReference).Assembly);

            string connectionString = configuration.GetConnectionString("SqlServer");
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddIdentity<AppUser, Role>().AddEntityFrameworkStores<AppDbContext>();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()//loglamanın hangi seviyede başlayacağını ayarlar.
                .Enrich.FromLogContext()//contexten gelen değerlerde daha detaylı loglama yapmaya yarar.
                .WriteTo.Console()//consola yazdırmaya yarar.
                .WriteTo.File("Logs/log*.txt", rollingInterval: RollingInterval.Day)//logun ne kadar sürede hangi pathe kaydolacağına yarar.
                .WriteTo.MSSqlServer(
                connectionString: connectionString,
                tableName: "Logs",
                autoCreateSqlTable: true)
                .CreateLogger();

            host.UseSerilog();
        }
    }
}
