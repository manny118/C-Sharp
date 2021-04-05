//Code adapted from Google's Codelab example

using System;
using Grpc.Core;
using Com.Example.Grpc;

//namespace for the square root server
namespace SquareRootServer
{
    class Program
    {
        const string Host = "localhost";//the host's name
        const int Port = 50051;//port to be used by client and server 

        public static void Main(string[] args)
        {
            // Build a server
            var server = new Server
            {
                Services = { SquareRootService.BindService(new GreeterServiceImpl()) },
                Ports = { new ServerPort(Host, Port, ServerCredentials.Insecure) }
            };

            // Start server
            server.Start();

            Console.WriteLine("GreeterServer listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}

