using BookStoreAPI.Models;
using BookStoreAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController (IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks ()
        {
            var data = await this._bookRepository.GetAllBooksAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]int id)
        {
            var data = await this._bookRepository.GetBookByIdAsync(id);

            if (data == null) return NotFound();

            return Ok(data);
        }

        [HttpPost("")] 
        public async Task<IActionResult> AddBook ([FromBody]BookModel book)
        {
            var data = await _bookRepository.AddBookAsync(book);

            return CreatedAtAction(nameof(GetBookById), new { id = data, controller = "books" }, data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id,[FromBody] BookModel book)
        {
            await this._bookRepository.UpdateBookAsync(id, book);
            return Ok();    
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromRoute] int id, [FromBody] JsonPatchDocument book)
        {
            await this._bookRepository.UpdateBookPatchAsync(id, book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute]int id)
        {
            await this._bookRepository.DeleteBookAsync(id);
            return Ok();
        }
    }
}
