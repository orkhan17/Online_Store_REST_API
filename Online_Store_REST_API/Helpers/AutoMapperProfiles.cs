using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Online_Store_REST_API.Data.DataTransferObjects;
using Online_Store_REST_API.Data.Request.Brand;
using Online_Store_REST_API.Data.Request.Category;
using Online_Store_REST_API.Data.Request.Product;
using Online_Store_REST_API.EntityModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store_REST_API.EntityModels
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateBrandRequest, Brand>();
            CreateMap<Brand, BrandViewDto>();
            CreateMap<UpdateBrandRequest, Brand>();

            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<Category, CategoryViewDto>();
            CreateMap<UpdateCategoryRequest, Category>();

            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductViewDto>();
            CreateMap<UpdateProductRequest, Product>();
        }
    }
}
