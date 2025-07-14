using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using LawPavillion.Library.Backend.API.Dtos;
using LawPavillion.Library.Backend.API.Helpers;
using LawPavillion.Library.Backend.API.Interfaces.Services;


namespace LawPavillion.Library.Backend.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route(ApiRoute.Books)]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _booksService;

        // Inject the book service via constructor
        public BooksController(IBookService bookService)
        {
            _booksService = bookService;
        }

        /// <summary>
        /// Creates a new book and returns the created resource.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto dto)
        {
            var result = await _booksService.CreateAsync(dto);

            if (!result.IsSuccessful)
            {
                return BadRequest(new { message = ConstantMessages.InvalidData, data = result });
            }

            return Ok(result);
        }

        /// <summary>
        /// Retrieves all books from the library.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _booksService.GetAllAsync();
            if (!result.IsSuccessful)
            {
                return BadRequest(new { message = ConstantMessages.Failed, data = result });
            }

            return Ok(result);
        }

        /// <summary>
        /// Retrieves a specific book by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _booksService.GetByIdAsync(id);
            if (!result.IsSuccessful)
            {
                return BadRequest(new { message = ConstantMessages.BookNotFound, data = result });
            }

            return Ok(result);
        }

        /// <summary>
        /// Updates an existing book's details.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookDto dto)
        {
            var result = await _booksService.UpdateAsync(dto);

            if (!result.IsSuccessful)
            {
                return BadRequest(new { message = ConstantMessages.Failed, data = result });
            }

            return Ok(result);
        }

        /// <summary>  
        /// Deletes a book by its ID.  
        /// </summary>  
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _booksService.DeleteAsync(id);
            if (!result.IsSuccessful)
            {
                return BadRequest(new { message = ConstantMessages.Failed, data = result });
            }

            return Ok(result);
        }

        /// <summary>
        /// Searches for books by title or author.
        /// </summary>
        [HttpGet(ApiRoute.SearchBooks)]
        public async Task<IActionResult> Search([FromQuery] string q)
        {
            var result = await _booksService.SearchAsync(q);
            if (!result.IsSuccessful)
            {
                return BadRequest(new { message = ConstantMessages.SearchEmpty, data = result });
            }

            return Ok(result);
        }

        /// <summary>
        /// Paginates the list of books based on page number and size.
        /// </summary>
        [HttpGet(ApiRoute.PaginateBooks)]
        public async Task<IActionResult> Paginate([FromQuery] int page, [FromQuery] int size)
        {
            var result = await _booksService.PaginateAsync(page, size);

            if (!result.IsSuccessful)
            {
                return BadRequest(new { message = ConstantMessages.PaginationEmpty, data = result });
            }

            return Ok(result);
        }
    }
}
