## Despacho Justo

Essa configuração permite que o RabbitMQ Client verifique se um consumidor ainda não confirmou o recebimento, se está lento pra ler, e passa mais mensagens para outro consumidor com melhor desempenho:
```
channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
```

e:
```
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
    
    Console.WriteLine(" [x] Received {0}", message);
};
```