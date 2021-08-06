using FluentValidation.Results;
using MediatR;
using System;

namespace SMTC.Core.MediatR
{
    public abstract class Command : IRequest<ValidationResult>
    {
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }

    }
}
