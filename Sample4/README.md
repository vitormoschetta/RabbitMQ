## Pub/Sub

É possível configurar o RabbitMQ para entregar uma mensagem a vários consumidores. Esse padrão é conhecido como "publish/subscribe", ou "pub/sub".

## Exchange

O produtor pode enviar mensagens para uma **exchange**. A exchange deve saber exatamente o que fazer com uma mensagem que recebe. Deve ser anexado a uma fila específica? Deve ser anexado a muitas filas? Ou deve ser descartado. As regras para isso são definidas pelo **exchange type**.

