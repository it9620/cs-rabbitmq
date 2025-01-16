using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//const string queueName = "logs";
const string exchangeName = "logs";

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

await channel.ExchangeDeclareAsync(exchange: exchangeName, type: ExchangeType.Fanout);

// Declare exchange by Work model:
// await channel.QueueDeclareAsync(queue: queueName, durable: false, exclusive: false,
//    autoDelete: false, arguments: null);
// await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 1, global: false);

// Declare temporary queue:
QueueDeclareOk queueDeclareResult = await channel.QueueDeclareAsync();
string queueName = queueDeclareResult.QueueName;

// Binding queue to exchange:
await channel.QueueBindAsync(
    queue: queueName, exchange: exchangeName, routingKey: string.Empty);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new AsyncEventingBasicConsumer(channel);

consumer.ReceivedAsync += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received {message}");

    int dots = message.Split('.').Length - 1;
    await Task.Delay(dots * 1000);

    Console.WriteLine(" [x] Done");
};

await channel.BasicConsumeAsync(queue: queueName, autoAck: true, consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
