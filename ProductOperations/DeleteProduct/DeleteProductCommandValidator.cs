using FluentValidation;


namespace ProductsAPI.ProductOperations.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator() 
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
