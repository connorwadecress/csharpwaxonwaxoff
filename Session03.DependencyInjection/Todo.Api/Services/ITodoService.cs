using Todo.Api.Models;

namespace Todo.Api.Services
{
    public interface ITodoService
    {
        IReadOnlyList<TodoItem> GetAll();
        TodoItem? GetById(int id);
        void Add(TodoItem todo);
        void Remove(TodoItem todo);
    }
}