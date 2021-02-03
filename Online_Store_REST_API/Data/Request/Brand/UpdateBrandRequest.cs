using Online_Store_REST_API.Data.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store_REST_API.Data.Request.Brand
{
    public class UpdateBrandRequest
    {
        public UpdateBrandRequest()
        {
            ModifiedDate = DateTime.Now;
        }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public DateTime ModifiedDate { get; private set; }

    }
}
