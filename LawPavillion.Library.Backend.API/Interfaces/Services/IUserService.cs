using TechArt;

using LawPavillion.Library.Backend.API.Dtos;

namespace LawPavillion.Library.Backend.API.Interfaces.Services
{
    /// <summary>
    /// Business logic interface for user authentication and registration.
    /// Uses BaseResponse for consistent API behavior.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Registers a new user account.
        /// </summary>
        /// <param name="dto">User registration data</param>
        /// <returns>Response indicating success or failure</returns>
        Task<BaseResponse<bool>> RegisterAsync(UserRegistrationDto dto);

        /// <summary>
        /// Authenticates a user and returns a JWT token if successful.
        /// </summary>
        /// <param name="dto">User login credentials</param>
        /// <returns>JWT token wrapped in a BaseResponse</returns>
        Task<BaseResponse<string>> AuthenticateAsync(UserLoginDto dto);
    }
}
