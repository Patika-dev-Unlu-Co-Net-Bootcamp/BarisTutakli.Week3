using CleanArch.Application.Cinemas.Commands.Request;
using CleanArch.Application.Cinemas.Handlers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Validators
{
    public class CreateCinemaCommandValidator:AbstractValidator<CreateCinemaCommandRequest>
    {
        public CreateCinemaCommandValidator()
        {
            RuleFor(command => command.Address).NotEmpty().NotNull().MinimumLength(10);
            RuleFor(command => command.Name).NotNull().NotEmpty().MinimumLength(2);
        }
    }
}
