using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //TODO: Make an interface for ProductContext
        private readonly ProductContext _context;
        private readonly IMapper _mapper;

        public ProductService(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<Product>, IEnumerable<ProductDto>>(products);
        }
    }
}
