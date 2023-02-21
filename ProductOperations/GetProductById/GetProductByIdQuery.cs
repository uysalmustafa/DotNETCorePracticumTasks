using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Base;
using ProductsAPI.Models;
using static ProductsAPI.ProductOperations.CreateProduct.CreateProductCommand;

namespace ProductsAPI.ProductOperations.GetProductById
{
    public class GetProductByIdQuery
    {
        private readonly ProductContext _context;

        private readonly IMapper _mapper;

        public ProductViewIdModel Model { get; set; }

        public int Id { get; set; }

        public GetProductByIdQuery(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProductViewIdModel Handle()
        {
            var product = _context.Products.Find(Id);
            return _mapper.Map<ProductViewIdModel>(product);
        }

        public class ProductViewIdModel
        {
            public string ProductName { get; set; }
            public decimal ProductPrice { get; set; }
        }
    }
}
