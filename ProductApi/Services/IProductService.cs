using Microsoft.AspNetCore.Mvc;
using ProductApi.Dtos;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<IEnumerable<Product>> GetProductsAdmin();
        Task<ProductDto> GetProduct(int id);
        Task<int> CreateProduct(CreateProductDto dto);
        Task<bool> DeleteProduct(int id);
    }
}
