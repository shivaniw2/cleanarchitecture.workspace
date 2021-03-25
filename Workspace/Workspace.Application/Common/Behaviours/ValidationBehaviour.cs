using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace Workspace.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse>: IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //Pre functionalities to be performed here
            var context = new ValidationContext<TRequest>(request);
            var failures = _validator
                .Select(x => x.Validate(request))
                .SelectMany(x => x.Errors)
                .Where(x => x is not null);
            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
            return next();
            //Post functionalities to be performed here
        }
    }
}