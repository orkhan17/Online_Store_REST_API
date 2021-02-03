using AutoMapper;
using Online_Store_REST_API.Data.DataTransferObjects;
using Online_Store_REST_API.Data.Request;
using Online_Store_REST_API.Data.Request.Brand;
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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public GetResponse<BrandViewDto> CreateBrand(CreateBrandRequest createBrandRequest)
        {
            var response = new GetResponse<BrandViewDto>();
            try
            {
                var brand = _mapper.Map<Brand>(createBrandRequest);
                _brandRepository.AddBrand(brand);
                bool result = _brandRepository.SaveAll();
                if(result)
                {
                    response.Data = _mapper.Map<BrandViewDto>(brand);
                    response.Messages.Add("Successfully created new brand");
                    response.StatusCode = HttpStatusCode.Created;
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

        public GetResponse<BrandViewDto> DeleteBrand(DeleteRequest deleteRequest)
        {
            var response = new GetResponse<BrandViewDto>();
            try
            {
                var brand = _brandRepository.FindBrandById(deleteRequest.Id);
                if(brand == null)
                {
                    response.Messages.Add("Not found brand");
                    response.StatusCode = HttpStatusCode.NotFound;
                    return response;
                }
                _brandRepository.DeleteBrand(deleteRequest.Id);
                bool result = _brandRepository.SaveAll();
                if(result)
                {
                    response.Data = _mapper.Map<BrandViewDto>(brand);
                    response.Messages.Add("Brand is deleted");
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

        public FetchResponse<BrandViewDto> FetchBrands(FetchRequest fetchRequest)
        {
            var response = new FetchResponse<BrandViewDto>();
            try
            {
                var brands = _brandRepository.GetAllBrands();
                response.Data = _mapper.Map<IEnumerable<BrandViewDto>>(brands);
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

        public GetResponse<BrandViewDto> GetBrand(GetRequest getRequest)
        {
            var response = new GetResponse<BrandViewDto>();
            try
            {
                var brand = _brandRepository.FindBrandById(getRequest.Id);
                if(brand == null)
                {
                    response.Messages.Add("Not found brand");
                    response.StatusCode = HttpStatusCode.NotFound;
                    return response;
                }
                response.Data = _mapper.Map<BrandViewDto>(brand);
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

        public GetResponse<BrandViewDto> UpdateBrand(long id, UpdateBrandRequest updateBrandRequest)
        {
            var response = new GetResponse<BrandViewDto>();
            try
            {
                var brand = _brandRepository.FindBrandById(id);
                if(brand == null)
                {
                    response.Messages.Add("Not found brand");
                    response.StatusCode = HttpStatusCode.NotFound;
                    return response;
                }
                _mapper.Map(updateBrandRequest, brand);
                _brandRepository.UpdateBrand(brand);

                bool result = _brandRepository.SaveAll();

                if(result)
                {
                    response.Data = _mapper.Map<BrandViewDto>(brand);
                    response.Messages.Add("Brand Updated");
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
