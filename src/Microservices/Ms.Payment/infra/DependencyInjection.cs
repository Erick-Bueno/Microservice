
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        DotNetEnv.Env.Load();
        string? connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        services.AddDbContext<AppDbContext>(opt => opt.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"), m => m.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IConversorToModel, ConversorToModel>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IRabbitMq, RabbitMq>();
        //inicia o servico rabbitmq juntamente com a aplicacao
        services.AddHostedService<RabbitMq>();
        return services;
    }
}