using Online_Store_REST_API.Data.DataTransferObjects;
using Online_Store_REST_API.Data.Request;
using Online_Store_REST_API.Data.Request.Brand;
using Online_Store_REST_API.Data.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store_REST_API.Services.Interfaces
{
    public interface IBrandService
    {
        GetResponse<BrandViewDto> CreateBrand(CreateBrandRequest createBrandRequest);
        GetResponse<BrandViewDto> UpdateBrand(long id, UpdateBrandRequest updateBrandRequest);
        GetResponse<BrandViewDto> GetBrand(GetRequest getRequest);
        FetchResponse<BrandViewDto> FetchBrands(FetchRequest fetchRequest);
        GetResponse<BrandViewDto> DeleteBrand(DeleteRequest deleteRequest);
    }
}
