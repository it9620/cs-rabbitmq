using RabbitMQ.Client;
using System.Text;

const string exchangeName = "direct_logs";

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

await channel.ExchangeDeclareAsync(exchange: exchangeName, type: ExchangeType.Direct);

var message = GetMessage(args);
var body = Encoding.UTF8.GetBytes(message);
await channel.BasicPublishAsync(
    exchange: exchangeName, routingKey: "black", body: body);

Console.WriteLine($" [x] Sent {message}");

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();

static string GetMessage(string[] args)
{
    return (args.Length > 0) ? string.Join(" ", args) : "Hello World!";
}
