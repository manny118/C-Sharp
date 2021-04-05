//Code adapted from Google's Codelab example

//imports
using System;
using Grpc.Core;
using Com.Example.Grpc;

//namespace for the Greeter client
namespace GreeterClient
{
    public class gRPC_Client
    {
        const string Host = "localhost";//the host's name
        const int Port = 50051;//port to be used by client and server 

        public double client(double query)//method to be used by the calculator
        {
            // Create a channel
            var channel = new Channel(Host + ":" + Port, ChannelCredentials.Insecure);

            // Create a client with the channel
            var client = new SquareRootService.SquareRootServiceClient(channel);

            // Create a request
            var request = new HelloRequest {
                Query = query,
            };

            // Send the request
            Console.WriteLine("GreeterClient sending request");
            var response = client.squareRoot(request);

            Console.WriteLine("GreeterClient received response: " + response.Response);

            // Shutdown
            channel.ShutdownAsync().Wait();

            return response.Response;//return the square root result
        }
    }
}
