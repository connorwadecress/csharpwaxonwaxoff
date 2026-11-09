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

        [HttpPost]
        public IActionResult Create(CreateToDoItemRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return BadRequest("Title is required.");
            }

            var todo = new TodoItem
            {
                //Id = _todos.Count + 1,
                Id = _todos.Count == 0 ? 1 : _todos.Max(item => item.Id) + 1,
                Title = request.Title
            };

            _todos.Add(todo);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, UpdateToDoRequest request)
        {
            var existingTodo = _todos.FirstOrDefault(item => item.Id == id);

            if (existingTodo is null)
            {
                return NotFound();
            }
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return BadRequest("Title is required.");
            }

            existingTodo.Title = request.Title;
            existingTodo.IsCompleted = request.IsCompleted;

            return Ok(existingTodo);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var existingTodo = _todos.FirstOrDefault(item => item.Id == id);
            if (existingTodo is null)
            {
                return NotFound();
            }
            _todos.Remove(existingTodo);
            return NoContent();
        }

    }
}
