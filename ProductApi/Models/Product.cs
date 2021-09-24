using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        //TODO: Make the category enum
        public string Category { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastEdit { get; set; }
    }
}
