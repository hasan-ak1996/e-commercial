namespace e_commercial_API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad request, you have made",
                401 => "Authorized , yor are not",
                404 => "Resource found, it was not",
                500 => "server error",
                _ => null
            };
        }
    }
}
