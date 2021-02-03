using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Store_REST_API.Data.Response
{
    public class GetResponse<T>: BaseResponse
    {
        public T Data { get; set; }
    }
}
