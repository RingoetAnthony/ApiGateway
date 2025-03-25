using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new[] {"command 1", "command 2", "command 3"});
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Your command is : {id}");
        }

        [HttpGet("post/{id}")]
        public IActionResult Post(int id)
        {
            return Ok ($"Your Order {id} was confirmed");
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Your Order {id} was deleted");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Put(int id)
        {
            return Ok($"Your Order {id} was modified");
        }
    }
}
