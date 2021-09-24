using Microsoft.AspNetCore.Mvc;
using ProductApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();

    }
}
