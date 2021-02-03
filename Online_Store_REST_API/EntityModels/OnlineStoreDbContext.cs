using Microsoft.EntityFrameworkCore;
using Online_Store_REST_API.EntityModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store_REST_API.EntityModels
{
    public class OnlineStoreDbContext: DbContext
    {
        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
