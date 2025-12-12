using Library.Application.DTOs;
using Library.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class LoansController : ControllerBase
{
    private readonly ILoanService _loanService;

    public LoansController(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var loans = await _loanService.GetAllAsync();
        return Ok(loans);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLoanDto dto)
    {
        var result = await _loanService.CreateLoanAsync(dto);
        return Ok(result);
    }

    [HttpPut("{id}/return")]
    public async Task<IActionResult> Return(int id)
    {
        var result = await _loanService.ReturnLoanAsync(id);
        return Ok(result);
    }
}

}
