using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _service;
        public CategoryController(ICategoryServices service)
        {
            _service = service;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategorys()
        {
            var results = await _service.GetAllCategorys();

            if(results == null) return BadRequest("Failed to retrieve Categorys");
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id){
            Category? category = await _service.GetCategoryById(id);

            if(category == null) return BadRequest("Category not found");
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddNewCategory(Category category){
            int? id = await _service.AddNewCategory(category);

            if(id == null) return BadRequest("Category could not be added");

            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategory(Category category){
            bool success = await _service.UpdateCategory(category);

            if(!success) return BadRequest("Operation not executed");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveItem(int id){
            bool success = await _service.RemoveCategory(id);

            if(!success) return BadRequest("Failed to remove Category");

            return Ok();
        }
    }
}