using RabbitMQ.Client;
using System.Text;

const string exchangeName = "topic_logs";

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

await channel.ExchangeDeclareAsync(exchange: exchangeName, type: ExchangeType.Topic);

var routingKey = (args.Length > 0) ? args[0] : "anonymous.info";
var message = GetMessage(args);
var body = Encoding.UTF8.GetBytes(message);
await channel.BasicPublishAsync(
    exchange: exchangeName, routingKey: routingKey, body: body);

Console.WriteLine($" [x] Sent '{routingKey}':'{message}'");

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();

static string GetMessage(string[] args)
{
    return (args.Length > 1) ? string.Join(" ", args) : "Hello World!";
}
