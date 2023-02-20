using AutoMapper;
using com.sun.xml.@internal.bind.v2.model.core;
using java.awt.print;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;
using System.Net;

namespace ProductsAPI.ProductOperations.UpdateProduct
{
    public class UpdateProductCommand
    { 
        public UpdateProductModel Model { get; set; }
        public int Id { get; set; }

        private readonly ProductContext _context;

        private readonly IMapper _mapper;

        public UpdateProductCommand(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == Id);
            product.Id = Model.Id != default ? Model.Id : product.Id;
            product.ProductName = Model.ProductName != default ? Model.ProductName : product.ProductName;
            product.ProductPrice = Model.ProductPrice != default ? Model.ProductPrice : product.ProductPrice;
            _context.SaveChanges();
        }
    }
    public class UpdateProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

    }
}
