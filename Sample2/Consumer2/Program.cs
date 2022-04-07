using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer2
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // cria canal de comunicação com o RabbitMQ
                // declara fila que iremos trabalhar com nome "hello"
                // declarar uma fila é idempotente - se ela não existir será criada
                channel.QueueDeclare(queue: "queue2",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);

                    // Simula um processamento lento
                    Thread.Sleep(5000);
                };

                // autoAck: true - a mensagem é automaticamente removida da fila
                // autoAck: false - o RabbitMQ aguarda a confirmação do consumidor para remover a mensagem da fila
                channel.BasicConsume(queue: "queue2", autoAck: false, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
