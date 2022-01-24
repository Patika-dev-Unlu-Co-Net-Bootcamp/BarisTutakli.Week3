using FluentValidation;
using WebApi.ProductOperations.Handlers.CommandHandlers;

namespace WebApi.ProductOperations.Handlers.Validators
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommandHandler>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(command => command.ProductId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}
