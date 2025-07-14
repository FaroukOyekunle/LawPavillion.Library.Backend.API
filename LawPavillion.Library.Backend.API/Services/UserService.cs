using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using TechArt;

using LawPavillion.Library.Backend.API.Dtos;
using LawPavillion.Library.Backend.API.Entities;
using LawPavillion.Library.Backend.API.Helpers;
using LawPavillion.Library.Backend.API.Interfaces.Repositories;
using LawPavillion.Library.Backend.API.Interfaces.Services;


namespace LawPavillion.Library.Backend.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IConfiguration _config;

        public UserService(IUserRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        /// <summary>
        /// Registers a new user after checking if the username already exists.
        /// Password is hashed with HMACSHA512 and stored with its salt.
        /// </summary>
        public async Task<BaseResponse<bool>> RegisterAsync(UserRegistrationDto dto)
        {
            var existingUser = await _repo.GetByUsernameAsync(dto.Username);
            if (existingUser != null)
            {
                return new BaseResponse<bool>().CreateResponse(ConstantMessages.InvalidData, false, false, 400);
            }

            // Create new user with hashed password and salt
            using var hmac = new HMACSHA512();
            var user = new User
            {
                Username = dto.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
                PasswordSalt = hmac.Key
            };

            await _repo.AddAsync(user);
            return new BaseResponse<bool>().CreateResponse(ConstantMessages.RegistrationSuccess, true, true, 201);
        }

        /// <summary>
        /// Authenticates a user by validating the password and returns a JWT if successful.
        /// </summary>
        public async Task<BaseResponse<string>> AuthenticateAsync(UserLoginDto dto)
        {
            var user = await _repo.GetByUsernameAsync(dto.Username);
            if (user == null)
            {
                return new BaseResponse<string>().CreateResponse(ConstantMessages.LoginFailed, false, null, 401);
            }

            // Compute hash using stored salt and compare with stored hash
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computed = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));

            for (int i = 0; i < computed.Length; i++)
            {
                if (computed[i] != user.PasswordHash[i])
                {
                    return new BaseResponse<string>().CreateResponse(ConstantMessages.LoginFailed, false, null, 401);
                }
            }

            // Generate JWT token on successful authentication
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Username) }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new BaseResponse<string>().CreateResponse("Login successful", true, tokenString, 200);
        }
    }
}
