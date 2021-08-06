using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SMTC.Core.Notification
{
    public class ValidationRequestBehavior<TRequest, Unit> : IPipelineBehavior<TRequest, Unit>
    {
        private readonly IEnumerable<IValidator> _validators;
        private readonly IDomainNotificationContext _notificationContext;

        public ValidationRequestBehavior(IEnumerable<IValidator<TRequest>> validators, IDomainNotificationContext notificationContext)
        {
            _validators = validators;
            _notificationContext = notificationContext;
        }

        public Task<Unit> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Unit> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
               .Select(v => v.ValidateAsync(context))
               .SelectMany(x => x.Result.Errors)
               .Where(f => f != null)
               .ToList();

            return failures.Any() ? Notify(failures) : next();
        }

        private Task<Unit> Notify(IEnumerable<ValidationFailure> failures)
        {
            var result = default(Unit);

            foreach (var failure in failures)
            {
                _notificationContext.NotifyError(failure.ErrorMessage);
            }

            return Task.FromResult(result);
        }
    }
}
