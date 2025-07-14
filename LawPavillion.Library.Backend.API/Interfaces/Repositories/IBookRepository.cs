using LawPavillion.Library.Backend.API.Entities;

namespace LawPavillion.Library.Backend.API.Interfaces.Repositories
{
    /// <summary>
    /// Interface for book repository, handles data access logic for Book entity.
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Adds a new book to the database.
        /// </summary>
        /// <param name="book">Book entity to add</param>
        /// <returns>Added Book entity</returns>
        Task<Book> AddAsync(Book book);

        /// <summary>
        /// Retrieves all books.
        /// </summary>
        /// <returns>Collection of all Book entities</returns>
        Task<IEnumerable<Book>> GetAllAsync();

        /// <summary>
        /// Retrieves a book by its ID.
        /// </summary>
        /// <param name="id">Book ID</param>
        /// <returns>Book entity if found; otherwise null</returns>
        Task<Book> GetByIdAsync(int id);

        /// <summary>
        /// Updates an existing book's details.
        /// </summary>
        /// <param name="book">Updated Book entity</param>
        /// <returns>Updated Book entity</returns>
        Task<Book> UpdateAsync(Book book);

        /// <summary>
        /// Deletes a book by ID.
        /// </summary>
        /// <param name="id">Book ID</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Searches books by title or author.
        /// </summary>
        /// <param name="search">Search query string</param>
        /// <returns>Filtered list of Book entities</returns>
        Task<IEnumerable<Book>> SearchByTitleOrAuthorAsync(string search);

        /// <summary>
        /// Retrieves books using pagination.
        /// </summary>
        /// <param name="pageNumber">Page number (starting from 1)</param>
        /// <param name="pageSize">Number of books per page</param>
        /// <returns>Paged list of Book entities</returns>
        Task<IEnumerable<Book>> GetPagedAsync(int pageNumber, int pageSize);
    }
}
