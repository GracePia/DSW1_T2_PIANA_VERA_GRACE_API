namespace Library.Domain.Ports.Out
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        ILoanRepository Loans { get; }

        Task<int> SaveChangesAsync();
    }
}
