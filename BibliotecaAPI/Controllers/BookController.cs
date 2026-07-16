using BibliotecaAPI.Dto;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if(book == null)
            {
                return BadRequest($"Book with id {id} not found.");
            }
            return Ok(book);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync(CreateBookDto createBookDto)
        {
            var book = await _bookService.CreateAsync(createBookDto);
            return Ok(book);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(int id, CreateBookDto createBookDto)
        {
            var book = await _bookService.UpdateAsync(id, createBookDto);
            if (book == null)
            {
                return BadRequest($"Book with id {id} not found.");
            }
            return Ok(book);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _bookService.DeleteAsync(id);
            if (!deleted)
            {
                return BadRequest($"Book with id {id} not found.");
            }
            return Ok($"Book with id {id} deleted successfully.");
        }
    }
}
