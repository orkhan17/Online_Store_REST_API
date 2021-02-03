using AutoMapper;
using Online_Store_REST_API.Data.DataTransferObjects;
using Online_Store_REST_API.Data.Request;
using Online_Store_REST_API.Data.Request.Category;
using Online_Store_REST_API.Data.Response;
using Online_Store_REST_API.EntityModels.Products;
using Online_Store_REST_API.Repositories.Interfaces;
using Online_Store_REST_API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Online_Store_REST_API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public GetResponse<CategoryViewDto> CreateCategory(CreateCategoryRequest createCategoryRequest)
        {
            var response = new GetResponse<CategoryViewDto>();
            try
            {
                var categeory = _mapper.Map<Category>(createCategoryRequest);
                _categoryRepository.AddCategory(categeory);
                bool result = _categoryRepository.SaveAll();

                if(result)
                {
                    response.Data = _mapper.Map<CategoryViewDto>(categeory);
                    response.Messages.Add("Successfully created new category");
                    response.StatusCode = HttpStatusCode.OK;
                }
            }
            catch (Exception e)
            {
                var error = e.ToString();
                response.Messages.Add(error);
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }

        public GetResponse<CategoryViewDto> DeleteCategory(DeleteRequest deleteRequest)
        {
            var response = new GetResponse<CategoryViewDto>();
            try
            {
                var category = _categoryRepository.FindCategoryById(deleteRequest.Id);
                if(category == null)
                {
                    response.Messages.Add("Not found brand");
                    response.StatusCode = HttpStatusCode.NotFound;
                    return response;
                }
                _categoryRepository.DeleteCategory(deleteRequest.Id);
                bool result = _categoryRepository.SaveAll();

                if(result)
                {
                    response.Data = _mapper.Map<CategoryViewDto>(category);
                    response.Messages.Add("Category is deleted");
                    response.StatusCode = HttpStatusCode.OK;
                }

            }
            catch (Exception e)
            {
                var error = e.ToString();
                response.Messages.Add(error);
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }

        public FetchResponse<CategoryViewDto> FetchCategories(FetchRequest fetchRequest)
        {
            var response = new FetchResponse<CategoryViewDto>();
            try
            {
                var categories = _categoryRepository.GetAllCategories();
                response.Data = _mapper.Map<IEnumerable<CategoryViewDto>>(categories);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                var error = e.ToString();
                response.Messages.Add(error);
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }

        public GetResponse<CategoryViewDto> GetCategory(GetRequest getRequest)
        {
            var response = new GetResponse<CategoryViewDto>();
            try
            {
                var category = _categoryRepository.FindCategoryById(getRequest.Id);
                if(category == null)
                {
                    response.Messages.Add("Not found category");
                    response.StatusCode = HttpStatusCode.NotFound;
                    return response;
                }
                response.Data = _mapper.Map<CategoryViewDto>(category);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                var error = e.ToString();
                response.Messages.Add(error);
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }

        public GetResponse<CategoryViewDto> UpdateCategory(long id, UpdateCategoryRequest updateCategoryRequest)
        {
            var response = new GetResponse<CategoryViewDto>();
            try
            {
                var category = _categoryRepository.FindCategoryById(id);
                if(category == null)
                {
                    response.Messages.Add("Not found category");
                    response.StatusCode = HttpStatusCode.NotFound;
                    return response;
                }
                _mapper.Map(updateCategoryRequest, category);
                _categoryRepository.UpdateCategory(category);

                bool result = _categoryRepository.SaveAll();
                if(result)
                {
                    response.Data = _mapper.Map<CategoryViewDto>(category);
                    response.Messages.Add("Category is updated");
                    response.StatusCode = HttpStatusCode.OK;
                }
            }
            catch (Exception e)
            {
                var error = e.ToString();
                response.Messages.Add(error);
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }
    }
}
