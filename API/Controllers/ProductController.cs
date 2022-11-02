using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _service;
        public ProductController(IProductServices service)
        {
            _service = service;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var results = await _service.GetAllProducts();

            if(results == null) return BadRequest("Failed to retrieve products");
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id){
            Product? product = await _service.GetProductById(id);

            if(product == null) return BadRequest("Product not found");
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddNewProduct(Product product){
            int? id = await _service.AddNewProduct(product);

            if(id == null) return BadRequest("Product could not be added");

            return Ok(id);
        }

        [HttpPut("{id}/{quantity}")]
        public async Task<ActionResult> AdjustInventory(int id, int quantity){
            bool success = await _service.AdjustInventory(id, quantity);

            if(!success) return BadRequest("Operation not executed");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveItem(int id){
            bool success = await _service.RemoveProduct(id);

            if(!success) return BadRequest("Failed to remove Product");

            return Ok();
        }
    }
}