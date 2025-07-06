using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Serilog;


namespace MerchantAPI.Application.Commons.Behaviors
{
    public class ValidationBehavior<TRequest , TResponse> (IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public readonly IEnumerable<IValidator<TRequest>> _validators = validators;
        public async Task<TResponse> Handle(TRequest request , RequestHandlerDelegate<TResponse> next , CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var failures = _validators
                    .Select(v => v.Validate(context))
                    .SelectMany(result => result.Errors)
                    .Where(f => f is not null)
                    .ToList();
                if (failures.Count != 0)
                {
                    Log.Error("Validation errors occurred: {@Failures}", failures);
                    throw new ValidationException(failures);
                }
            }
            Log.Error("Model validation passed for request: {@Request}", request);
            return await next();
        }
    }
}
