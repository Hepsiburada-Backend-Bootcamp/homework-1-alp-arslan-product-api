using Microsoft.AspNetCore.Mvc;
using ProductApi.Dtos;
using ProductApi.Exceptions;
using ProductApi.Models;
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

        //This endpoint is for testing purposes.
        //No endpoint should pass the model by itself.
        [HttpGet("admin")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAdmin()
        {
            return Ok(await _service.GetProductsAdmin());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct([FromRoute] int id)
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

        [HttpPost]
        public async Task<ActionResult<string>> CreateProduct([FromBody] CreateProductDto dto)
        {
            try
            {
                int id = await _service.CreateProduct(dto);
                //TODO: Refractor hard coded route
                return Created("api/v1/products/" + id, "api/v1/products/" + id);
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            try
            {
                bool status = await _service.DeleteProduct(id);
                return status ? NoContent() : NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateProduct([FromRoute]int id, [FromBody]UpdateProductDto dto)
        {
            try
            {
                await _service.UpdateProduct(id, dto);
            }
            catch (IdDoesNotBelongToProductExcepiton ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProductNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
