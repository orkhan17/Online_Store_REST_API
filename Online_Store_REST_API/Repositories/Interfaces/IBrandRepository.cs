using Online_Store_REST_API.EntityModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store_REST_API.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Brand FindBrandById(long id);
        IEnumerable<Brand> GetAllBrands();
        void AddBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void DeleteBrand(long id);
        bool SaveAll();
    }
}
