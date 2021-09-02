using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Grpc.Net.Client;
using JuiceGrpcService;

namespace JuiceGrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            // using var channel = GrpcChannel.ForAddress("http://localhost:5000");
            // var client = new Greeter.GreeterClient(channel);
            // var reply = await client.SayHelloAsync(
            //     new HelloRequest { Name = "GreeterClient" });
            // Console.WriteLine("Greeting: " + reply.Message);
            // Console.WriteLine("Press any key to exit...");
            // Console.ReadKey();

            
            var httpClient = new HttpClient();
            // var httpResponse = await httpClient.GetAsync("http://localhost:10000/t");
            var tasks = Enumerable.Range(1, 50).Select(x => httpClient.GetAsync("http://localhost:10000/t"));
            var res = await Task.WhenAll(tasks);

            foreach (var httpResponseMessage in res)
            {
                Console.WriteLine(httpResponseMessage.Content.ReadAsStringAsync().Result);
            }

            Console.WriteLine("Done. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
