using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new[] {"product 1", "product 2", "product 3"});
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Your product number : {id}");
        }
    }
}
