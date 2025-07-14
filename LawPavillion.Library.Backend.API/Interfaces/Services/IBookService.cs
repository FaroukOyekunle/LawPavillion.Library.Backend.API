using LawPavillion.Library.Backend.API.Dtos;
using TechArt;


namespace LawPavillion.Library.Backend.API.Interfaces.Services
{
    /// <summary>
    /// Business logic interface for book-related operations,
    /// returns BaseResponse-wrapped results for consistency.
    /// </summary>
    public interface IBookService
    {
        Task<BaseResponse<BookDto>> CreateAsync(CreateBookDto dto);

        Task<BaseResponse<IEnumerable<BookDto>>> GetAllAsync();

        Task<BaseResponse<BookDto>> GetByIdAsync(int id);

        Task<BaseResponse<BookDto>> UpdateAsync(UpdateBookDto dto);

        Task<BaseResponse<bool>> DeleteAsync(int id);

        Task<BaseResponse<IEnumerable<BookDto>>> SearchAsync(string search);

        Task<BaseResponse<IEnumerable<BookDto>>> PaginateAsync(int pageNumber, int pageSize);
    }
}
