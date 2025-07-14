using AutoMapper;
using TechArt;

using LawPavillion.Library.Backend.API.Dtos;
using LawPavillion.Library.Backend.API.Entities;
using LawPavillion.Library.Backend.API.Helpers;
using LawPavillion.Library.Backend.API.Interfaces.Repositories;
using LawPavillion.Library.Backend.API.Interfaces.Services;


namespace LawPavillion.Library.Backend.API.Services
{
    /// <summary>
    /// Service class for managing books.
    /// Implements methods to interact with book-related data.
    /// </summary>
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repo, IMapper mapper)
        {
            _bookRepo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<BookDto>> CreateAsync(CreateBookDto dto)
        {
            var existingBooks = await _bookRepo.GetAllAsync();
            var isbnExists = existingBooks.Any(b => b.ISBN == dto.ISBN);

            if (isbnExists)
            {
                return new BaseResponse<BookDto>().CreateResponse("A book with the same ISBN already exists.", false, null, 400);
            }

            var book = _mapper.Map<Book>(dto);

            var createdBook = await _bookRepo.AddAsync(book);
            var bookDto = _mapper.Map<BookDto>(createdBook);

            return new BaseResponse<BookDto>().CreateResponse(ConstantMessages.BookCreated, true, bookDto, 201);
        }

        public async Task<BaseResponse<bool>> DeleteAsync(int id)
        {
            try
            {
                await _bookRepo.DeleteAsync(id);
                return new BaseResponse<bool>().CreateResponse(ConstantMessages.BookDeleted, true, true, 200);
            }
            catch (KeyNotFoundException)
            {
                return new BaseResponse<bool>().CreateResponse(ConstantMessages.BookNotFound, false, false, 404);
            }
        }

        public async Task<BaseResponse<IEnumerable<BookDto>>> GetAllAsync()
        {
            var books = await _bookRepo.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<BookDto>>(books);
            return new BaseResponse<IEnumerable<BookDto>>().CreateResponse(ConstantMessages.OperationSuccess, true, mapped, 200);
        }

        public async Task<BaseResponse<BookDto>> GetByIdAsync(int id)
        {
            try
            {
                var book = await _bookRepo.GetByIdAsync(id);
                var mapped = _mapper.Map<BookDto>(book);
                return new BaseResponse<BookDto>().CreateResponse(ConstantMessages.OperationSuccess, true, mapped, 200);
            }
            catch (KeyNotFoundException)
            {
                return new BaseResponse<BookDto>().CreateResponse(ConstantMessages.BookNotFound, false, null, 404);
            }
        }

        public async Task<BaseResponse<BookDto>> UpdateAsync(UpdateBookDto dto)
        {
            try
            {
                var book = await _bookRepo.GetByIdAsync(dto.Id);

                _mapper.Map(dto, book);

                var updated = await _bookRepo.UpdateAsync(book);
                var mapped = _mapper.Map<BookDto>(updated);

                return new BaseResponse<BookDto>().CreateResponse(ConstantMessages.BookUpdated, true, mapped, 200);
            }
            catch (KeyNotFoundException)
            {
                return new BaseResponse<BookDto>().CreateResponse(ConstantMessages.BookNotFound, false, null, 404);
            }
        }

        public async Task<BaseResponse<IEnumerable<BookDto>>> SearchAsync(string search)
        {
            var keyword = search?.Trim();
            var allBooks = await _bookRepo.GetAllAsync();

            var filtered = allBooks.Where(b =>
                b.Title.ToLower().Contains(keyword) ||
                b.Author.ToLower().Contains(keyword)).ToList();

            var mapped = _mapper.Map<IEnumerable<BookDto>>(filtered);
            return new BaseResponse<IEnumerable<BookDto>>().CreateResponse(ConstantMessages.OperationSuccess, true, mapped, 200);
        }

        public async Task<BaseResponse<IEnumerable<BookDto>>> PaginateAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return new BaseResponse<IEnumerable<BookDto>>().CreateResponse("Invalid pagination parameters", false, null, 400);
            }

            var pagedBooks = await _bookRepo.GetPagedAsync(pageNumber, pageSize);
            var mapped = _mapper.Map<IEnumerable<BookDto>>(pagedBooks);

            return new BaseResponse<IEnumerable<BookDto>>().CreateResponse(ConstantMessages.OperationSuccess, true, mapped, 200);
        }
    }
}
