using Todo.Api.Models;

namespace Todo.Api.Services
{
    public class InMemoryTodoService : ITodoService
    {
        private readonly List<TodoItem> _todos = new List<TodoItem>
        {
            new TodoItem { Id = 1, Title = "Buy groceries"},
            new TodoItem { Id = 2, Title = "Clean the house"},
        };

        public IReadOnlyList<TodoItem> GetAll()
        {
            return _todos.AsReadOnly();
        }

        public TodoItem? GetById(int id)
        {
            return _todos.FirstOrDefault(item => item.Id == id);
        }

        public void Add(TodoItem todo)
        {
            _todos.Add(todo);
        }

        public void Remove(TodoItem todo)
        {
            _todos.Remove(todo);
        }
    }
}
