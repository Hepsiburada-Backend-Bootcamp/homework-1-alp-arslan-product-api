using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Models
{
    public class ProductContext : DbContext
    {
        //Mock in-memory DB, I implemented it to work async
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }
        
        public DbSet<Product> Products { get; set; }
    }
}
