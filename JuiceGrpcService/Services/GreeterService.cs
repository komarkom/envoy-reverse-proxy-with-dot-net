using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuiceGrpcService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Sending hello to {request.Name}");
            return Task.FromResult(new HelloReply { Message = $"Hello {request.Name}" });
        }

        public override Task<HelloReply> SayHelloFrom(HelloRequestFrom request, ServerCallContext context)
        {
            _logger.LogInformation($"Sending hello to {request.Name} from {request.From}");
            return Task.FromResult(new HelloReply { Message = $"Hello {request.Name} from {request.From}" });
        }
    }
}
