using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class RabbitMq : BackgroundService
{
    public RabbitMq(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
        this.factory = new ConnectionFactory { HostName = "localhost" };;
        this.connection = factory.CreateConnection();
        this.channel = connection.CreateChannel();
        channel.QueueDeclare(queue: "payment",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);
    }
    private readonly IServiceScopeFactory _serviceScopeFactory;
    public IConnectionFactory factory { get; private set; }
    public IConnection connection { get; private set; }
    public IChannel channel { get; private set; }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var body = ea.Body.ToArray();
                var messageBody = Encoding.UTF8.GetString(body);
                var paymentService = scope.ServiceProvider.GetRequiredService<IDeliveryService>();
                await paymentService.createDelivery(messageBody);
                Console.WriteLine($" [x] Received {messageBody}");
            }
        };
        channel.BasicConsume(queue: "payment",
          autoAck: true,
          consumer: consumer);
        return Task.CompletedTask;

    }
}