namespace Bookshelf.Api.Models
{
    public class CreateBookRequest
    {
        public required string Title { get; set; }
        public required int AuthorId { get; set; }
        public required string ISBN { get; set; }
        public required int PublishedYear { get; set; }
    }
}
