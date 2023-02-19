using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Base;
using ProductsAPI.Controllers;
using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _context;

        public ProductService(ProductContext context)
        {
            _context = context;
        }
        public BaseResponse<Product> DeleteProduct([FromRoute] int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return BaseResponse<Product>.Success(200, product);
        }

        public BaseResponse<IEnumerable<Product>> GetProducts()
        {
            var products = from p in _context.Products
                           select p;
            return BaseResponse<IEnumerable<Product>>.Success(200, products.ToList());
        }

        public BaseResponse<IEnumerable<Product>> List([FromQuery] QueryObject product)
        {
            var products = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(product.ProductName))
            {
                products = products.Where(e => e.ProductName.Contains(product.ProductName));
            }
            return BaseResponse<IEnumerable<Product>>.Success(200, products.ToList());
        }

        public BaseResponse<Product> PostProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return BaseResponse<Product>.Success(201, product);
        }

        public BaseResponse<Product> ProductById([FromRoute] int id)
        {
            var product = _context.Products.Find(id);
            return BaseResponse<Product>.Success(200, product);
        }

        public BaseResponse<Product> UpdateProduct([FromRoute] int id, [FromBody] Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return BaseResponse<Product>.Success(200, product);
        }
    }
}
