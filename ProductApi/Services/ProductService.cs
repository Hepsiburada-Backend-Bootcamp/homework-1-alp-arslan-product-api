using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Dtos;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {

        private readonly List<Product> _products;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
            _products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Chair",
                    Description = "asd",
                    Price = 50
                },
                new Product
                {
                    Id = 2,
                    Name = "Sofa",
                    Description = "adsafsd",
                    Price = 100
                }
            };
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            //return null;
            return _mapper.Map<List<Product>, IEnumerable<ProductDto>>(_products);
        }
    }
}
