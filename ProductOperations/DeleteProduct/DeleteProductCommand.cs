using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;
using System.Net;

namespace ProductsAPI.ProductOperations.DeleteProduct
{
    public class DeleteProductCommand
    {

        private readonly ProductContext _context;

        public int Id { get; set; }

        public DeleteProductCommand(ProductContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var product = _context.Products.Find(Id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
