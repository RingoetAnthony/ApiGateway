using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.API.Models;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private static List<OrderModel> _orders = new List<OrderModel>
        {
            new OrderModel { Id = 1, CustomerName = "john", Price = 2},
            new OrderModel { Id = 2, CustomerName = "alice", Price = 3},
            new OrderModel { Id = 3, CustomerName = "test", Price = 4}
        };


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            OrderModel? order = _orders.FirstOrDefault(o => o.Id == id);
            if (order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderModel order)
        {
            order.Id = _orders.Max(o => o.Id) + 1;
            _orders.Add(order);
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] OrderModel orderUpdate)
        {
            OrderModel? orderToUpdate = _orders.FirstOrDefault(o => o.Id == id);
            if(orderToUpdate is null)
            {
                return NotFound();
            }

            orderToUpdate.CustomerName = orderUpdate.CustomerName;
            orderToUpdate.Price = orderUpdate.Price;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            OrderModel? orderModel = _orders.FirstOrDefault(o => o.Id == id);
            if (orderModel is null)
            {
                return NotFound();
            }

            _orders.Remove(orderModel);
            return NoContent();
        }
    }
}
