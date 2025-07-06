using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace MerchantAPI.Application.Commons.Behaviors
{
    public class LoggingBehavior<TRequest , TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Log the request details here
           Log.Information("Handling {RequestName} with data: {@Request}", typeof(TRequest).Name, request);
            // Call the next delegate/middleware in the pipeline
            var response = await next();
            // Log the response details here
            Log.Information("Handled {RequestName} with response: {@Response}", typeof(TRequest).Name, response);
            return response;
        }
    }
}
