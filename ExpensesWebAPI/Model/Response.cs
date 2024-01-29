using System.Net;

namespace ExpensesWebAPI.Model
{
    public class Response
    {
        public Response()
        {
            ErrorMessage = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessage { get; set; }
        public object Result { get; set; }
    }
}

