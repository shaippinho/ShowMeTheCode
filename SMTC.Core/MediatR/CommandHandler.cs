using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTC.Core.MediatR
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(params string[] messages)
        {
            foreach (var message in messages)
                ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected ValidationResult WithError(params string[] messages)
        {
            AddError(messages);

            return ValidationResult;
        }
       
    }
}
