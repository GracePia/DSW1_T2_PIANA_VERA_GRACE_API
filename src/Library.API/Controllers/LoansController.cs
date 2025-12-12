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
            try
            {
                var loans = await _loanService.GetAllAsync(); // Incluye los datos del libro
                return Ok(loans);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los préstamos", details = ex.Message });
            }
        }

        // GET: api/loans/active
        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            try
            {
                var loans = await _loanService.GetActiveLoansAsync();
                return Ok(loans);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los préstamos activos", details = ex.Message });
            }
        }

        // POST: api/loans
        [HttpPost]
        public async Task<IActionResult> Create(CreateLoanDto dto)
        {

            if (dto.Status != null && dto.Status != "Active" && dto.Status != "Returned")
            {
                return BadRequest(new { message = "Status debe ser 'Active' o 'Returned'" });
            }


            if (string.IsNullOrEmpty(dto.Status))
            {
                dto.Status = "Active";
            }

            try
            {
                var loan = await _loanService.CreateLoanAsync(dto);
                return Ok(loan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear el préstamo", details = ex.Message });
            }
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
            try
            {
                var deleted = await _loanService.DeleteAsync(id);
                if (!deleted)
                    return NotFound(new { message = "Préstamo no encontrado" });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar el préstamo", details = ex.Message });
            }
        }
    }
}
