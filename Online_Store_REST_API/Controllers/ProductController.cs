using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Store_REST_API.Data.DataTransferObjects;
using Online_Store_REST_API.Data.Request;
using Online_Store_REST_API.Data.Request.Product;
using Online_Store_REST_API.Data.Response;
using Online_Store_REST_API.Services.Interfaces;

namespace Online_Store_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public ActionResult<GetResponse<ProductViewDto>> GetProduct(long id)
        {
            var request = new GetRequest
            {
                Id = id
            };
            var response = _productService.GetProduct(request);
            return response;
        }

        [HttpGet()]
        public ActionResult<FetchResponse<ProductViewDto>> FetchProducts()
        {
            var request = new FetchProductsRequest { };
            var response = _productService.FetchProducts(request);
            return response;
        }

        [HttpPost()]
        public ActionResult<GetResponse<ProductViewDto>> PostBrand(CreateProductRequest createProductRequest)
        {
            var response = _productService.CreateProduct(createProductRequest);
            return response;
        }

        [HttpPut("{id}")]
        public ActionResult<GetResponse<ProductViewDto>> PutProduct(long id, UpdateProductRequest updateProductRequest)
        {
            var response = _productService.UpdateProduct(id, updateProductRequest);
            return response;
        }

        [HttpDelete("{id}")]
        public ActionResult<GetResponse<ProductViewDto>> DeleteProduct(long id)
        {
            var request = new DeleteRequest
            {
                Id = id
            };

            var response = _productService.DeleteProduct(request);
            return response;
        }
    }
}