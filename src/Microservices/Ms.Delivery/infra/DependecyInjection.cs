using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure (this IServiceCollection services){
        DotNetEnv.Env.Load();
        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        services.AddDbContext<AppDbContext>(opt => opt.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"), m => m.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
        services.AddScoped<IDeliveryRepository, DeliveryRepository>();
        services.AddScoped<IDeliveryService, DeliveryService>();
        services.AddScoped<IConversorToModel, ConversorToModel>();
        services.AddHostedService<RabbitMq>();
        return services;
    }
}