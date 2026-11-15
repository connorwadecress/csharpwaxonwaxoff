namespace Bookshelf.Api.Contracts
{
    public class BookResponse
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string ISBN { get; set; }
        public required int PublishedYear { get; set; }
        public int AuthorId { get; set; }
        public required string AuthorName { get; set; }
    }
}
