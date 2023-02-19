using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Base;
using ProductsAPI.Controllers;
using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public interface IProductService
    {
        public BaseResponse<IEnumerable<Product>> GetProducts();
        public BaseResponse<IEnumerable<Product>> List([FromQuery] QueryObject product);
        public BaseResponse<Product> ProductById([FromRoute] int id);
        public BaseResponse<Product> UpdateProduct([FromRoute] int id, [FromBody] Product product);
        public BaseResponse<Product> PostProduct([FromBody] Product product);
        public BaseResponse<Product> DeleteProduct([FromRoute] int id);
    }
}
