namespace Bookshelf.Api.Contracts
{
    public class AuthorResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int BookCount { get; set; }
    }
}
