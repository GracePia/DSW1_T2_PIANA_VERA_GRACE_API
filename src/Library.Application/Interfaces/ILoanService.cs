using Library.Application.DTOs;

namespace Library.Application.Interfaces.Services
{
    public interface ILoanService
    {
        Task<LoanDto> CreateLoanAsync(CreateLoanDto dto);
        Task<IEnumerable<LoanDto>> GetAllAsync();
        Task<IEnumerable<LoanDto>> GetActiveLoansAsync();
        Task<LoanDto> ReturnLoanAsync(int loanId);
        Task<bool> DeleteAsync(int loanId);
    }
}
