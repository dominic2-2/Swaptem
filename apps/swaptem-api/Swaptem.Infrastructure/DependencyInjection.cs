using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swaptem.Infrastructure.Persistence;

namespace Swaptem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Chỉ sử dụng PostgreSQL
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<SwaptemDbContext>(options =>
            options.UseNpgsql(connectionString, b => 
                b.MigrationsAssembly("Swaptem.Infrastructure")));

        return services;
    }
}
