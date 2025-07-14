using System.ComponentModel.DataAnnotations;

namespace LawPavillion.Library.Backend.API.Dtos
{
    /// <summary>
    /// DTO for new user registration. Used in POST /api/auth/register.
    /// </summary>
    public class UserRegistrationDto
    {
        [Required]
        [MinLength(4)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
