using Microsoft.AspNetCore.Mvc;
using ProductApi.Dtos;
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

        [HttpGet]
        public ActionResult<ProductDto> GetProducts()
        {

            List<ProductDto> list = new List<ProductDto>();
            list.Add(new ProductDto
            {
                Id = 1,
                Name = "Chair",
                Description = "asd",
                Price = 50
            });
            return Ok(list);
        }
    }
}
