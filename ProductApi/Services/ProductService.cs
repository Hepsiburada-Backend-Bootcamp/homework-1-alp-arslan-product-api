using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Dtos;
using ProductApi.Exceptions;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        //TODO: Make a repository for ProductContext
        private readonly ProductContext _context;
        private readonly IMapper _mapper;

        public ProductService(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateProduct(CreateProductDto dto)
        {
            Product product = _mapper.Map<CreateProductDto, Product>(dto);
            product.DateOfCreation = product.DateOfLastEdit = DateTime.Now;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product.Id;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            _context.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ProductDto> GetProduct(int id)
        {

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                throw new ProductNotFoundException(id);
            }

            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts(string sortParameter)
        {
            List<Product> products = await _context.Products.ToListAsync();

            if (string.IsNullOrWhiteSpace(sortParameter))
                throw new ArgumentNullException();

            switch (sortParameter)
            {
                case "id":
                    products = products.OrderBy(p => p.Id).ToList();
                    break;
                case "name":
                    products = products.OrderBy(p => p.Name).ToList();
                    break;
                case "price":
                    products = products.OrderBy(p => p.Price).ToList();
                    break;
                case "category":
                    products = products.OrderBy(p => p.Category).ToList();
                    break;
                default:
                    break;
            }

            return _mapper.Map<List<Product>, IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<Product>> GetProductsAdmin()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task UpdateProduct(int id, UpdateProductDto dto)
        {
            if (id != dto.Id)
                throw new IdDoesNotBelongToProductExcepiton(id, dto.Name);

            bool exists = await _context.Products.AnyAsync(e => e.Id == id);
            if (!exists)
                throw new ProductNotFoundException(id);

            Product product = await _context.Products.FindAsync(id);
            product = _mapper.Map(dto, product);
            product.DateOfLastEdit = DateTime.Now;
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
