using CubeGPS.Business.Services;
using CubeGPS.Business.Services.Implementation;
using CubeGPS.Repository;
using CubeGPS.Repository.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CubeGPS.Root
{
    // Used for Dependency Injection
    public class DIRoot
    {
        public static void InjectDependencies(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<GPSContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IGPSService, GPSService>();
            services.AddScoped<IGPSRepository, GPSRepository>();
        }
    }
}
