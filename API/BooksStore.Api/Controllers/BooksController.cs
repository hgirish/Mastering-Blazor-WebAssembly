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
}
