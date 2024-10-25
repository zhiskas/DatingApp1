using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
namespace API.Extensions;

public static class ApplicationsServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();   
        services.AddScoped<IUserRepository, UserReposititory>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        return services;
    }
}