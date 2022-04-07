## Persistência das mensagens em Disco

Aprendemos no **Sample1** como garantir que, mesmo que um dos consumidores morra, a tarefa não seja perdida.  
Mas nossas tarefas ainda serão perdidas se o servidor RabbitMQ parar.

Primeiro, precisamos ter certeza de que a fila sobreviverá a uma reinicialização do nó RabbitMQ. Para fazer isso:
```
var properties = channel.CreateBasicProperties();
properties.Persistent = true;
```

em seguida:
```
channel.BasicPublish(exchange: "",
    routingKey: "queue2",
    basicProperties: properties,
    body: body);
```

Segundo, precisamos dizer que a fila é durável, ou seja, cada novo consumidor que entrar vai consumir todas as mensagens desde o início:
```
channel.QueueDeclare(queue: "hello",
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);
```


