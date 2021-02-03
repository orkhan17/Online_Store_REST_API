using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Online_Store_REST_API.Data.Response
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Messages = new List<string>();
            Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public string Timestamp { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<string> Messages { get; set; }
    }
}
