using BookTok.Domain.Entities;
using BookTok.Infrastructure.Persistence;
using BookTok.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookTok.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionStringName = "BooktokDB";
        var connectionString = configuration.GetConnectionString(connectionStringName);

        services.AddDbContext<BooktokDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IBooktokSeeder, BooktokSeeder>();
    }
}
