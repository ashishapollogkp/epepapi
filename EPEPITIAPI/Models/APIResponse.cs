using System.Net;

namespace EPEPITIAPI.Models
{
    public class APIResponse
    {
       
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;      
        public object Result { get; set; }
        public string ActionResponse { get; set; }
    }
}
