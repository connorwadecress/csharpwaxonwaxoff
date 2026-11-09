namespace Todo.Api.Models
{
    public class UpdateToDoRequest
    {
        public required string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
