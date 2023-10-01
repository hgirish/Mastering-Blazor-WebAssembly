using BooksStore.Api.Models;
using BooksStore.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : Controller
{
    private readonly BooksService _booksService;

    public BooksController(BooksService booksService)
    {
        _booksService = booksService;
    }
    [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
    [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _booksService.GetAllBooksAsync();
        return Ok(result.ToArray());
    }
   // [Authorize(Roles ="Admin")]
    [ProducesResponseType(200, Type=typeof(Book))]
    [ProducesResponseType(400, Type=typeof(ApiErrorResponse))]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddBookRequest model)
    {
        var book = await _booksService.AddBookAsync(model);
        return Ok(book);
    }
    [ProducesResponseType(200, Type = typeof(Book))]
    [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        // Validate the model 
        var result = await _booksService.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]    
    [HttpPost("review/{bookId}")]
    public async Task<IActionResult> AddReview(string bookId, [FromBody] AddBookReviewRequest model)
    {
        // Validate the model 
        await _booksService.AddReviewAsync(bookId, model);
        return Ok();
    }

    [ProducesResponseType(200)]
    [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
    [HttpPost("{bookId}/cover")]
    public async Task<IActionResult> UploadCover(string bookId, [FromForm] IFormFile file)
    {
        // Validate the model 
        await _booksService.SetCoverAsync(bookId, file);
        return Ok();
    }
}
