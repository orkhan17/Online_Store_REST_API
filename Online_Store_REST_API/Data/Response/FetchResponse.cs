using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store_REST_API.Data.Response
{
    public class FetchResponse<T> : BaseResponse
    {
        public int BrandsPerPage { get; set; }
        public bool HasPreviousPages { get; set; }
        public bool HasNextPages { get; set; }
        public int CurrentPage { get; set; }
        public int[] Pages { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
