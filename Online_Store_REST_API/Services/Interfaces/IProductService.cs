using Online_Store_REST_API.Data.DataTransferObjects;
using Online_Store_REST_API.Data.Request;
using Online_Store_REST_API.Data.Request.Product;
using Online_Store_REST_API.Data.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store_REST_API.Services.Interfaces
{
    public interface IProductService
    {
        GetResponse<ProductViewDto> CreateProduct(CreateProductRequest createProductRequest);
        GetResponse<ProductViewDto> UpdateProduct(long id,UpdateProductRequest updateProductRequest);
        GetResponse<ProductViewDto> GetProduct(GetRequest getRequest);
        FetchResponse<ProductViewDto> FetchProducts(FetchProductsRequest fetchProductsRequest);
        GetResponse<ProductViewDto> DeleteProduct(DeleteRequest deleteRequest);
    }
}
