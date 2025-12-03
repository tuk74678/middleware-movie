using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieMiddleware.Filters;
using MovieMiddleware.Models;

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
        
        [HttpPost("CreateMovie")]
        [ServiceFilter(typeof(LogFilter))]
        public IActionResult CreateMovie([FromBody] MovieModel model)
        {
            return Ok(model);
        }
        
        [HttpPost("PurchaseMovie")]
        public IActionResult PurchaseMovie([FromBody] PurchaseMovieModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Simulate movie purchase
            return Ok(new { Message = "Movie purchased successfully", Purchase = model });
        }
    }
}
