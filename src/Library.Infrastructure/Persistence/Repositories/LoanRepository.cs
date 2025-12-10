using Library.Domain.Entities;
using Library.Domain.Ports.Out;

namespace Library.Infrastructure.Persistence
{
    public class LoanRepository : Repository<Loan>, ILoanRepository
    {
        public LoanRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
