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

        [HttpPost]
        public IActionResult Create(CreateTodoRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return BadRequest("Title must not be blank.");
            }

            var todo = new TodoItem
            {
                Id = _todos.Count == 0 ? 1 : _todos.Max(item => item.Id) + 1,
                Title = request.Title.Trim()
            };

            _todos.Add(todo);

            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, UpdateTodoRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return BadRequest("Title must not be blank.");
            }

            var todo = _todos.FirstOrDefault(item => item.Id == id);

            if (todo is null)
            {
                return NotFound();
            }

            todo.Title = request.Title.Trim();
            todo.IsCompleted = request.IsCompleted;

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var todo = _todos.FirstOrDefault(item => item.Id == id);

            if (todo is null)
            {
                return NotFound();
            }

            _todos.Remove(todo);
            return NoContent();
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
