using System;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Producer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {                
                channel.QueueDeclare(queue: "queue2",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                // cria fila durável e persistente em disco
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(1000);

                    string message = $"Hello World {i}!";

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                     routingKey: "queue2",
                                     basicProperties: properties, // seta propriedades da mensagem
                                     body: body);

                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }

        }
    }
}
