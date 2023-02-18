using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MessagePack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public ProductsController(ProductContext context)
        {
            _context = context;
        }


        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts([FromQuery] string? sortOrder)
        {

            string nameSortParam = String.IsNullOrEmpty(sortOrder) ? "id_asc" : "";

            var products = from p in _context.Products
                           select p;

            switch (sortOrder)
            {
                case "id_desc":
                    products = products.OrderByDescending(s => s.Id);
                    break;
                case "id_asc":
                    products = products.OrderBy(s => s.Id);
                    break;
                case "productname_desc":
                    products = products.OrderByDescending(s => s.ProductName);
                    break;
                case "productname_asc":
                    products = products.OrderBy(s => s.ProductName);
                    break;
                case "productprice_desc":
                    products = products.OrderByDescending(s => s.ProductPrice);
                    break;
                case "productprice_asc":
                    products = products.OrderBy(s => s.ProductPrice);
                    break;
                default:
                    products = products.OrderBy(s => s.Id);
                    break;
            }

            return products.ToList();
        }


        // GET: api/Products/List
        [HttpGet("List")]
        public ActionResult<IEnumerable<Product>> List([FromQuery] QueryObject product)
        {
            var products = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(product.ProductName))
            {
                products = products.Where(e => e.ProductName.Contains(product.ProductName));
            }
            return products.ToList();
        }

        // GET: api/Products/ProductByIdQuery
        [HttpGet("ProductByIdQuery")]
        public  ActionResult<Product> ProductByIdQuery([FromQuery] int id)
        {
            var product =  _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        // GET: api/Products/ProductByIdRoute/2
        [HttpGet("ProductByIdRoute/{id}")]
        public ActionResult<Product> ProductByIdRoute([FromRoute] int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public  ActionResult<Product> PostProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ProductByIdQuery), new { id = product.Id }, product);
        }

        // DELETE: /api/Products/ProductByRoute/5
        [HttpDelete("ProductByRoute/{id}")]
        public  IActionResult DeleteProductByRoute([FromRoute] int id)
        {
            var product =  _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: /api/Products/ProductByQuery
        [HttpDelete("ProductByQuery")]
        public IActionResult DeleteProductByQuery([FromQuery] int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }


        // PATCH: api/Products/5
        [HttpPatch("{id}")]
        public  IActionResult UpdatePatch(int id, JsonPatchDocument<Product> patchDoc)
        {
            var product = _context.Products.Find(id);

            if (product == null)
                return NotFound();

            patchDoc.ApplyTo(product, ModelState);
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            _context.SaveChanges();
            return NoContent();  
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
