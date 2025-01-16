using EasyNetQ;
using Messages;

using (var bus = RabbitHutch.CreateBus("host=localhost"))
{
    await bus.PubSub.SubscribeAsync<TextMessage>("test", HandleTextMessage);
    Console.WriteLine("Listening for messages. Hit <return> to quit.");
    Console.ReadLine();
}

static void HandleTextMessage(TextMessage textMessage)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Got message: {0}", textMessage.Text);
    Console.ResetColor();
}