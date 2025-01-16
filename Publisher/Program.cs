using EasyNetQ;
using Messages;

using (var bus = RabbitHutch.CreateBus("host=localhost"))
{
    var input = string.Empty;
    Console.WriteLine("Enter a message. 'Quit' to quit.");
    while ((input = Console.ReadLine()) != "Quit")
    {
        await bus.PubSub.PublishAsync(new TextMessage { Text = input });
        Console.WriteLine("Message published!");
    }
}