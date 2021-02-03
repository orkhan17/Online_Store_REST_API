using Online_Store_REST_API.EntityModels;
using Online_Store_REST_API.EntityModels.Products;
using Online_Store_REST_API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store_REST_API.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly OnlineStoreDbContext _context;

        public BrandRepository(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public void AddBrand(Brand brand)
        {
            _context.Brands.Add(brand);
        }

        public void DeleteBrand(long id)
        {
            var brand = FindBrandById(id);
            _context.Brands.Remove(brand);
        }

        public Brand FindBrandById(long id)
        {
            var product = _context.Brands.Find(id);
            return product;
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            var brands = _context.Brands;
            return brands;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateBrand(Brand brand)
        {
            _context.Brands.Update(brand);
        }
    }
}
