using Library.Domain.Ports.Out;
using Library.Infrastructure.Persistence.Context;

namespace Library.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBookRepository Books { get; }
        public ILoanRepository Loans { get; }

        public UnitOfWork(
            ApplicationDbContext context,
            IBookRepository books,
            ILoanRepository loans)
        {
            _context = context;
            Books = books;
            Loans = loans;
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
