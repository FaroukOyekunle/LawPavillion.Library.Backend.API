using Microsoft.EntityFrameworkCore;

using LawPavillion.Library.Backend.API.Data;
using LawPavillion.Library.Backend.API.Entities;
using LawPavillion.Library.Backend.API.Helpers;
using LawPavillion.Library.Backend.API.Interfaces.Repositories;


namespace LawPavillion.Library.Backend.API.Repositories
{
    /// <summary>
    /// Concrete implementation of IBookRepository using Entity Framework Core.
    /// Handles all database operations related to Book entity.
    /// </summary>
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new book to the database and returns the created entity.
        /// </summary>
        public async Task<Book> AddAsync(Book book)
        {
            var entry = await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        /// <summary>
        /// Deletes a book by ID.
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var book = await GetByIdAsync(id); // throws if not found
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves all books from the database.
        /// </summary>
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                .AsNoTracking() // This improves performance for read-only queries
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a book by its ID. Throws exception if not found.
        /// </summary>
        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id)
                ?? throw new KeyNotFoundException(ConstantMessages.BookNotFound);
        }

        /// <summary>
        /// Updates an existing book's details and saves the changes.
        /// </summary>
        public async Task<Book> UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }

        /// <summary>
        /// Searches for books by title or author (partial match).
        /// </summary>
        public async Task<IEnumerable<Book>> SearchByTitleOrAuthorAsync(string search)
        {
            return await _context.Books
                .Where(b => b.Title.Contains(search) || b.Author.Contains(search))
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a paginated list of books.
        /// </summary>
        public async Task<IEnumerable<Book>> GetPagedAsync(int pageNumber, int pageSize)
        {
            return await _context.Books
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
