using Library.Domain.Entities;
using Library.Domain.Ports.Out;

namespace Library.Infrastructure.Persistence
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
