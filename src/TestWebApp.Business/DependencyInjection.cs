using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestWebApp.Business.services;
using TestWebApp.DataAccess.Context;
using TestWebApp.DataAccess.Interfaces;
using TestWebApp.DataAccess.Repositories;

namespace TestWebApp.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Inyección de AppDbContext (EF Core)
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Repositorio y servicios
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
