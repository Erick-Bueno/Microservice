using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services){
        DotNetEnv.Env.Load();
        string? connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        services.AddDbContext<AppDbContext>(opt => opt.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"), m => m.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IConversorDtoToModel, ConversorDtoToModel>();
        services.AddScoped<IRabbitMq, RabbitMq>();
     
        // inicia o servico junto com a aplicacao
        services.AddHostedService<RabbitMq>();
        return services;

    }
}