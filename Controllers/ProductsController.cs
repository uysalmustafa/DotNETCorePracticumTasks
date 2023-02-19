using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Base;
using ProductsAPI.Models;
using ProductsAPI.Services;
using System.Collections.Generic;

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
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products =  _productService.GetProducts();
            return Ok(products);
        }


        // GET: api/Products/List
        [HttpGet("List")]

        public ActionResult<IEnumerable<Product>> List([FromQuery] QueryObject product)
        {
            var productList = _productService.List(product);
            return Ok(productList);
        }

        // GET: api/Products/2
        [HttpGet("{id}")]
        public ActionResult<Product> ProductById([FromRoute] int id)
        {
            var product = _productService.ProductById(id);
            return Ok(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct([FromRoute] int id, [FromBody] Product product)
        {
            var updatedProduct = _productService.UpdateProduct(id, product);
            return Ok(updatedProduct);
        }

        // POST: api/Products
        [HttpPost]
        public ActionResult<Product> PostProduct([FromBody] Product product)
        {
            var newProduct = _productService.PostProduct(product);
            return Ok(newProduct);
        }

        // DELETE: /api/Products/5
        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct([FromRoute] int id)
        {
            var deletedProduct = _productService.DeleteProduct(id);
            return Ok(deletedProduct);
        }
    }
}
