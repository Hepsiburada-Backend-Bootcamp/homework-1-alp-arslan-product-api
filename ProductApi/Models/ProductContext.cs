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
            AddDummyData();
        }

        private void AddDummyData()
        {
            //This is a very bad way of filling the db,
            //Because of the scope, this method is called for every request.
            //TODO: Refractor this ASAP
            if (Products.Any())
                return;

            DateTime now = DateTime.Now;
            Products.AddRange(
                new Product
                {
                    Name = "Chair",
                    Description = "A chair",
                    Category = "Furniture",
                    Price = 50,
                    DateOfCreation = now,
                    DateOfLastEdit = now
                },
                new Product
                {
                    Name = "Sofa",
                    Description = "A sofa",
                    Category = "Furniture",
                    Price = 100,
                    DateOfCreation = now,
                    DateOfLastEdit = now
                },
                new Product
                {
                    Name = "Huge Phone",
                    Description = "The biggest phone yet",
                    Category = "Electronics",
                    Price = 5000,
                    DateOfCreation = now,
                    DateOfLastEdit = now
                }
                );
            this.SaveChanges();
        }

        public DbSet<Product> Products { get; set; }
    }
}
