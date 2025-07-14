using Microsoft.EntityFrameworkCore;

using LawPavillion.Library.Backend.API.Data;
using LawPavillion.Library.Backend.API.Entities;
using LawPavillion.Library.Backend.API.Interfaces.Repositories;

namespace LawPavillion.Library.Backend.API.Repositories
{
    /// <summary>
    /// Repository for user-related data access using Entity Framework Core.
    /// Implements IUserRepository for handling login and registration.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">User entity to persist</param>
        /// <returns>The created User entity</returns>
        public async Task<User> AddAsync(User user)
        {
            var entry = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        /// <summary>
        /// Retrieves a user by username (case-sensitive).
        /// Returns null if no match is found.
        /// </summary>
        /// <param name="username">The username to search for</param>
        /// <returns>User entity if found; otherwise null</returns>
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.Username == username);
        }
    }
}
