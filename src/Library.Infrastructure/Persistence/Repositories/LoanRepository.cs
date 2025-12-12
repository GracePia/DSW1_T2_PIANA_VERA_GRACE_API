using Library.Domain.Entities;
using Library.Domain.Ports.Out;
using Library.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Loan entity)
        {
            await _context.Loans.AddAsync(entity);
        }

        public void Update(Loan entity)
        {
            _context.Loans.Update(entity);
        }

        public void Delete(Loan entity)  // ⚠️ Implementar Delete
        {
            _context.Loans.Remove(entity);
        }

        public async Task<Loan?> GetByIdAsync(int id)  // ⚠️ Ajuste de nulabilidad
        {
            return await _context.Loans
                                 .Include(l => l.Book)
                                 .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Loan>> GetAllAsync()
        {
            return await _context.Loans
                                 .Include(l => l.Book)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Loan>> GetActiveLoansAsync()
        {
            return await _context.Loans
                                 .Include(l => l.Book)
                                 .Where(l => l.Status == "Active")
                                 .ToListAsync();
        }
    }
}
