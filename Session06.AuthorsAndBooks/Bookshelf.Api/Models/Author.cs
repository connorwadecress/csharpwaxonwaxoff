namespace Bookshelf.Api.Models
{
    public class Author
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        //collection of books
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
