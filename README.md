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

## Link library to the project

```sh
dotnet new console --name RabbitMqProducer
dotnet new console --name RabbitMqConsumer

# cd and add nuget package to each directory
dotnet add package RabbitMQ.Client
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

---
