using AuthApi.Data;
using AuthApi.Helpers;
using AuthApi.Services;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {



            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped<ITokenService, TokenService>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(connectionString);

            });

            return services;
        }
    }
}
