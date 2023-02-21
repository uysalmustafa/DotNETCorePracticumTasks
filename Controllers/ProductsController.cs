using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Base;
using ProductsAPI.Models;
using ProductsAPI.ProductOperations.CreateProduct;
using ProductsAPI.ProductOperations.DeleteProduct;
using ProductsAPI.ProductOperations.GetProductById;
using ProductsAPI.ProductOperations.GetProducts;
using ProductsAPI.ProductOperations.UpdateProduct;
using ProductsAPI.Services;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static ProductsAPI.ProductOperations.CreateProduct.CreateProductCommand;
using static ProductsAPI.ProductOperations.GetProductById.GetProductByIdQuery;

namespace ProductsAPI.Controllers
{

    public class QueryObject
    {
        public string? ProductName { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;

        private readonly IMapper _mapper;

        public ProductsController(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            GetProductsQuery query = new GetProductsQuery(_context, _mapper);
            var prdocuts = query.Handle();
            return Ok(prdocuts);
        }

        // GET: api/Products/2
        [HttpGet("{id}")]
        public ActionResult<Product> ProductById([FromRoute] int id)
        {
            ProductViewIdModel result;
            GetProductByIdQuery query = new GetProductByIdQuery(_context, _mapper);
            query.Id = id;
            GetProductByIdQueryValidator validator = new GetProductByIdQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductModel product)
        {
            UpdateProductCommand command = new UpdateProductCommand(_context, _mapper);
            command.Model = product;
            command.Id = id;
            UpdateProductCommandValidator validator = new UpdateProductCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        // POST: api/Products
        [HttpPost]
        public ActionResult PostProduct([FromBody] CreateProductModel product)
        {
            CreateProductCommand command = new CreateProductCommand(_context, _mapper);
            command.Model = product;
            CreateProductCommandValidator validator = new CreateProductCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        // DELETE: /api/Products/5
        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct([FromRoute] int id)
        {
            DeleteProductCommand command = new DeleteProductCommand(_context);
            command.Id = id;
            DeleteProductCommandValidator validator = new DeleteProductCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
