using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Core.Application.Features.Clients.Commands.UpdateClientCommand
{
    public class UpdateClientCommandValidator:AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(p => p.Name)
    .NotEmpty().WithMessage("{PropertyName} can't be empty")
    .MaximumLength(150).WithMessage("{PropertyName} must not exceed { Maxtength} characters");
            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .MaximumLength(150).WithMessage("{PropertyName} must not exceed { Maxtength} characters");
            RuleFor(p => p.BirthDate)
                .NotEmpty().WithMessage("{PropertyName} can't be empty");
            RuleFor(p => p.Phone)
                 .NotEmpty().WithMessage("{PropertyName} can't be empty")
                 .Matches(@"^(?:\+1)?8[024]9\d{7}$").WithMessage("{PropertyName} must be filled in format 809-000-0000")
                 .MaximumLength(9).WithMessage("{PropertyName} must not exceed { Maxtength} characters");
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .EmailAddress().WithMessage("{PropertyName} must be a valid email")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed { Maxtength} characters");
            RuleFor(p => p.Direction)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .MaximumLength(150).WithMessage("{PropertyName} must not exceed { Maxtength} characters");
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} can't be empty")
                .MaximumLength(150).WithMessage("{PropertyName} must not exceed { Maxtength} characters");
        }
    }
}
