## Distribuição de mensagens para os consumidores

Por padrão, o RabbitMQ enviará cada mensagem para o próximo consumidor, em sequência. Em média, cada consumidor receberá o mesmo número de mensagens, independente do poder de processamento que tenha.

Execute as aplicações **Consumer**, **Consumer2** e **Producer** simultaneamente:

![alt text](../assets/images/sample1-a.png?raw=true=250x250 "Title")


## Confirmação de entrega de mensagem

Podemos configurar o RabbitMQ para remover a mensagem da fila ao ser consumida, ou remover apenas quando for confirmado o recebimento:
```
// autoAck: true - a mensagem é automaticamente removida da fila
// autoAck: false - o RabbitMQ aguarda a confirmação do consumidor para remover a mensagem da fila
channel.BasicConsume(queue: "hello", autoAck: false, consumer: consumer);
```

Podemos testar matando o **Consumer2** (Ctrl + C) antes de consumir suas mensagens, e vê-las sendo consumidas pelo **Consumer**.

