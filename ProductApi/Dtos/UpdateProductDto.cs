using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Dtos
{
    public class UpdateProductDto
    {
        //TODO: Add validation
        //Maybe remove this and have only 2 dtos as request and response
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
    }
}
