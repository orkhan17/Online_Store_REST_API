using Online_Store_REST_API.EntityModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store_REST_API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Category FindCategoryById(long id);
        IEnumerable<Category> GetAllCategories();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(long id);
        bool SaveAll();
    }
}
