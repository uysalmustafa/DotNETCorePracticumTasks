using AutoMapper;
using ProductsAPI.Models;

namespace ProductsAPI.ProductOperations.CreateProduct
{
    public class CreateProductCommand
    {
        public CreateProductModel Model { get; set; }

        private readonly ProductContext _context;

        private readonly IMapper _mapper;
        public CreateProductCommand(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var product = _mapper.Map<Product>(Model);
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public class CreateProductModel
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public decimal ProductPrice { get; set; }
        }
    }
}
