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
    }
}
