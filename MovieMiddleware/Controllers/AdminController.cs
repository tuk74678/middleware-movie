using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieMiddleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return Ok(new[] { "Inception", "Matrix" });
        }
        [HttpGet("throw")]
        public IActionResult ThrowException()
        {
            throw new Exception("Test exception!");
        }
    }
}
