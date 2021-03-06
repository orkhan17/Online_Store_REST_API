﻿using Online_Store_REST_API.EntityModels.Shared;

namespace Online_Store_REST_API.EntityModels.Products
{
    public class Brand : BaseModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public BrandStatus BrandStatus { get; set; }
    }
}
