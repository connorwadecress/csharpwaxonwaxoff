using Bookshelf.Api.Contracts;
using Bookshelf.Api.Models;

namespace Bookshelf.Api.Services
{
    public interface IBookService
    {
        Task<BookResponse> CreateBookAsync(CreateBookRequest request);
        Task<bool> DeleteBookAsync(int id);
        Task<IEnumerable<BookResponse>> GetBooksAsync();
        Task<BookResponse?> GetBookByIdAsync(int id);
        Task<BookResponse?> UpdateBookAsync(int id, UpdateBookRequest request);
        Task<IEnumerable<BookResponse>?> GetBooksByAuthorIdAsync(int id);

    }
}
