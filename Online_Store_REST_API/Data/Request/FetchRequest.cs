using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store_REST_API.Data.Request
{
    public class FetchRequest
    {
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
