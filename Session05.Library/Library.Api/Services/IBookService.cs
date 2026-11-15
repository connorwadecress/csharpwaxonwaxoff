using Library.Api.Models;

namespace Library.Api.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> ListBooksAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book> CreateBookAsync(CreateBookRequest createBookRequest);
        Task<Book?> UpdateBookAsync(int id, UpdateBookRequest updateBookRequest);
        Task<bool> DeleteBookAsync(int id);

    }
}
