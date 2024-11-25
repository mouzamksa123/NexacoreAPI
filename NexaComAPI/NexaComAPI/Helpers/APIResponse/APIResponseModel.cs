using System.Net;

namespace NexaComAPI.Helpers.APIResponse
{
    public class APIResponseModel
    {
        public APIResponseModel()
        {
            Errors = new List<string>();
        }
        public bool Status { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public dynamic Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
