using Online_Store_REST_API.EntityModels.Shared;

namespace Online_Store_REST_API.EntityModels.Products
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string SKU { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public decimal OldPrice { get; set; }
        public string ImageUrl { get; set; }
        public int QuantityInStock { get; set; }
        public bool IsBestSeller { get; set; }
        public bool IsFeatured { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public long BrandId { get; set; }
        public Brand Brand { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }
}
