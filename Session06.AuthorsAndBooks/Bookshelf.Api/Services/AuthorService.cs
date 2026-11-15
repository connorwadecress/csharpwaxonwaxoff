using Bookshelf.Api.Contracts;
using Bookshelf.Api.Data;
using Bookshelf.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Api.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _dbContext;

        public AuthorService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        } 

        public async Task<IEnumerable<AuthorResponse>> GetAuthorsAsync()
        {
            return await _dbContext.Authors
                .Select(author => new AuthorResponse
                {
                    Id = author.Id,
                    Name = author.Name,
                    BookCount = author.Books.Count
                })
                .ToListAsync();
        }

        public async Task<AuthorResponse?> GetAuthorByIdAsync(int id) => (await _dbContext.Authors
            .Where(a => a.Id == id)
            .Select(author => new AuthorResponse
            {
                Id = author.Id,
                Name = author.Name,
                BookCount = author.Books.Count
            }).FirstOrDefaultAsync());

        public async Task<AuthorResponse> CreateAuthorAsync(AuthorCreateRequest request)
        {
            var author = new Author
            {
                Name = request.Name
            };

            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
            return new AuthorResponse
            {
                Id = author.Id,
                Name = author.Name,
                BookCount = 0 // brand new author so no books
            };
        }

        public async Task<AuthorResponse?> UpdateAuthorAsync(int id, AuthorUpdateRequest request)
        {
            var author = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author == null)
            {
                return null;
            }
            author.Name = request.Name;
            await _dbContext.SaveChangesAsync();
            return await GetAuthorByIdAsync(id);
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author == null)
            {
                return false;
            }
            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AuthorExistsAsync(int id) =>
            await _dbContext.Authors.AnyAsync(a => a.Id == id);
    }
}
