using Bookshelf.Api.Contracts;
using Bookshelf.Api.Models;

namespace Bookshelf.Api.Services
{
    public interface IAuthorService
    {
        Task<AuthorResponse> CreateAuthorAsync(AuthorCreateRequest request);
        Task<bool> DeleteAuthorAsync(int id);
        Task<IEnumerable<AuthorResponse>> GetAuthorsAsync();
        Task<AuthorResponse?> GetAuthorByIdAsync(int id);
        Task<AuthorResponse?> UpdateAuthorAsync(int  id, AuthorUpdateRequest request);
        Task<bool> AuthorExistsAsync(int id);
    }
}
