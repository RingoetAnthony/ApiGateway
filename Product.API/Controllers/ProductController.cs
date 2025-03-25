using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.API.Models;
using System.Xml.Linq;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<ProductModel> _products = new List<ProductModel>
        {
            new ProductModel { Id = 1, Name = "john", Description = "test1"},
            new ProductModel { Id = 2, Name = "alice", Description = "test2"},
            new ProductModel { Id = 3, Name = "test", Description = "test3"}
        };


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ProductModel? product = _products.FirstOrDefault(o => o.Id == id);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductModel product)
        {
            product.Id = _products.Max(o => o.Id) + 1;
            _products.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ProductModel productUpdate)
        {
            ProductModel? productToUpdate = _products.FirstOrDefault(o => o.Id == id);
            if (productToUpdate is null)
            {
                return NotFound();
            }

            productToUpdate.Name = productUpdate.Name;
            productToUpdate.Description = productUpdate.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ProductModel? ProductModel = _products.FirstOrDefault(o => o.Id == id);
            if (ProductModel is null)
            {
                return NotFound();
            }

            _products.Remove(ProductModel);
            return NoContent();
        }
    }
}
