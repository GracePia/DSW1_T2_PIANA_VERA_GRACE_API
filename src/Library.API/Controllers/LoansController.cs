using Library.Application.DTOs;
using Library.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("active")]
    public async Task<IActionResult> GetActive()
    {
        var loans = await _loanService.GetActiveLoansAsync();
        return Ok(loans);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLoanDto dto)
    {
        var loan = await _loanService.CreateLoanAsync(dto);
        return Ok(loan);
    }

    [HttpPut("{id}/return")]
    public async Task<IActionResult> Return(int id)
    {
        var loan = await _loanService.ReturnLoanAsync(id);
        return Ok(loan);
    }
}


