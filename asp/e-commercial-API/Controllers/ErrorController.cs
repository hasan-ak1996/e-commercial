using e_commercial_API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commercial_API.Controllers
{
    [Route("error/{code}")]
    // to ignore this controller fron swagger because not use this controller for client side
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorController : BaseApiController
    {
        public IActionResult error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
