using FluentValidation;


namespace ProductsAPI.ProductOperations.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator() {
            RuleFor(command => command.Model.Id).GreaterThan(0);
            RuleFor(command => command.Model.ProductName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.ProductPrice).GreaterThan(0);
        }
    }
}
