using Library.Application.DTOs;

namespace Library.Application.Interfaces.Services
{
    public interface IBookService
    {
        Task<BookDto> CreateAsync(CreateBookDto dto);
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto?> GetByIdAsync(int id);
        Task<BookDto> UpdateAsync(int id, CreateBookDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
