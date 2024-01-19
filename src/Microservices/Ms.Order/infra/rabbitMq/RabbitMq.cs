using System.Text;
using RabbitMQ.Client;

public class RabbitMq : IRabbitMq
{
    public ConnectionFactory factory { get; private set; }
    public IConnection connection { get; private set; }
    public IChannel channel { get; private set; }
    public RabbitMq()
    {
        factory = new ConnectionFactory { HostName = "localhost" };
        connection = factory.CreateConnection();
        channel = connection.CreateChannel();
        channel.QueueDeclare("pedido", durable: false, exclusive: false, autoDelete: false, arguments: null);
    }
    public async void producer(int id, DateTime date)
    {
        string data = $"{id}, {date}";
        var body = Encoding.UTF8.GetBytes(data);
        BasicProperties basicProperties = new BasicProperties();
        channel.BasicPublish<BasicProperties>(exchange: string.Empty, routingKey: "pedido", basicProperties:basicProperties, body: body);
        await channel.CloseAsync();
        await connection.CloseAsync();


    }
}