using Microsoft.AspNetCore.Mvc;
using BookStore.BL.Interfaces;
using BookStore.Models.DTO;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IBookBlService _bookService;
        private readonly IAuthorService _authorService;

        public BusinessController(IBookBlService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAllBookWithDetails")]
        public IActionResult GetAllBookWithDetails()
        {
            var result = _bookService.GetDetailedBooks();

            if (result == null || result.Count == 0)
            {
                return NotFound("No books found");
            }

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("AddAuthor")]
        public IActionResult AddAuthor([FromBody] Author author)
        {
            _authorService.Add(author);

            return Ok();
        }

    }
}
