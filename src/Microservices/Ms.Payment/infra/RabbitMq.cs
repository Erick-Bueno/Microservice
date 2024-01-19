using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class RabbitMq : BackgroundService, IRabbitMq
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    public ConnectionFactory factory { get; private set; }
    public IConnection connection { get; private set; }
    public IChannel channel { get; private set; }
    public RabbitMq(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
        factory = new ConnectionFactory { HostName = "localhost" };
        connection = factory.CreateConnection();
        channel = connection.CreateChannel();
           channel.QueueDeclare(queue: "payment",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);
            channel.QueueDeclare(queue: "order",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

    }

    public async void producer(int id)
    {
        var message = $"{id}";
        var body = Encoding.UTF8.GetBytes(message);

        BasicProperties basicProperties = new BasicProperties();

        channel.BasicPublish<BasicProperties>(exchange: string.Empty,
                     routingKey: "payment",
                     basicProperties: basicProperties,
                     body: body);
        await connection.CloseAsync();
        await channel.CloseAsync();
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        //solicita entrega das msg de forma assincrona e retorna
        var consumer = new EventingBasicConsumer(channel);
        //receber a mensagem da fila, converter e imprimir
        consumer.Received += async (model, ea) =>
        {
            //cria um escopo personalizado e resolve a dependencia do paymente service
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var body = ea.Body.ToArray();
                var messageBody = Encoding.UTF8.GetString(body);
                var paymentService = scope.ServiceProvider.GetRequiredService<IPaymentService>();
                await paymentService.create(messageBody);
               Console.WriteLine($" [x] Received {messageBody}");
            }
        };
        //indicamos o consumo da mensagem
        channel.BasicConsume(queue: "order",
                     autoAck: true,
                     consumer: consumer);
        return Task.CompletedTask;

    }
}