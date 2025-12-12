using AutoMapper;
using Library.Application.DTOs;
using Library.Domain.Entities;

namespace Library.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Libros
            CreateMap<Book, BookDto>();
            CreateMap<CreateBookDto, Book>();

            // Préstamos
            CreateMap<Loan, LoanDto>()
                .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title));

            CreateMap<CreateLoanDto, Loan>();
        }
    }
}
