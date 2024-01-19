
using System.Text;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
//ao herdar backgroundservice eu estou indicando q essa classe sera um servico q rodara em segundo plano, e o que sera executado sera definido no metodo execute async
public class RabbitMq : BackgroundService, IRabbitMq
{
    public IConnectionFactory factory { get; set; }
    public IConnection connection { get; private set; }
    public IChannel channel { get; private set; }
    public RabbitMq(){
        factory = new ConnectionFactory { HostName = "localhost" };
        connection = factory.CreateConnection();
        channel = connection.CreateChannel();
         channel.QueueDeclare(queue: "order",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);
    }
    public async void producer(int id, DateTime data)
    {
        var message = $"{id}, {data}";
        var body = Encoding.UTF8.GetBytes(message);

        BasicProperties basicProperties = new BasicProperties();

        channel.BasicPublish<BasicProperties>(exchange: string.Empty,
                     routingKey: "order",
                     basicProperties: basicProperties,
                     body: body);
        await connection.CloseAsync();
        await channel.CloseAsync();
    }
    // e executado assim que e iniciado
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
          return Task.CompletedTask;
    }

}