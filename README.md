# RabbitMQ Producer

https://www.rabbitmq.com/tutorials/tutorial-one-dotnet

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
dotnet add package RabbitMQ.Client
```

---
