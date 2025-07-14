using LawPavillion.Library.Backend.API.Entities;

namespace LawPavillion.Library.Backend.API.Interfaces.Repositories
{
    /// <summary>
    /// Interface for user repository. Handles data access related to authentication.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves a user by username (used for login or validation).
        /// </summary>
        /// <param name="username">Username to search for</param>
        /// <returns>User entity if found; otherwise null</returns>
        Task<User> GetByUsernameAsync(string username);

        /// <summary>
        /// Adds a new user to the database (used during registration).
        /// </summary>
        /// <param name="user">User entity to add</param>
        /// <returns>Newly created User entity</returns>
        Task<User> AddAsync(User user);
    }
}
