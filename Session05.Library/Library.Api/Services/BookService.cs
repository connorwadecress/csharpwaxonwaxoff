using Library.Api.Data;
using Library.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Api.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> ListBooksAsync() => await _context.Books.ToListAsync();

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> CreateBookAsync(CreateBookRequest createBookRequest)
        {
            var book = new Book
            {
                Title = createBookRequest.Title,
                Author = createBookRequest.Author,
                ISBN = createBookRequest.ISBN,
                PublishedYear = createBookRequest.PublishedYear
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> UpdateBookAsync(int id, UpdateBookRequest updateBookRequest)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
            {
                return null;
            }
            existingBook.Title = updateBookRequest.Title;
            existingBook.Author = updateBookRequest.Author;
            existingBook.ISBN = updateBookRequest.ISBN;
            existingBook.PublishedYear = updateBookRequest.PublishedYear;

            await _context.SaveChangesAsync();
            return existingBook;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return false;
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
