using FluentValidation;

namespace ProductsAPI.ProductOperations.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() 
        {
            RuleFor(command => command.Model.Id).GreaterThan(0);
            RuleFor(command => command.Model.ProductName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.ProductPrice).GreaterThan(0);
        }
    }
}
