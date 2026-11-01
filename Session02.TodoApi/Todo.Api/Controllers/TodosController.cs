using Microsoft.AspNetCore.Mvc;
using Todo.Api.Models;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("todos")]
    public class TodosController : ControllerBase
    {
        private static readonly List<TodoItem> _todos = new List<TodoItem>
        {
            new TodoItem { Id = 1, Title = "Buy groceries"},
            new TodoItem { Id = 2, Title = "Clean the house"},
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_todos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var todo = _todos.FirstOrDefault(item => item.Id == id);

            if (todo is null)
            {
                return NotFound();
            }

            return Ok(todo);
        }
    }
}
