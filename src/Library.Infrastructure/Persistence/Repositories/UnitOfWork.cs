using Library.Domain.Ports.Out;

namespace Library.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBookRepository Books { get; }
        public ILoanRepository Loans { get; }

        public UnitOfWork(ApplicationDbContext context,
            IBookRepository bookRepository,
            ILoanRepository loanRepository)
        {
            _context = context;
            Books = bookRepository;
            Loans = loanRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
