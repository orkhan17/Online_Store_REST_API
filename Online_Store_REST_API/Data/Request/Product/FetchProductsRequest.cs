using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store_REST_API.Data.Request.Product
{
    public class FetchProductsRequest: FetchRequest
    {
        public string CategorySlug { get; set; }
        public string BrandSlug { get; set; }
    }
}
