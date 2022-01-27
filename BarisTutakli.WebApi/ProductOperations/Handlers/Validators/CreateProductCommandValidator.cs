using FluentValidation;
using WebApi.ProductOperations.Commands.Request;
using WebApi.ProductOperations.Handlers.CommandHandlers;

namespace WebApi.ProductOperations.Handlers.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandHandler>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(command => command.Model.CategoryId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(command => command.Model.ProductName).MinimumLength(2).NotEmpty();
            RuleFor(command => command.Model.PublishDate.Year).GreaterThan(1800);
        }
    }
}
