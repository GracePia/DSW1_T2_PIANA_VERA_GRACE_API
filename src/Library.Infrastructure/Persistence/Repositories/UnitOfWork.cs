using Library.Domain.Ports.Out;
using Library.Infrastructure.Persistence.Context;

namespace Library.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBookRepository Books { get; }
        public ILoanRepository Loans { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Books = new BookRepository(_context);
            Loans = new LoanRepository(_context);
        }

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
