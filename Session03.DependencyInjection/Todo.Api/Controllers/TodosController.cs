using Microsoft.AspNetCore.Mvc;
using Todo.Api.Models;
using Todo.Api.Services;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("todos")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        
        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_todoService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var todo = _todoService.GetById(id);

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
                Id = _todoService.GetAll().Count == 0 ? 1 : _todoService.GetAll().Max(item => item.Id) + 1,
                Title = request.Title
            };

            _todoService.Add(todo);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, UpdateToDoRequest request)
        {
            var existingTodo = _todoService.GetById(id);

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
            var existingTodo = _todoService.GetById(id);
            if (existingTodo is null)
            {
                return NotFound();
            }
            _todoService.Remove(existingTodo);
            return NoContent();
        }

    }
}
