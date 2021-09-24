using Microsoft.AspNetCore.Mvc;
using ProductApi.Dtos;
using ProductApi.Exceptions;
using ProductApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _service;

        public ProductController(IProductService productService)
        {
            _service = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            return Ok(await _service.GetProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct([FromRoute]int id)
        {
            try
            {
                return Ok(await _service.GetProduct(id));
            }
            catch (ProductNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
