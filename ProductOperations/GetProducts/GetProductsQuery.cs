using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Base;
using ProductsAPI.Models;
using System.Collections.Generic;

namespace ProductsAPI.ProductOperations.GetProducts
{
    public class GetProductsQuery
    {
        private readonly ProductContext _context;

        private readonly IMapper _mapper;

        public GetProductsQuery(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ProductsViewModel> Handle()
        {
            var products = from p in _context.Products
                           select p;

            return _mapper.Map<List<ProductsViewModel>>(products);
        }

        public class ProductsViewModel
        {
            public string ProductName { get; set; }
            public decimal ProductPrice { get; set; }
        }
    }
}
