using Microsoft.EntityFrameworkCore;
using Online_Store_REST_API.EntityModels;
using Online_Store_REST_API.EntityModels.Products;
using Online_Store_REST_API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store_REST_API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineStoreDbContext _context;

        public ProductRepository(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void DeleteProduct(long id)
        {
            var product = FindProductById(id);
            _context.Products.Remove(product);
        }

        public Product FindProductById(long id)
        {
            var product = _context.Products.Find(id);
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = _context.Products
                .Include(c => c.Category)
                .Include(b => b.Brand);
            return products;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }
    }
}
