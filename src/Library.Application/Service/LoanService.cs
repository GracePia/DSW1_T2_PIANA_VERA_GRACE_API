using System.ComponentModel;
using AutoMapper;
using Library.Application.DTOs;
using Library.Application.Interfaces.Services;
using Library.Domain.Entities;
using Library.Domain.Exceptions;
using Library.Domain.Ports.Out;

namespace Library.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public LoanService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<LoanDto> CreateLoanAsync(CreateLoanDto dto)
        {
            var book = await _uow.Books.GetByIdAsync(dto.BookId);
            if (book == null)
                throw new NotFoundException($"Libro con Id {dto.BookId} no existe.");

            if (book.Stock <= 0)
                throw new BusinessException("El libro no tiene stock disponible.");

            book.Stock--;

            var loan = new Loan
            {
                BookId = dto.BookId,
                StudentName = dto.StudentName,
                LoanDate = DateTime.Now,
                Status = "Active",
                CreatedAt = DateTime.Now
            };

            await _uow.Loans.AddAsync(loan);
            await _uow.SaveChangesAsync();

            return _mapper.Map<LoanDto>(loan);
        }

        public async Task<IEnumerable<LoanDto>> GetActiveLoansAsync()
        {
            var loans = await _uow.Loans.GetActiveLoansAsync();
            return _mapper.Map<IEnumerable<LoanDto>>(loans);
        }

        public async Task<LoanDto> ReturnLoanAsync(int loanId)
        {
            var loan = await _uow.Loans.GetByIdAsync(loanId);
            if (loan == null)
                throw new NotFoundException("El préstamo no existe.");

            if (loan.Status == "Returned")
                throw new BusinessException("El préstamo ya fue devuelto.");

            loan.Status = "Returned";
            loan.ReturnDate = DateTime.Now;

            var book = await _uow.Books.GetByIdAsync(loan.BookId);
            book.Stock++;

            _uow.Loans.Update(loan);
            _uow.Books.Update(book);

            await _uow.SaveChangesAsync();

            return _mapper.Map<LoanDto>(loan);
        }
    }
}
