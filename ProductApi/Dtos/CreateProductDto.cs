using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Dtos
{
    public class CreateProductDto
    {
        //TODO: Maybe make category enum
        [Required, StringLength(56, MinimumLength = 4)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required, Range(1, 50000)]
        public double Price { get; set; }
    }
}
