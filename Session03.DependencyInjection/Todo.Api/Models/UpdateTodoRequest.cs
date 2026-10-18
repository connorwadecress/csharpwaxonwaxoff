namespace Todo.Api.Models
{
    public class UpdateTodoRequest
    {
        public required string Title { get; init; }
        public required bool IsCompleted { get; init; }
    }
}
