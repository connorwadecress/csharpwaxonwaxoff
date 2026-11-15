using Bookshelf.Api.Models;
using Bookshelf.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookshelf.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public BookController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request)
        {
            if (!await _authorService.AuthorExistsAsync(request.AuthorId))
            {
                return BadRequest($"Author with ID {request.AuthorId} does not exist.");
            }
            var book = await _bookService.CreateBookAsync(request);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookRequest request)
        {
            if(!await _authorService.AuthorExistsAsync(request.AuthorId))
            {
                return BadRequest($"Author with ID {request.AuthorId} does not exist.");
            }   

            var updatedBook = await _bookService.UpdateBookAsync(id, request);
            if (updatedBook == null)
            {
                return NotFound();
            }
            return Ok(updatedBook);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var isDeleted = await _bookService.DeleteBookAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
