using Library.Application.DTOs;
using Library.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
   [ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookDto dto)
    {
        var book = await _bookService.CreateAsync(dto);
        return Ok(book);
    }
}

}
