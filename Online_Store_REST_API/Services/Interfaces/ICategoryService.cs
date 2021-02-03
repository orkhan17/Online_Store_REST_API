using Online_Store_REST_API.Data.DataTransferObjects;
using Online_Store_REST_API.Data.Request;
using Online_Store_REST_API.Data.Request.Category;
using Online_Store_REST_API.Data.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store_REST_API.Services.Interfaces
{
    public interface ICategoryService
    {
        GetResponse<CategoryViewDto> CreateCategory(CreateCategoryRequest createCategoryRequest);
        GetResponse<CategoryViewDto> UpdateCategory(long id, UpdateCategoryRequest updateCategoryRequest);
        GetResponse<CategoryViewDto> GetCategory(GetRequest getRequest);
        FetchResponse<CategoryViewDto> FetchCategories(FetchRequest fetchRequest);
        GetResponse<CategoryViewDto> DeleteCategory(DeleteRequest deleteRequest);
    }
}
