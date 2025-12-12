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

        // GET: api/loans
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var loans = await _loanService.GetAllAsync();
            return Ok(loans);
        }

        // GET: api/loans/active
        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var loans = await _loanService.GetActiveLoansAsync();
            return Ok(loans);
        }

        // POST: api/loans
        [HttpPost]
        public async Task<IActionResult> Create(CreateLoanDto dto)
        {
            // Validación de Status
            if (dto.Status != null && dto.Status != "Active" && dto.Status != "Returned")
            {
                return BadRequest(new { message = "Status debe ser 'Active' o 'Returned'" });
            }

            // Si Status es null o vacío, asignamos "Active" por defecto
            if (string.IsNullOrEmpty(dto.Status))
            {
                dto.Status = "Active";
            }

            var loan = await _loanService.CreateLoanAsync(dto);
            return Ok(loan);
        }

        // PUT: api/loans/return/{id}
        [HttpPut("return/{id}")]
        public async Task<IActionResult> ReturnLoan(int id)
        {
            try
            {
                var loan = await _loanService.ReturnLoanAsync(id);
                return Ok(loan);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/loans/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _loanService.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { message = "Préstamo no encontrado" });

            return NoContent();
        }
    }
}
