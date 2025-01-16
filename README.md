# RabbitMQ Producer

[The source](https://www.rabbitmq.com/tutorials/tutorial-one-dotnet)

## Commands install and run

```sh
docker pull rabbitmq:management

docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management

# Open the page

http://localhost:15672/


# Stop and Remove the container
docker stop rabbitmq
docker rm rabbitmq
```

Trouble shoot with unaccess port:

```sh
# Restart winnat service:

net stop winnat
net start winnat

```

---

## Create solution

```sh
# Create solution
dotnet new sln -n EasyNetQTest

# Create projects
dotnet new console -lang c# -n Publisher -o ./Publisher -f net8.0
dotnet new console -lang c# -n Subscriber -o ./Subscriber -f net8.0
dotnet new classlib -lang c# -n Messages -o ./Messages -f net8.0

# Link projects to sln
dotnet sln ./EasyNetQTest.sln add ./Publisher
dotnet sln ./EasyNetQTest.sln add ./Subscriber
dotnet sln ./EasyNetQTest.sln add ./Messages

# Add Messages reference
dotnet add ./Publisher/Publisher.csproj reference ../Messages/Messages.csproj
dotnet add ./Publisher/Subscriber.csproj reference ../Messages/Messages.csproj

# Link libraryes
dotnet add Publisher package EasyNetQ
dotnet add Subscriber package EasyNetQ

dotnet add Publisher package Newtonsoft.Json
dotnet add Subscriber package Newtonsoft.Json

dotnet add Publisher package EasyNetQ.Serialization.SystemTextJson
dotnet add Subscriber package EasyNetQ.Serialization.SystemTextJson

dotnet add Publisher package EasyNetQ.DI.Microsoft
dotnet add Subscriber package EasyNetQ.DI.Microsoft

dotnet add Publisher package Microsoft.Extensions.DependencyInjection
dotnet add Subscriber package Microsoft.Extensions.DependencyInjection
```

---

## Connect to container daemon

```sh
docker exec -it rabbitmq /bin/bash
```

Print message_unacknowledged and ready messages:

```sh
sudo rabbitmqctl list_queues name messages_ready messages_unacknowledged
# Or in container, just without sudo
rabbitmqctl list_queues name messages_ready messages_unacknowledged
```

Print exchanges

```sh
rabbitmqctl list_exchanges
```

List bindings

```sh
rabbitmqctl list_bindings
```

---
