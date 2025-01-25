using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using BookStore.BL.Interfaces;
using BookStore.Models.DTO;
using BookStore.Models.Requests;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        private readonly ILogger<BooksController> _logger;

        public BooksController(
            IBookService bookService,
            IMapper mapper, 
            ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _mapper = mapper;
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _bookService.GetAllBooks();

            if (result == null || result.Count == 0)
            {
                return NotFound("No books found");
            }

            return Ok(result);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id can't be null or empty");
            }

            var result = _bookService.GetById(id);

            if (result == null)
            {
                return NotFound($"Book with ID:{id} not found");
            }

            return Ok(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(AddBookRequest book)
        {
            try
            {
                var bookDto = _mapper.Map<Book>(book);

                if (bookDto == null)
                {
                    return BadRequest("Can't convert book to book DTO");
                }

                _bookService.AddBook(bookDto);

                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error adding book with");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than 0");
            }

            //_bookService.Delete(id);


            return Ok();
        }
    }
}
