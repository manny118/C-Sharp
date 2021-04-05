//Code adapted from Google's Codelab example

//imports
using Com.Example.Grpc;
using Grpc.Core;
using System.Threading.Tasks;
using System;

namespace SquareRootServer
{
    //craete a class for the GreeterServiceImpl
    //SquareRootServiceBase is an abstract class defined in the GreeterGrpc.cs file
    public class GreeterServiceImpl : SquareRootService.SquareRootServiceBase
    {
        //task for the squareRoot operation
        public override Task<HelloResponse> squareRoot(HelloRequest request, ServerCallContext context)
        {
            Console.WriteLine("Recieved value from client:  " + request.Query);
            return Task.FromResult(new HelloResponse {

                Response = Math.Pow(request.Query, 0.5)//caculates the sqaure root

            });
        }
    }

}
//end