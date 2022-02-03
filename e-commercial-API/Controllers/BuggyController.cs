using e_commercial_API.Errors;
using e_commercial_Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commercial_API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var item = _context.Products.Find(42);
            if(item == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();

        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var item = _context.Products.Find(42);
            var itemToReturn  = item.ToString();
            return Ok();
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }


    }
}
