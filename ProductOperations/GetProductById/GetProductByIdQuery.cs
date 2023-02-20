using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Base;
using ProductsAPI.Models;

namespace ProductsAPI.ProductOperations.GetProductById
{
    public class GetProductByIdQuery
    {
        private readonly ProductContext _context;

        private readonly IMapper _mapper;

        public GetProductByIdQuery(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProductViewIdModel Handle(int id)
        {
            var product = _context.Products.Find(id);
            return _mapper.Map<ProductViewIdModel>(product);
        }

        public class ProductViewIdModel
        {
            public string ProductName { get; set; }
            public decimal ProductPrice { get; set; }

        }
    }
}
