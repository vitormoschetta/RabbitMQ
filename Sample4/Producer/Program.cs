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
                // Declare the exchange
                // fanout é um tipo de exchange que envia mensagens para todos os consumidores
                channel.ExchangeDeclare(exchange: "exchange1", type: "fanout");

                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(1000);

                    string message = $"Hello World {i}!";

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "exchange1", // specify the exchange
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);

                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }

        }
    }
}
