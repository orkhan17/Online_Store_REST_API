using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Store_REST_API.Data.DataTransferObjects;
using Online_Store_REST_API.Data.Request;
using Online_Store_REST_API.Data.Request.Category;
using Online_Store_REST_API.Data.Response;
using Online_Store_REST_API.Services;
using Online_Store_REST_API.Services.Interfaces;

namespace Online_Store_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public ActionResult<GetResponse<CategoryViewDto>> GetCategory(long id)
        {
            var request = new GetRequest
                                {
                                    Id = id
                                };
            var response = _categoryService.GetCategory(request);
            return response;
        }

        [HttpGet()]
        public ActionResult<FetchResponse<CategoryViewDto>> FetchCategories()
        {
            var request = new FetchRequest { };
            var response = _categoryService.FetchCategories(request);
            return response;
        }

        [HttpPost()]
        public ActionResult<GetResponse<CategoryViewDto>> PostCategory(CreateCategoryRequest createCategoryRequest)
        {
            var response = _categoryService.CreateCategory(createCategoryRequest);
            return response;
        }

        [HttpPut("{id}")]
        public ActionResult<GetResponse<CategoryViewDto>> PutCategory(long id, UpdateCategoryRequest updateCategoryRequest)
        {
            var response = _categoryService.UpdateCategory(id, updateCategoryRequest);
            return response;
        }

        [HttpDelete("{id}")]
        public ActionResult<GetResponse<CategoryViewDto>> DeleteCategory(long id)
        {
            var request = new DeleteRequest
                                {
                                    Id = id
                                };
            var response = _categoryService.DeleteCategory(request);
            return response;
        }
    }
}