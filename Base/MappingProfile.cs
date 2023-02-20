using AutoMapper;
using ProductsAPI.Models;
using static ProductsAPI.ProductOperations.CreateProduct.CreateProductCommand;
using static ProductsAPI.ProductOperations.GetProductById.GetProductByIdQuery;
using static ProductsAPI.ProductOperations.GetProducts.GetProductsQuery;
using ProductsAPI.ProductOperations.UpdateProduct;

namespace ProductsAPI.Base
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductModel, Product>();
            CreateMap<Product, ProductViewIdModel>();
            CreateMap<Product, ProductsViewModel>();
            CreateMap<Product, UpdateProductModel>();
        }
    }
}
