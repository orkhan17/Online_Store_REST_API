using AutoMapper;
using Online_Store_REST_API.Data.DataTransferObjects;
using Online_Store_REST_API.Data.Request;
using Online_Store_REST_API.Data.Request.Product;
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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public GetResponse<ProductViewDto> CreateProduct(CreateProductRequest createProductRequest)
        {
            var response = new GetResponse<ProductViewDto>();
            try
            {
                var product = _mapper.Map<Product>(createProductRequest);
                _productRepository.AddProduct(product);
                bool result = _productRepository.SaveAll();
                if(result)
                {
                    response.Data = _mapper.Map<ProductViewDto>(product);
                    response.Messages.Add("Successfully created new product");
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

        public GetResponse<ProductViewDto> DeleteProduct(DeleteRequest deleteRequest)
        {
            var response = new GetResponse<ProductViewDto>();
            try
            {
                var product = _productRepository.FindProductById(deleteRequest.Id);
                if(product == null)
                {
                    response.Messages.Add("Not found product");
                    response.StatusCode = HttpStatusCode.NotFound;
                    return response;
                }
                _productRepository.DeleteProduct(deleteRequest.Id);
                bool result = _productRepository.SaveAll();
                if(result)
                {
                    response.Data = _mapper.Map<ProductViewDto>(product);
                    response.Messages.Add("Product is deleted");
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

        public FetchResponse<ProductViewDto> FetchProducts(FetchProductsRequest fetchProductsRequest)
        {
            var response = new FetchResponse<ProductViewDto>();
            try
            {
                var products = _productRepository.GetAllProducts();
                response.Data = _mapper.Map<IEnumerable<ProductViewDto>>(products);
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

        public GetResponse<ProductViewDto> GetProduct(GetRequest getRequest)
        {
            var response = new GetResponse<ProductViewDto>();
            try
            {
                var product = _productRepository.FindProductById(getRequest.Id);
                if (product == null)
                {
                    response.Messages.Add("Not found product");
                    response.StatusCode = HttpStatusCode.NotFound;
                    return response;
                }

                response.Data = _mapper.Map<ProductViewDto>(product);
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

        public GetResponse<ProductViewDto> UpdateProduct(long id, UpdateProductRequest updateProductRequest)
        {
            var response = new GetResponse<ProductViewDto>();
            try
            {
                var product = _productRepository.FindProductById(id);
                if(product == null)
                {
                    response.Messages.Add("Not found product");
                    response.StatusCode = HttpStatusCode.NotFound;
                    return response;
                }
                _mapper.Map(updateProductRequest, product);
                _productRepository.UpdateProduct(product);

                bool result = _productRepository.SaveAll();

                if(result)
                {
                    response.Data = _mapper.Map<ProductViewDto>(product);
                    response.Messages.Add("Product is updated");
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
