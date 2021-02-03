using Online_Store_REST_API.EntityModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store_REST_API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product FindProductById(long id);
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(long id);
        bool SaveAll();
    }
}
