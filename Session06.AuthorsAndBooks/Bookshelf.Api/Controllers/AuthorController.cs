using Bookshelf.Api.Models;
using Bookshelf.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookshelf.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public AuthorController(IAuthorService authorService, IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorService.GetAuthorsAsync();
            return Ok(authors);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpGet("{id:int}/books")]
        public async Task<IActionResult> GetBooksByAuthorId(int id)
        {
            var books = await _bookService.GetBooksByAuthorIdAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorCreateRequest request)
        {
            var author = await _authorService.CreateAuthorAsync(request);
            return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorUpdateRequest request)
        {
            var updatedAuthor = await _authorService.UpdateAuthorAsync(id, request);
            if (updatedAuthor == null)
            {
                return NotFound();
            }
            return Ok(updatedAuthor);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var deleted = await _authorService.DeleteAuthorAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
