using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Store_REST_API.Data.DataTransferObjects;
using Online_Store_REST_API.Data.Request;
using Online_Store_REST_API.Data.Request.Brand;
using Online_Store_REST_API.Data.Response;
using Online_Store_REST_API.Services.Interfaces;

namespace Online_Store_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("{id}")]
        public ActionResult<GetResponse<BrandViewDto>> GetBrand(long id)
        {
            var request = new GetRequest
            {
                Id = id
            };
            var response = _brandService.GetBrand(request);
            return response;
        }

        [HttpGet()]
        public ActionResult<FetchResponse<BrandViewDto>> FetchBrands()
        {
            var request = new FetchRequest { };
            var response = _brandService.FetchBrands(request);
            return response;
        }

        [HttpPost()]
        public ActionResult<GetResponse<BrandViewDto>> PostBrand(CreateBrandRequest createBrandRequest)
        {
            var response = _brandService.CreateBrand(createBrandRequest);
            return response;
        }

        [HttpPut("{id}")]
        public ActionResult<GetResponse<BrandViewDto>> PutBrand(long id, UpdateBrandRequest updateBrandRequest)
        {
            var response = _brandService.UpdateBrand(id, updateBrandRequest);
            return response;
        }

        [HttpDelete("{id}")]
        public ActionResult<GetResponse<BrandViewDto>> DeleteBrand(long id)
        {
            var request = new DeleteRequest
            {
                Id = id
            };

            var response = _brandService.DeleteBrand(request);
            return response;
        }
    }
}