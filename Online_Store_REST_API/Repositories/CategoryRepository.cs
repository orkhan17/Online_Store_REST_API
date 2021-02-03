using Online_Store_REST_API.EntityModels;
using Online_Store_REST_API.EntityModels.Products;
using Online_Store_REST_API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store_REST_API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly OnlineStoreDbContext _context;

        public CategoryRepository(OnlineStoreDbContext context)
        {
            _context = context;
        }
        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public void DeleteCategory(long id)
        {
            var category = FindCategoryById(id);
            _context.Categories.Remove(category);
        }

        public Category FindCategoryById(long id)
        {
            var catalog = _context.Categories.Find(id);
            return catalog;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categories = _context.Categories;
            return categories;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
