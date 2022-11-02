using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _service;
        public CustomerController(ICustomerServices service)
        {
            _service = service;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var results = await _service.GetAllCustomers();

            if(results == null) return BadRequest("Failed to retrieve Customers");
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id){
            Customer? customer = await _service.GetCustomerById(id);

            if(customer == null) return BadRequest("Customer not found");
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddNewCustomer(Customer customer){
            int? id = await _service.AddNewCustomer(customer);

            if(id == null) return BadRequest("Customer could not be added");

            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(Customer customer){
            bool success = await _service.UpdateCustomer(customer);

            if(!success) return BadRequest("Operation not executed");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveItem(int id){
            bool success = await _service.RemoveCustomer(id);

            if(!success) return BadRequest("Failed to remove Customer");

            return Ok();
        }
    }
}