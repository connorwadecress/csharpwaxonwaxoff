using Bookshelf.Api.Contracts;
using Bookshelf.Api.Data;
using Bookshelf.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Api.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _dbContext;
        private readonly IAuthorService _authorService;

        public BookService(AppDbContext dbContext, IAuthorService authorService)
        {
            _dbContext = dbContext;
            _authorService = authorService;
        }

        public async Task<IEnumerable<BookResponse>> GetBooksAsync() =>
            await _dbContext.Books
                .Select(b => new BookResponse
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    PublishedYear = b.PublishedYear,
                    AuthorId = b.AuthorId,
                    AuthorName = b.Author.Name
                })
                .ToListAsync();

        public async Task<BookResponse?> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books
                .Where(b => b.Id == id)
                .Select(b => new BookResponse
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    PublishedYear = b.PublishedYear,
                    AuthorId = b.AuthorId,
                    AuthorName = b.Author.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BookResponse>?> GetBooksByAuthorIdAsync(int id)
        {
            if (!await _authorService.AuthorExistsAsync(id))
            {
                return null;
            }

            var books = await _dbContext.Books.Where(b => b.AuthorId == id).ToListAsync();
            return books.Select(b => new BookResponse
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                PublishedYear = b.PublishedYear,
                AuthorId = b.AuthorId,
                AuthorName = b.Author.Name
            });
        }

        public async Task<BookResponse> CreateBookAsync(CreateBookRequest request)
        {
            var book = new Book
            {
                Title = request.Title,
                AuthorId = request.AuthorId,
                ISBN = request.ISBN,
                PublishedYear = request.PublishedYear,
            };
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return await GetBookByIdAsync(book.Id)!;
        }

        public async Task<BookResponse?> UpdateBookAsync(int id, UpdateBookRequest request)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null)
            {
                return null;
            }

            book.Title = request.Title;
            book.AuthorId = request.AuthorId;
            book.ISBN = request.ISBN;
            book.PublishedYear = request.PublishedYear;

            await _dbContext.SaveChangesAsync();
            return await GetBookByIdAsync(id);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null)
            {
                return false;
            }

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
