using FluentValidation;

namespace ProductsAPI.ProductOperations.GetProductById
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator() 
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
