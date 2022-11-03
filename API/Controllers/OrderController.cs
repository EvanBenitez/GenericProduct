using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _service;
        public OrderController(IOrderServices service)
        {
            _service = service;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var results = await _service.GetAllOrders();

            if(results == null) return BadRequest("Failed to retrieve Orders");
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id){
            Order? order = await _service.GetOrderById(id);

            if(order == null) return BadRequest("Order not found");
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddNewOrder(Order order){
            int? id = await _service.AddNewOrder(order);

            if(id == null) return BadRequest("Order could not be added");

            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOrder(Order order){
            bool success = await _service.UpdateOrder(order);

            if(!success) return BadRequest("Operation not executed");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveItem(int id){
            bool success = await _service.RemoveOrder(id);

            if(!success) return BadRequest("Failed to remove Order");

            return Ok();
        }
    }
}